using System;
using System.Collections.Generic;

#nullable disable

namespace API.Models
{
    public partial class Iccatsubcat
    {
        public int Companyid { get; set; }
        public int Mycatsubid { get; set; }
        public int? Catid { get; set; }
        public string Cattype { get; set; }
        public int? Subcatid { get; set; }
        public string Subcattype { get; set; }
        public string Remarks { get; set; }
        public string Itemid { get; set; }
        public int? Status { get; set; }
        public long? CrupId { get; set; }
    }
}
