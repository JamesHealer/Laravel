USE [KUPFDb]
GO
/****** Object:  StoredProcedure [dbo].[Get_DetailEmployee_History]    Script Date: 11/21/2023 7:25:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER Procedure [dbo].[Get_DetailEmployee_History]
@TenentID int = 21,
@University int = 1,
@ContractType int,
@DepartmentIDFrom int = 1,
@DepartmentIDTo int = 99999,
@Occupation int ,
@ServicesType varchar(10), ---JSM 
@STypeList varchar(10),    ---JSM 
@ServicesSubType varchar(10), ---JSM 
@Services varchar(200),
@PeriodFrom int = 202301, --JSM make this currentyeardate	 01 
@PeriodTo   int = 202312,  --JSM make this currentyeardate 12
@MyOffset INT =0,
@MyNextRows INT=100,
@TotalCount INT OUTPUT

as
begin
set nocount on;
DECLARE @CurYear VARCHAR(6) = '202301'
--SET @CurYear = DATEPART(YEAR,GETDATE())+'01'   ---JSM Getting current Year+01
--set @PeriodFrom = case when @PeriodFrom = '0' then @CurYear  end
--SET @CurYear = DATEPART(YEAR,GETDATE())+DATEPART(MONTH,GETDATE()) ---JSM Getting current Year+MM
--set @PeriodTo   = case when @PeriodTo = '0' then @CurYear  end
set @Occupation = case when @Occupation = '0' then null else @Occupation end
set @Services = case when @Services = '0' then null else @Services end
set @University = case when @University = '0' then null else @University end

set @ContractType  = case when @ContractType = '0' then null else @ContractType end
set @ServicesType = case when @ServicesType = '0' then null else @ServicesType end
set @ServicesSubType = case when @ServicesSubType = '0' then null else @ServicesSubType end

/*
SELECT @STypeList = COALESCE(@STypeList+', ' ,'')
*/
Select ROW_NUMBER() over
		(
			Order by [D].[TenentID],[D].[LocationID],[D].[Department],[D].[employeeID],[DT].[Period_code],[HD].[ServiceTypeId]
		) as RowNumber,
	   D.TenentID AS DETenentID, D.LocationID AS DEUniversity, D.employeeID AS DEemployeeID, D.ArabicName, D.EnglishName, D.Department, 
       D.Department_Name, D.ContractType, D.PFID AS DEPFID, D.SubscribedDate, D.AgreedSubAmount, 
       D.KUEmployee, D.OnSickLeave, D.MemberOfFund, D.ReSubscribed,D.LoanAmount, D.Remarks as DERemarks,
       ServiceType.REFNAME1 AS ServiceTypeEnglish, ServiceType.REFNAME2 AS ServiceTypeArabic, 
       ServiceType.SWITCH4 AS ServiceTypeSorting, ContractType.REFID AS ContractTypeID, ContractType.REFNAME1 AS ContractTypeEnglish, ContractType.REFNAME2 AS ContractTypeArabic, 
       ContractType.REFNAME3 AS ContractTypeFullName, ContractType.SWITCH4 AS ContractTypeSorting, TerminationType.REFNAME1 AS TerminationEnglish, TerminationType.REFNAME2 AS TerminationArabic, 
       TerminationType.SWITCH4 AS TerminationSorting, dbo.tblCOUNTRY.COUNTRYID, dbo.tblCOUNTRY.COUNAME1, dbo.tblCOUNTRY.COUNAME2, University.REFID AS UniversityID, University.REFNAME1 AS UniversityEnglish, 
       University.REFNAME2 AS UniversityArabic, University.SWITCH4 AS UniversitySorting,HD.TenentID AS TransactionHDTenentID,HD.MYTRANSID AS TransactionHDMYTRANSID, 
       HD.locationID AS TransactionHDUniversity,HD.employeeID AS TransactionHDemployeeID,HD.SponserProvidentID AS TransactionHDSponserProvidentID, 
       HD.ServiceID AS TransactionHDServieID,HD.MasterServiceID AS TransactionHDMasterServiceID,HD.ServiceTypeId AS TransactionHDServiceTypeId, 
       HD.ServiceSubTypeId AS TransactionHDServiceSubTypeId,HD.ServiceType AS TransactionHDServiceType,HD.ServiceSubType AS TransactionHDServiceSubType, 
       HD.Source,HD.AttachID,HD.UserDefinedNumber,HD.TransDocNo,HD.BankID,HD.VoucherNumber, 
       HD.VoucherDate,HD.AccountantID,HD.BenefeciaryName,HD.ChequeNumber,HD.ChequeDate,HD.ChequeAmount, 
       HD.CollectedDate,HD.CollectedBy,HD.Relationship,HD.CollectedPersonCID,HD.InstallmentsBegDate,HD.PeriodBegin, 
       HD.EachInstallmentsAmt,HD.TOTInstallments,HD.AllowDiscountDefault,HD.DiscountType,HD.Discount, 
       HD.DiscountedGiftAmount,HD.AmtPaid,HD.TOTAMT,HD.LoanAct,HD.HajjAct,HD.PersLoanAct, 
       HD.ConsumerLoanAct,HD.OtherAct1,HD.OtherAct2,HD.OtherAct3,HD.OtherAct4,HD.OtherAct5,HD.SerApproval1, 
       HD.ApprovalBy1,HD.ApprovedDate1,HD.SerApproval2,HD.ApprovalBy2,HD.ApprovedDate2,HD.SerApproval3, 
       HD.ApprovalBy3,HD.ApprovedDate3,HD.SerApproval4,HD.ApprovalBy4,HD.ApprovedDate4,HD.SerApproval5, 
       HD.ApprovalBy5,HD.ApprovedDate5,HD.SerApproval6,HD.ApprovalBy6,HD.ApprovedDate6,HD.PFID, 
       HD.InstallmentAmount,HD.UntilMonth,HD.DownPayment,HD.YearOfService,HD.NoOfTransactions,HD.PaidSubscriptionAmount, 
       HD.SubscriptionDueAmount,HD.LoanAmountBalance,HD.FinancialAid,HD.PFFundRevenuePercentage,HD.AdjustmentAmount, 
       HD.AdjustmentAmountRemarks,HD.FinancialAmount,HD.FinancialAmountRemarks,HD.NoOfSponsor,HD.SponsorDueAmount, 
       HD.TotalAmount,HD.FinancialAidPercentage,HD.PFFundRevenue,HD.EntireLoanAmount,HD.PayPer1,HD.DraftNumber1, 
       HD.DraftDate1,HD.DraftAmount1,HD.BankAccount1,HD.DeliveryDate1,HD.ReceivedBy1,HD.DeliveredBy1, 
       HD.DraftNumber2,HD.PayPer2,HD.DraftDate2,HD.DraftAmount2,HD.BankAccount2,HD.DeliveryDate2, 
       HD.ReceivedBy2,HD.DeliveredBy2,HD.ACTIVITYCODE,HD.MYDOCNO,HD.USERBATCHNO,HD.PROJECTNO, 
       HD.TRANSDATE,HD.REFERENCE,HD.NOTES,HD.GLPOSTREF,HD.GLPOSTREF1,HD.COMPANYID,HD.Terms, 
       HD.RefTransID,HD.signatures,HD.ExtraSwitch1,HD.ExtraSwitch2,HD.Status,HD.USERID,HD.ACTIVE, 
       HD.ReceivedDate1,HD.ReceivedDate2,HD.AmountMinus,HD.AmountPlus,HD.SystemRemarks,HD.IsDraftCreated, 
       HD.CalculatedAmount, 
	   DT.PendingAmount, DT.ReceivedAmount,
	   Occupation.REFID AS JobId, Occupation.SHORTNAME AS JobShortName, Occupation.REFNAME1 AS JobEnglish, 
       Occupation.REFNAME2 AS JobArabic, TP.MYSYSNAME, TP.PRD_YEAR, TP.PRD_MONTH, TP.PRD_START_DATE, TP.PRD_END_DATE,
       Department.REFID as DepartmentID, Department.REFNAME1 AS DepartmentEnglish, Department.REFNAME2 AS DepartmentTypeArabic,Department.Remarks AS DepartmentDesc,
	   SS.ServiceName2
