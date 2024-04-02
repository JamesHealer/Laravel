namespace API.DTOs
{
    public class FinanaceCalculationDto
    {
        public long? MyTransId { get; set; }
        public int? NoOfTransactions { get; set; }
        public decimal? SubscriptionPaidAmount { get; set; }
        public decimal? SubscriptionDueAmount { get; set; }
        public decimal? SubscriptionInstalmentAmount { get; set; }
        public decimal? FinancialAid { get; set; }
        public decimal? PFFundRevenue { get; set; }
        public decimal? AdjustmentAmount { get; set; }
        public string? AdjustmentAmountRemarks { get; set; }
        public decimal? PFFundRevenuePercentage { get; set; }
        public decimal? SponsorLoanPendingAmount { get; set; }
        public decimal? SponsorDueAmount { get; set; }
        public string? FinAidAmountRemarks { get; set; }

        public decimal? LoanPendingAmount { get; set; }
        public decimal? LoanreceivedAmount { get; set; }
        public decimal? LoanInstallmentAmount { get; set; }
        public int? NoOfSponsor { get; set; }
        public string? YearOfService { get; set; }
        public decimal? AmountMinus { get; set; }
        public decimal? AmountPlus { get; set; }
        public string? SystemRemarks { get; set; }
        public double PayableAmount { get; set; }
        public double  PayableAmountAfterOneYear { get; set; }
    }
}
