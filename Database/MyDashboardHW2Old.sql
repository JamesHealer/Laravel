USE [KUPFDb]
GO
/****** Object:  StoredProcedure [dbo].[MyDashboardSave]    Script Date: 18-02-2023 01:46:06 ******/
--- Find this month new subscription =1
--- Find Subscribed Total ACTIVE Subscribed Employee #2
--- Find this month new Transactions as table =3 provide the Date & Time and job Completed by
--- #4 Find the Approval Status of this month by drop down of the Approval by
--- #5 Employee Performance by Employee ID and Week of this Month , Last Month
--- 

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROC [dbo].[MyDashboardSave]
(
	 @TenentID                                int = 21
	,@LocationId                              int = 1
	,@CurrentPeriod                           BIGINT = 202302
)
AS
BEGIN
	DECLARE
		 @CP_Begin                                Date
		,@CP_End                                  date
		,@PrevPeriod                              int
		,@PR_Begin                                Date
		,@PR_End                                  date
		,@NextPeriod                              int
		,@NT_Begin                                Date
		,@NT_End                                  date
		,@MyDateHW                                date
		,@MyEmployeeIdT                           int=0
		,@MyEmpNameT                              nvarchar(150)
		,@MyPeriodCodeT                           int
		,@MyTransIdT                              Bigint=0
		,@MainTypeT								  nvarchar(100)
		,@SubType1T								  nvarchar(100)
		,@AsOfDateT								  date
		,@MyMaxNow                                int=0
		,@MyMainSessionSeq                        int=0
		,@MyCountFound                            int=0
		,@MyRunCount                              int=0
		,@ClickMeT								  nvarchar(50)
		,@Action                                  VARCHAR(50)
		,@Label1								  VARCHAR(50)
		,@Value1								  decimal(18,2)=1.00
		,@Label2								  VARCHAR(50)
		,@Value2								  decimal(18,2)=1.00
		--,@Remarks                               nvarchar(1000)
BEGIN
	SELECT @MyMainSessionSeq=MAX(ISNULL(MainSessionSeq,0))+1 FROM MyDashboard WHERE TenentID=@TenentID and LocationID=@LocationId 

	SELECT  @CP_Begin=PRD_START_DATE, @CP_End=PRD_END_DATE,@PR_Begin=PRD_START_DATE-1, @NT_End=PRD_END_DATE+1
	 FROM TBLPERIODS WHERE TenentID= @TenentID and PERIOD_CODE=@CurrentPeriod

	SELECT @PrevPeriod=PERIOD_CODE, @PR_Begin=PRD_START_DATE, @PR_End=PRD_END_DATE,@PR_Begin=PRD_START_DATE-1, @NT_End=PRD_END_DATE+1
	 FROM TBLPERIODS WHERE TenentID= @TenentID and @PR_Begin BETWEEN PRD_START_DATE AND PRD_END_DATE

	SELECT @NextPeriod=PERIOD_CODE, @NT_Begin=PRD_START_DATE, @NT_End=PRD_END_DATE,@PR_Begin=PRD_START_DATE-1, @NT_End=PRD_END_DATE+1
	 FROM TBLPERIODS WHERE TenentID= @TenentID and @NT_End BETWEEN PRD_START_DATE AND PRD_END_DATE

--- Find this month new subscription =1
    select @MyCountFound=COUNT(*) from TransactionHD 
	 where TenentID=@TenentID and LocationID=@LocationId 
	   and transdate between @CP_Begin and @CP_End AND ServiceTypeId=1 AND ServiceSubTypeId IN (1,2)
	SET @MyMaxNow=1;
    print 'NewSubThisMonth 1='+CAST(@MyCountFound AS VARCHAR)
    IF @MyCountFound>0
		INSERT INTO MyDashboard
			(
				 MainSessionSeq
				,TenentID
				,locationID
				,AsOfDate
				,MainType
				,SubType1
				,MySeq
				,MyLabel1
				,MyValue1
				,MyLabel2
				,MyValue2
				,MyPeriodCode
			)
			VALUES
			(    @MyMainSessionSeq
				,@TenentID
				,@locationID
				,GETDATE()
				,@MyCountFound
				,''
				,@MyMaxNow
				,'NewSubThisMonth'
				,@MyCountFound
				,@CurrentPeriod
				,'NewSubThisMonth'
				,@MyCountFound
			)
