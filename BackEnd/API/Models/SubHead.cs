using System;
using System.Collections.Generic;

#nullable disable

namespace API.Models
{
    public partial class SubHead
    {
        public int TenentId { get; set; }
        public int LocationId { get; set; }
        public int SubHeadId { get; set; }
        public int HeadId { get; set; }
        public int SubHeadCode { get; set; }
        public string SubHeadName { get; set; }
        public string ArabicSubHeadName { get; set; }
        public string Remarks { get; set; }
        public bool IsActive { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public long? Crupid { get; set; }
        public int? CrFlag { get; set; }
        public decimal? BalanceAmt { get; set; }
    }
}
