using System;

namespace API.DTOs
{
    public class VoucherDetailsDto
    {
        public long VoucherDetailID { get; set; }
        public string AccountName { get; set; }
        public string AccountId { get; set; }
        public double Amount { get; set; }
        public string Particular { get; set; }
        public string? ChequeNo { get; set; }
        public DateTime? ChequeDate { get; set; }
        public double Dr { get; set; }
        public double Cr { get; set; }
        public Int64 CostCenterID { get; set; }
        public string CostCenterName { get; set; }
    }
}
