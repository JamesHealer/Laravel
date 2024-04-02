using System;
using System.Collections.Generic;

#nullable disable

namespace API.Models
{
    public partial class FinancialPeriod
    {
        public int TenentId { get; set; }
        public int LocationId { get; set; }
        public int FperiodId { get; set; }
        public string YearCode { get; set; }
        public string DescripitonEng { get; set; }
        public string DescripitonArabic { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsActive { get; set; }
        public long? Crupid { get; set; }
    }
}
