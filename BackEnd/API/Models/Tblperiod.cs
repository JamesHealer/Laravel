using System;
using System.Collections.Generic;

#nullable disable

namespace API.Models
{
    public partial class Tblperiod
    {
        public int TenentId { get; set; }
        public long PeriodCode { get; set; }
        public string Mysysname { get; set; }
        public short PrdYear { get; set; }
        public string PrdMonth { get; set; }
        public string PrdPeriod1 { get; set; }
        public string PrdPeriod2 { get; set; }
        public string PrdPeriod3 { get; set; }
        public DateTime PrdStartDate { get; set; }
        public DateTime PrdEndDate { get; set; }
        public string Glpost { get; set; }
        public string Glpostref { get; set; }
        public string Icpost { get; set; }
        public string Icpostref { get; set; }
        public string Status1 { get; set; }
        public long? CrupId { get; set; }
        public string PrdPeriod { get; set; }
    }
}
