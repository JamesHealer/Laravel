using System;
using System.Collections.Generic;

#nullable disable

namespace API.Models
{
    public partial class VoucherDetail
    {
        public int TenentId { get; set; }
        public int LocationId { get; set; }
        public int VoucherDetailId { get; set; }
        public int VoucherId { get; set; }
        public int AccountId { get; set; }
        public decimal? Amount { get; set; }
        public decimal? Dr { get; set; }
        public decimal? Cr { get; set; }
        public string Particular { get; set; }
        public string ChequeNo { get; set; }
        public DateTime? ChequeDate { get; set; }
        public bool? IsPaid { get; set; }
        public int? CostCenterId { get; set; }
        public int? ClearedBy { get; set; }
        public DateTime? ClearedDate { get; set; }
        public DateTime? ClearedDateTime { get; set; }
    }
}
