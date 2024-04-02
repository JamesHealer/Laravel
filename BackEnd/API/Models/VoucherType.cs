using System;
using System.Collections.Generic;

#nullable disable

namespace API.Models
{
    public partial class VoucherType
    {
        public int VoucherTypeId { get; set; }
        public string VoucherName { get; set; }
        public string ArabicVoucherName { get; set; }
        public string CodePrefix { get; set; }
    }
}
