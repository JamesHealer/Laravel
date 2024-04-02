using System;
using System.Collections.Generic;

#nullable disable

namespace API.Models
{
    public partial class Tbltranstype
    {
        public int TenentId { get; set; }
        public int Transid { get; set; }
        public string Mysysname { get; set; }
        public string InoutSwitch { get; set; }
        public string Transtype1 { get; set; }
        public string Transtype2 { get; set; }
        public string Transtype3 { get; set; }
        public string Serialno { get; set; }
        public string Years { get; set; }
        public string Active { get; set; }
        public long? CrupId { get; set; }
        public string Transtype { get; set; }
        public string Switch1 { get; set; }
    }
}
