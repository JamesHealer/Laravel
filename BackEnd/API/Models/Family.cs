using System;
using System.Collections.Generic;

#nullable disable

namespace API.Models
{
    public partial class Family
    {
        public int FamilyId { get; set; }
        public string FamilyName { get; set; }
        public string ArabicName { get; set; }
        public string OtherName { get; set; }
        public bool? IsActive { get; set; }
        public long? Crupid { get; set; }
        public int? FamilyCode { get; set; }
    }
}