into #TempTable
from DetailedEmployee  D left join 
     TransactionHD HD on d.TenentID=hd.TenentID and D.employeeID=HD.employeeID left join
     TransactionDT DT on HD.TenentID=DT.TenentID and HD.MYTRANSID=DT.MYTRANSID inner join
     TBLPERIODS TP  on TP.TenentID=DT.TenentID and tp.PERIOD_CODE=dt.PERIOD_CODE left join
     dbo.ServiceSetup SS ON HD.TenentID = SS.TenentID and HD.ServiceID=ss.ServiceID  left JOIN
     dbo.REFTABLE AS Occupation ON D.TenentID = Occupation.TenentID AND D.job_title_code = Occupation.REFID  and Occupation.REFSUBTYPE='Occupation' LEFT  JOIN
     dbo.tblCOUNTRY ON D.TenentID = dbo.tblCOUNTRY.TenentID AND D.coun_code = dbo.tblCOUNTRY.COUNTRYID   LEFT  JOIN
     dbo.REFTABLE AS ContractType ON D.TenentID = ContractType.TenentID AND D.ContractType = ContractType.REFID  and ContractType.REFSUBTYPE='ContractType' LEFT  JOIN
     dbo.REFTABLE AS University ON D.TenentID = University.TenentID AND D.LocationID = University.REFID  and University.REFSUBTYPE='University' LEFT  JOIN
     dbo.REFTABLE AS TerminationType ON D.TenentID = TerminationType.TenentID AND D.termination_id = TerminationType.REFID and TerminationType.REFSUBTYPE = 'Termination' left join
     dbo.REFTABLE AS ServiceType ON SS.ServiceType = ServiceType.REFID AND SS.TenentID = ServiceType.TenentID and ServiceType.REFSUBTYPE = 'ServiceType' left join
     dbo.REFTABLE AS Department ON D.TenentID = Department.TenentID AND D.Department = Department.REFID and Department.REFSUBTYPE = 'Department' 
 WHERE D.ContractType=ISNULL(@ContractType,D.ContractType)
   and D.Department between @DepartmentIDFrom and @DepartmentIDTo
   and D.job_title_code=ISNULL(@Occupation,D.job_title_code)
   and HD.ServiceSubTypeId=ISNULL(@Services,HD.ServiceSubTypeId)
   and SS.ServiceType in(select * from STRING_SPLIT(isnull(@Services, CAST(SS.ServiceType as varchar(200))),',')) ---JSM I have hardcoded as this is my ultimate task that I want to achieve
   and TP.PERIOD_CODE between @PeriodFrom and @PeriodTo
   and D.TenentID=@TenentID and D.LocationID=ISNULL(@University,D.LocationID)

SELECT @TotalCount = COUNT(*)
FROM #TempTable

SELECT * FROM #TempTable
WHERE RowNumber BETWEEN(@MyOffset+1) AND (@MyOffset + @MyNextRows)

DROP TABLE #TempTable

END 