--- Find Subscribed Total ACTIVE Subscribed Employee #2
	SET @MyMaxNow=2;
	select @MyCountFound = count(*) 
	  FROM DetailedEmployee A
	 where A.TenentID=21 and A.LocationID=1 
	   and (A.PFID is not null or A.PFID != '')	
       and (A.termination_id IS NULL or A.TerminationDate IS NULL)
       print 'SubscribedEmpl 2='+CAST(@MyCountFound AS VARCHAR)
     IF @MyCountFound>0
        INSERT INTO MyDashboard
		(	 MainSessionSeq,TenentID
			,locationID
			,AsOfDate
			,MainType
			,SubType1
			,MySeq
			,MyLabel1
			,MyValue1
			,MyPeriodCode
		)
		VALUES
		(	 @MyMainSessionSeq,@TenentID
			,@locationID
			,GETDATE()
			,@MyCountFound
			,''
			,@MyMaxNow
			,'SubscribedEmpl'
			,@MyCountFound
			,@CurrentPeriod
		)
---	   raiserror('this is a raised error', 18, 1)
--- Find this month new Transactions as table =3
    SET @MyCountFound=1;
	SET @MyMaxNow=3;
    select @MyCountFound=count(*)
	  FROM TransactionHD B
	 where B.TenentID=@TenentID and B.LocationID=@LocationId and B.PeriodBegin= @CurrentPeriod
 
    print 'ThisMonthTotTrans 3='+CAST(@MyCountFound AS VARCHAR)
    IF @MyCountFound>0
		Begin 
			WHILE @MyRunCount < = @MyCountFound -1
				 select @MyTransIdT= B.MyTransID,@MainTypeT= A.ServiceShortName,@SubType1T= A.ServiceName2,
						@MyEmployeeIdT=B.EmployeeId,
						@MyEmpNameT=RTRIM(CAST(B.EmployeeId AS VARCHAR))+'-'+RTRIM(C.EnglishName) +'-'+ RTRIM(C.ArabicName,1), 
						@MyPeriodCodeT=B.PeriodBegin,@Value1 = B.EachInstallmentsAmt, @Label1 = 'TransMonth'
		   		   FROM TransactionHD B, DetailedEmployee C,ServiceSetup A
				  where B.TenentID=@TenentID and B.LocationID=@LocationId and B.PeriodBegin= @CurrentPeriod
				    AND A.TenentID=@TenentID and A.ServiceType = B.ServiceTypeId and A.ServiceSubType = B.ServiceSubTypeId
					and C.TenentID=@TenentID and C.LocationID=@LocationId and C.employeeID = B.employeeID
				  print 'ThisMonthTotTrans 3='++CAST(@MyCountFound AS VARCHAR)+' Trans='++CAST(@MyTransIdT AS VARCHAR)
				  INSERT INTO MyDashboard
						(	 MainSessionSeq,TenentID
							,locationID
							,TransId
							,MyEmployeeId
							,MyEmpName
							,AsOfDate
							,MainType
							,SubType1
							,MyPeriodCode
							,MySeq
							,MyLabel1
							,MyValue1
							,MyLabel2
							,MyValue2
						)
						VALUES
						(	 @MyMainSessionSeq,@TenentID
							,@locationID
							,@MyTransIdT
							,@MyEmployeeIdT
							,@MyEmpNameT
							,GETDATE()
							,@MainTypeT
							,@SubType1T
							,@CurrentPeriod
							,@MyMaxNow
							,@Label1
							,@Value1
							,@Label1
							,@Value1
						)
					set  @MyRunCount = @MyRunCount + 1;	
		END  -- End of Do While This Month Transactions
END
RETURN
END
RETURN
--BEGIN CATCH

--	THROW;

--END CATCH
