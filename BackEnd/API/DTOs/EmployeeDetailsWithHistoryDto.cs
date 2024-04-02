using API.DTOs.RefTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class EmployeeDetailsWithHistoryDtoObj
    {
        public int TotalRecords { get; set; }
        public List<EmployeeDetailsWithHistoryDto> EmpDetailsWithHistoryList { get; set; }

    }
    public class EmployeeDetailsWithHistoryDto
    {
        public int DETenentID { get; set; }
        public int DELocationID { get; set; }
        public int DEemployeeID { get; set; }
        public int Department { get; set; }
        public string ArabicName { get; set; }
        public string EnglishName { get; set; }
        public string Department_Name { get; set; }
        public int ContractType { get; set; }
        public string ContractTypeEnglish { get; set; }
        public int DEPFID { get; set; }
        public DateTime? SubscribedDate { get; set; }
        public decimal AgreedSubAmount { get; set; }
        public int KUEmployee { get; set; }
        public int OnSickLeave { get; set; }
        public int MemberOfFund { get; set; }
        public DateTime ReSubscribed { get; set; }
        public string LoanAmount { get; set; }
        public int LoanAmountBalance { get; set; }
        public int TOTInstallments { get; set; }        // HD.TOTInstallments for end_deduct = HD.PeriodBegin + TOTInstallments
        public int InstallmentsBegDate { get; set; }
        public int EachInstallmentsAmt { get; set; }
        public int TOTAMT { get; set; }                 // HD.TOTAMT for loan_value
        public int InstallmentNumber { get; set; }      // DT.InstallmentNumber for installments
        public int InstallmentAmount { get; set; }      // HD.InstallmentAmount for installment_value
        public int ServiceSubTypeId { get; set; }       // HD.ServiceSubTypeId  for loan
        public int PeriodBegin { get; set; }            // HD.PeriodBegin for start_deduct
        public int VoucherDate { get; set; }            // for member-loan-stmt.date
        public string ServiceName2 { get; set; }        // ServiceType.ServiceName2, for loan_desc
        public string ReceivedAmount { get; set; }      // DT.ReceivedAmount for member-loan-stmt.debit
        public int PendingAmount { get; set; }          // DT.PendingAmount for member-loan-stmt.balance
        public string DepartmentEnglish { get; set; }   // Reftable.REFNAME1 
        public string DepartmentTypeArabic { get; set; }    // Reftable.REFNAME2
        public string DepartmentDesc { get; set; }      // Reftable.Remarks

        /*public int ServiceSubTypeEnglish { get; set; }
        public int ServiceSubTypeArabic { get; set; }
        public int ServiceSubTypeSorting { get; set; }
        public int ServiceTypeEnglish { get; set; }
        public int ServiceTypeArabic { get; set; }
        public int ServiceTypeSorting { get; set; }
        public int ContractTypeID { get; set; }
        public int ContractTypeEnglish { get; set; }
        public int ContractTypeArabic { get; set; }
        public int ContractTypeFullName { get; set; }
        public int ContractTypeSorting { get; set; }
        public int TerminationEnglish { get; set; }
        public int TerminationArabic { get; set; }
        public int TerminationSorting { get; set; }
        public int COUNTRYID { get; set; }
        public int COUNAME1 { get; set; }
        public int COUNAME2 { get; set; }
        public int REFIDUniversityID { get; set; }
        public int UniversityEnglish { get; set; }
        public int UniversityArabic { get; set; }
        public int UniversitySorting { get; set; }
        public int TransactionHDTenentID { get; set; }
        public int TransactionHDMYTRANSID { get; set; }
        public int TransactionHDlocationID { get; set; }
        public int TransactionHDemployeeID { get; set; }
        public int TransactionHDSponserProvidentID { get; set; }
        public int TransactionHDServieID { get; set; }
        public int TransactionHDMasterServiceID { get; set; }
        public int TransactionHDServiceTypeId { get; set; }
        public int TransactionHDServiceType { get; set; }
        public int TransactionHDServiceSubType { get; set; }
        public int Source { get; set; }
        public int AttachID { get; set; }
        public int UserDefinedNumber { get; set; }
        public int TransDocNo { get; set; }
        public int BankID { get; set; }
        public int VoucherNumber { get; set; }
        public int AccountantID { get; set; }
        public int BenefeciaryName { get; set; }
        public int ChequeNumber { get; set; }
        public int ChequeDate { get; set; }
        public int ChequeAmount { get; set; }
        public int CollectedDate { get; set; }
        public int CollectedBy { get; set; }
        public int Relationship { get; set; }
        public int CollectedPersonCID { get; set; }
        public int AllowDiscountDefault { get; set; }
        public int DiscountType { get; set; }
        public int Discount { get; set; }
        public int DiscountedGiftAmount { get; set; }
        public int AmtPaid { get; set; }
        public int LoanAct { get; set; }
        public int HajjAct { get; set; }
        public int PersLoanAct { get; set; }
        public int ConsumerLoanAct { get; set; }
        public int OtherAct1 { get; set; }
        public int OtherAct2 { get; set; }
        public int OtherAct3 { get; set; }
        public int OtherAct4 { get; set; }
        public int OtherAct5 { get; set; }
        public int SerApproval1 { get; set; }
        public int ApprovalBy1 { get; set; }
        public int ApprovedDate1 { get; set; }
        public int SerApproval2 { get; set; }
        public int ApprovalBy2 { get; set; }
        public int ApprovedDate2 { get; set; }
        public int SerApproval3 { get; set; }
        public int ApprovalBy3 { get; set; }
        public int ApprovedDate3 { get; set; }
        public int SerApproval4 { get; set; }
        public int ApprovalBy4 { get; set; }
        public int ApprovedDate4 { get; set; }
        public int SerApproval5 { get; set; }
        public int ApprovalBy5 { get; set; }
        public int ApprovedDate5 { get; set; }
        public int SerApproval6 { get; set; }
        public int ApprovalBy6 { get; set; }
        public int ApprovedDate6 { get; set; }
        public int PFID { get; set; }
        public int InstallmentAmount { get; set; }
        public int UntilMonth { get; set; }
        public int DownPayment { get; set; }
        public int YearOfService { get; set; }
        public int NoOfTransactions { get; set; }
        public int PaidSubscriptionAmount { get; set; }
        public int SubscriptionDueAmount { get; set; }
        public int FinancialAid { get; set; }
        public int PFFundRevenuePercentage { get; set; }
        public int AdjustmentAmount { get; set; }
        public int AdjustmentAmountRemarks { get; set; }
        public int FinancialAmount { get; set; }
        public int FinancialAmountRemarks { get; set; }
        public int NoOfSponsor { get; set; }
        public int SponsorDueAmount { get; set; }
        public int TotalAmount { get; set; }
        public int FinancialAidPercentage { get; set; }
        public int PFFundRevenue { get; set; }
        public int EntireLoanAmount { get; set; }
        public int PayPer1 { get; set; }
        public int DraftNumber1 { get; set; }
        public int DraftDate1 { get; set; }
        public int DraftAmount1 { get; set; }
        public int BankAccount1 { get; set; }
        public int DeliveryDate1 { get; set; }
        public int ReceivedBy1 { get; set; }
        public int DeliveredBy1 { get; set; }
        public int DraftNumber2 { get; set; }
        public int PayPer2 { get; set; }
        public int DraftDate2 { get; set; }
        public int DraftAmount2 { get; set; }
        public int BankAccount2 { get; set; }
        public int DeliveryDate2 { get; set; }
        public int ReceivedBy2 { get; set; }
        public int DeliveredBy2 { get; set; }
        public int ACTIVITYCODE { get; set; }
        public int MYDOCNO { get; set; }
        public int USERBATCHNO { get; set; }
        public int PROJECTNO { get; set; }
        public int TRANSDATE { get; set; }
        public int REFERENCE { get; set; }
        public int NOTES { get; set; }
        public int GLPOSTREF { get; set; }
        public int GLPOSTREF1 { get; set; }
        public int COMPANYID { get; set; }
        public int Terms { get; set; }
        public int RefTransID { get; set; }
        public int signatures { get; set; }
        public int ExtraSwitch1 { get; set; }
        public int ExtraSwitch2 { get; set; }
        public int Status { get; set; }
        public int USERID { get; set; }
        public int ACTIVE { get; set; }
        public int ReceivedDate1 { get; set; }
        public int ReceivedDate2 { get; set; }
        public int AmountMinus { get; set; }
        public int AmountPlus { get; set; }
        public int SystemRemarks { get; set; }
        public int IsDraftCreated { get; set; }
        public int CalculatedAmount { get; set; }
        */
    }
}
