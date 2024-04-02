using System;
using System.Collections.Generic;

#nullable disable

namespace API.Models
{
    public partial class Tbltranssubtype
    {
        public int TenentId { get; set; }
        public int Transid { get; set; }
        public string Mysysname { get; set; }
        public int Transsubid { get; set; }
        public string Transsubtype1 { get; set; }
        public string Transsubtype2 { get; set; }
        public string Transsubtype3 { get; set; }
        public string OpQtyBeh { get; set; }
        public string OnHandBeh { get; set; }
        public string QtyOutBeh { get; set; }
        public string QtyConsumedBeh { get; set; }
        public string QtyReservedBeh { get; set; }
        public string QtyAtDestination { get; set; }
        public string QtyAtSource { get; set; }
        public string Serialno { get; set; }
        public string Years { get; set; }
        public string Active { get; set; }
        public long? CrupId { get; set; }
        public string Transsubtype { get; set; }
        public string CashBeh { get; set; }
        public string QtyReceivedBeh { get; set; }
    }
}
