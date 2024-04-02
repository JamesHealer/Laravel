using System;
using System.Collections.Generic;

#nullable disable

namespace API.Models
{
    public partial class VoucherDetailHistory
    {
        public int TenentId { get; set; }
        public int LocationId { get; set; }
        public long VoucherDetailHistoryId { get; set; }
        public DateTime? HistoryDate { get; set; }
        public int? VoucherDetailId { get; set; }
        public int VoucherId { get; set; }
        public int AccountId { get; set; }
        public decimal Amount { get; set; }
        public string Particular { get; set; }
        public string ChequeNo { get; set; }
        public DateTime? ChequeDate { get; set; }
        public bool? IsPaid { get; set; }
        public int? CostCenterId { get; set; }
        public decimal? Dr { get; set; }
        public decimal? Cr { get; set; }
        public int? UserId { get; set; }
        public long? Crupid { get; set; }
        public string FilePath { get; set; }
        public int? ClearedBy { get; set; }
        public DateTime? ClearedDate { get; set; }
        public DateTime? ClearedDateTime { get; set; }
    }
}
