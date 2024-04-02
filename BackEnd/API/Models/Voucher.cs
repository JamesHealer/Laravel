using System;
using System.Collections.Generic;

#nullable disable

namespace API.Models
{
    public partial class Voucher
    {
        public int TenentId { get; set; }
        public int LocationId { get; set; }
        public int VoucherId { get; set; }
        public string VoucherCode { get; set; }
        public int FperiodId { get; set; }
        public int VoucherTypeId { get; set; }
        public int? AccountId { get; set; }
        public DateTime VoucherDate { get; set; }
        public bool IsPosted { get; set; }
        public string Narrations { get; set; }
        public string ReceiverName { get; set; }
        public string ReferenceNo { get; set; }
        public int? CostCenterId { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public long? Crupid { get; set; }
        public string OriginalFileName { get; set; }
        public string FileExtension { get; set; }
        public string FileContentType { get; set; }
        public string FilePath { get; set; }
        public bool? IsSingleEntry { get; set; }
    }
}
