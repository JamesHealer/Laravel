using System;
using System.Collections.Generic;

#nullable disable

namespace API.Models
{
    public partial class TransactionHd
    {
        public int TenentId { get; set; }
        public long Mytransid { get; set; }
        public int? LocationId { get; set; }
        public int? EmployeeId { get; set; }
        public int? SponserProvidentID { get; set; }
        public int? ServiceId { get; set; }
        public int? MasterServiceId { get; set; }
        public int? ServiceTypeId { get; set; }
        public int? ServiceSubTypeId { get; set; }
        public string? ServiceType { get; set; }
        public string? ServiceSubType { get; set; }
        public string Source { get; set; }
        public int? AttachId { get; set; }
        public string TransDocNo { get; set; }
        public string? UserDefinedNumber { get; set; }
        public long? BankId { get; set; }
        public string? VoucherNumber { get; set; }
        public DateTime? VoucherDate { get; set; }
        public int? AccountantID { get; set; }
        public string? BenefeciaryName { get; set; }
        public string? ChequeNumber { get; set; }
        public DateTime? ChequeDate { get; set; }
        public decimal? ChequeAmount { get; set; }
        public DateTime? CollectedDate { get; set; }
        public string? CollectedBy { get; set; }
        public string? Relationship { get; set; }
        public string? CollectedPersonCID { get; set; }
        public decimal? EachInstallmentsAmt { get; set; }
        public decimal? Totinstallments { get; set; }
        public decimal? Totamt { get; set; }
        public decimal? AmtPaid { get; set; }
        public string LoanAct { get; set; }
        public string HajjAct { get; set; }
        public string PersLoanAct { get; set; }
        public string ConsumerLoanAct { get; set; }
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
        public string Activitycode { get; set; }
        public int? Mydocno { get; set; }
        public string Userbatchno { get; set; }
        public string Projectno { get; set; }
        public DateTime Transdate { get; set; }
        public string Reference { get; set; }
        public string Notes { get; set; }
        public string Glpostref { get; set; }
        public string Glpostref1 { get; set; }
        public int? Companyid { get; set; }
        public decimal? Discount { get; set; }
        public decimal? DiscountedGiftAmount { get; set; }
        public int? Terms { get; set; }
        public int? RefTransId { get; set; }
        public string Signatures { get; set; }
        public string ExtraSwitch1 { get; set; }
        public string ExtraSwitch2 { get; set; }
        public string Status { get; set; }
        public long? CrupId { get; set; }
        public string Userid { get; set; }
        public bool? Active { get; set; }
        public DateTime? Entrydate { get; set; }
        public DateTime? Entrytime { get; set; }
        public DateTime? Updttime { get; set; }
        public decimal? InstallmentAmount { get; set; }
        public DateTime? InstallmentsBegDate { get; set; }
        public string? UntilMonth { get; set; }
        public decimal? DownPayment { get; set; }
        //
        public decimal? EntireLoanAmount { get; set; }
        public string? FinancialAidPercentage { get; set; }
        public decimal? PFFundRevenue { get; set; }
        public decimal? PFFundRevenuePercentage { get; set; }
        public decimal? AdjustmentAmount { get; set; }
        public string? AdjustmentAmountRemarks { get; set; }
        public decimal? FinancialAmount { get; set; }
        public string? FinancialAmountRemarks { get; set; }
        public int? NoOfSponsor { get; set; }
        public decimal? SponsorDueAmount { get; set; }

        //
        public string? YearOfService { get; set; }
        public int? NoOfTransactions { get; set; }
        public decimal? PaidSubscriptionAmount { get; set; }
        public decimal? SubscriptionDueAmount { get; set; }
        public decimal? LoanAmountBalance { get; set; }
        public decimal? FinancialAid { get; set; }
        public decimal? TotalAmount { get; set; }
        //
        public decimal? PayPer1 { get; set; }
        public int? DraftNumber1 { get; set; }
        public DateTime? DraftDate1 { get; set; }
        public decimal? DraftAmount1 { get; set; }
        public string? BankAccount1 { get; set; }
        public DateTime? DeliveryDate1 { get; set; }
        public string? ReceivedBy1 { get; set; }
        public string? DeliveredBy1 { get; set; }

        public decimal? PayPer2 { get; set; }
        public int? DraftNumber2 { get; set; }
        public DateTime? DraftDate2 { get; set; }
        public decimal? DraftAmount2 { get; set; }
        public string? BankAccount2 { get; set; }
        public DateTime? DeliveryDate2 { get; set; }
        public string? ReceivedBy2 { get; set; }
        public string? DeliveredBy2 { get; set; }
        public DateTime? ReceivedDate1 { get; set; }
        public DateTime? ReceivedDate2 { get; set; }
        public int? DiscountType { get; set; }
        public int? PeriodBegin { get; set; }
        public bool? AllowDiscountDefault { get; set; }
        public string? SerApproval6 { get; set; }
        public string? ApprovalBy6 { get; set; }
        public DateTime? ApprovedDate6 { get; set; }
        public string? PFID { get; set; }
        public decimal? AmountMinus { get; set; }
        public decimal? AmountPlus { get; set; }
        public string? SystemRemarks { get; set; }
        public bool IsDraftCreated { get; set; }
        public decimal? CalculatedAmount { get; set; }
    }
}
