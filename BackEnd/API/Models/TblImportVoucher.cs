using System;
using System.Collections.Generic;

#nullable disable

namespace API.Models
{
    public partial class TblImportVoucher
    {
        public int? TanentId { get; set; }
        public int? LocationId { get; set; }
        public int? VoucherTypeId { get; set; }
        public int? SerialNo { get; set; }
        public DateTime? VoucherDate { get; set; }
        public string AccountName { get; set; }
        public string Remarks { get; set; }
        public string ChequeNo { get; set; }
        public DateTime? ChequeDate { get; set; }
        public double? Debit { get; set; }
        public double? Credit { get; set; }
        public int? UserId { get; set; }
    }
}
