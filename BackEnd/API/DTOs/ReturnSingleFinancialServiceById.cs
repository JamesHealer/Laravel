using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class ReturnSingleFinancialServiceById
    {
        public long Mytransid { get; set; }
        public string PFID { get; set; }
        public string EmployeeId { get; set; }
        public string ArabicName { get; set; }
        public string EnglishName { get; set; }
        public string ContractType { get; set; }
        public int? Department { get; set; }
        public string DepartmentName { get; set; }
        public short? EmpGender { get; set; }
        public DateTime? EmpBirthday { get; set; }
        public string EmpCidNum { get; set; }
        public string? EmpMaritalStatus { get; set; }
        public string NationName { get; set; }
        public decimal? Salary { get; set; }
        public string EmpWorkTelephone { get; set; }
        public string EmpWorkEmail { get; set; }
        public string MobileNumber { get; set; }
        public string Remarks { get; set; }

        public string LoanAct { get; set; }
        public string HajjAct { get; set; }
        public string ConsumerLoanAct { get; set; }
        public string PersLoanAct { get; set; }
        public string OtherAct1 { get; set; }
        public string OtherAct2 { get; set; }
        public string OtherAct3 { get; set; }
        public string OtherAct4 { get; set; }
        public string OtherAct5 { get; set; }
        public string? SerApproval1 { get; set; }
        public string? ApprovalBy1 { get; set; }
        public DateTime? ApprovedDate1 { get; set; }
        public string? SerApproval2 { get; set; }
        public string? ApprovalBy2 { get; set; }
        public DateTime? ApprovedDate2 { get; set; }
        public string? SerApproval3 { get; set; }
        public string? ApprovalBy3 { get; set; }
        public DateTime? ApprovedDate3 { get; set; }
        public string? SerApproval4 { get; set; }
        public string? ApprovalBy4 { get; set; }
        public DateTime? ApprovedDate4 { get; set; }
        public string? SerApproval5 { get; set; }
        public string? ApprovalBy5 { get; set; }
        public DateTime? ApprovedDate5 { get; set; }
        public DateTime? JoinedDate { get; set; }
        public string? ServiceType { get; set; }
        public string? ServiceSubType { get; set; }
        public decimal? Totinstallments { get; set; }
        public decimal? Totamt { get; set; }
        public decimal? AmtPaid { get; set; }
        public decimal? InstallmentAmount { get; set; }
        public DateTime InstallmentsBegDate { get; set; }
        public bool? AllowDiscountDefault { get; set; }
        public string UntilMonth { get; set; }
        public List<TransactionHDDMSDto> TransactionHDDMSDto { get; set; }
        public decimal? DownPayment { get; set; }
        public int? ServiceTypeId { get; set; }
        public int? ServiceSubTypeId { get; set; }
        public int? DiscountType { get; set; }
        public decimal? AllowDiscountAmount { get; set; }
        public string? KinName { get; set; }
        public string? KinMobile { get; set; }
        public string? SubscriptionStatus { get; set; }
        public string? EmployeeStatus { get; set; }

        public DateTime? EndDate { get; set; }
        public DateTime? TerminationDate { get; set; }
        public decimal? SubscriptionAmount { get; set; }
        public decimal? PaidSubscriptionAmount { get; set; }
        public decimal? SubscriptionDueAmount { get; set; }
        public decimal? LastSubscriptionPaid { get; set; }
        public decimal? FinancialAmount { get; set; }
        public string? FinancialAmountRemarks { get; set; }
        public string? FinancialAidPercentage { get; set; }
        public decimal? FinancialAid { get; set; }
        public decimal? PFFundRevenue { get; set; }
        public decimal? PFFundRevenuePercentage { get; set; }
        public decimal? AdjustmentAmount { get; set; }
        public decimal? LoanAmountBalance { get; set; }
        public string? AdjustmentAmountRemarks { get; set; }
        public decimal? CalculatedAmount { get; set; }
        public decimal? Discount { get; set; }
        public decimal? DiscountedGiftAmount { get; set; }
        public string? YearOfService { get; set; }
    }

    public class EmployeeDetailsWithAllServiceData
    {
        public long Mytransid { get; set; }
        public string PFID { get; set; }
        public string EmployeeId { get; set; }
        public string ArabicName { get; set; }
        public string EnglishName { get; set; }
        public string ContractType { get; set; }
        public int? Department { get; set; }
        public string DepartmentName { get; set; }
        public short? EmpGender { get; set; }
        public DateTime? EmpBirthday { get; set; }
        public string EmpCidNum { get; set; }
        public string? EmpMaritalStatus { get; set; }
        public string NationName { get; set; }
        public decimal? Salary { get; set; }
        public string EmpWorkTelephone { get; set; }
        public string EmpWorkEmail { get; set; }
        public string MobileNumber { get; set; }
        public string Remarks { get; set; }

        public string LoanAct { get; set; }
        public string HajjAct { get; set; }
        public string ConsumerLoanAct { get; set; }
        public string PersLoanAct { get; set; }
        public string OtherAct1 { get; set; }
        public string OtherAct2 { get; set; }
        public string OtherAct3 { get; set; }
        public string OtherAct4 { get; set; }
        public string OtherAct5 { get; set; }
        public string? SerApproval1 { get; set; }
        public string? ApprovalBy1 { get; set; }
        public DateTime? ApprovedDate1 { get; set; }
        public string? SerApproval2 { get; set; }
        public string? ApprovalBy2 { get; set; }
        public DateTime? ApprovedDate2 { get; set; }
        public string? SerApproval3 { get; set; }
        public string? ApprovalBy3 { get; set; }
        public DateTime? ApprovedDate3 { get; set; }
        public string? SerApproval4 { get; set; }
        public string? ApprovalBy4 { get; set; }
        public DateTime? ApprovedDate4 { get; set; }
        public string? SerApproval5 { get; set; }
        public string? ApprovalBy5 { get; set; }
        public DateTime? ApprovedDate5 { get; set; }
        public DateTime? JoinedDate { get; set; }
        public string? ServiceType { get; set; }
        public string? ServiceSubType { get; set; }
        public decimal? Totinstallments { get; set; }
        public decimal? Totamt { get; set; }
        public decimal? AmtPaid { get; set; }
        public decimal? InstallmentAmount { get; set; }
        public DateTime InstallmentsBegDate { get; set; }
        public bool? AllowDiscountDefault { get; set; }
        public string UntilMonth { get; set; }
        public List<TransactionHDDMSDto> TransactionHDDMSDto { get; set; }
        public decimal? DownPayment { get; set; }
        public int? ServiceTypeId { get; set; }
        public int? ServiceSubTypeId { get; set; }
        public int? DiscountType { get; set; }
        public decimal? AllowDiscountAmount { get; set; }
        public string? KinName { get; set; }
        public string? KinMobile { get; set; }
        public string? SubscriptionStatus { get; set; }
        public string? EmployeeStatus { get; set; }

        public DateTime? EndDate { get; set; }
        public DateTime? TerminationDate { get; set; }
        public decimal? SubscriptionAmount { get; set; }
        public decimal? PaidSubscriptionAmount { get; set; }
        public decimal? SubscriptionDueAmount { get; set; }
        public decimal? LastSubscriptionPaid { get; set; }
        public List<TransactionDt> TransactionDt { get; set; }
    }
}
