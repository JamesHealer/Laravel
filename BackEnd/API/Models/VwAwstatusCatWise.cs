using System;
using System.Collections.Generic;

#nullable disable

namespace API.Models
{
    public partial class VwAwstatusCatWise
    {
        public int TenentId { get; set; }
        public string Reftype { get; set; }
        public string Refsubtype { get; set; }
        public string Status { get; set; }
        public string Awstatus { get; set; }
        public string Sorting { get; set; }
        public string Category { get; set; }
        public string DepartmentId { get; set; }
        public string Department { get; set; }
        public string Active { get; set; }
    }
}
