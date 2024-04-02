using System;
using System.Collections.Generic;

#nullable disable

namespace API.Models
{
    public partial class AccountHead
    {
        public int TenentId { get; set; }
        public int LocationId { get; set; }
        public int HeadId { get; set; }
        public int FamilyId { get; set; }
        public int HeadCode { get; set; }
        public string HeadName { get; set; }
        public string ArabicHeadName { get; set; }
        public bool? IsActive { get; set; }
        public long? Crupid { get; set; }
        public decimal? BalanceAmt { get; set; }
    }
}
