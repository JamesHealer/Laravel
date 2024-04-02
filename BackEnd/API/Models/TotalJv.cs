using System;
using System.Collections.Generic;

#nullable disable

namespace API.Models
{
    public partial class TotalJv
    {
        public double? SlNo { get; set; }
        public double? Year { get; set; }
        public string Month { get; set; }
        public string AccountHead { get; set; }
        public string SubAccountExpenses { get; set; }
        public string Remarks { get; set; }
        public double? Debit { get; set; }
        public double? Credit { get; set; }
        public double? VoucherNo { get; set; }
    }
}
