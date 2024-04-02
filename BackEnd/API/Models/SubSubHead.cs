using System;
using System.Collections.Generic;

#nullable disable

namespace API.Models
{
    public partial class SubSubHead
    {
        public int TenentId { get; set; }
        public int LocationId { get; set; }
        public int SubSubHeadId { get; set; }
        public int? SubHeadId { get; set; }
        public int? HeadId { get; set; }
        public int? SubSubHeadCode { get; set; }
        public string SubSubHeadName { get; set; }
        public string ArabicSubSubHeadName { get; set; }
        public bool? IsActive { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? Crupid { get; set; }
        public decimal? BalanceAmt { get; set; }
    }
}
