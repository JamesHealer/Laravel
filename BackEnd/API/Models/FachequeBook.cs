using System;
using System.Collections.Generic;

#nullable disable

namespace API.Models
{
    public partial class FachequeBook
    {
        public int TenentId { get; set; }
        public int ChequeId { get; set; }
        public int? BankId { get; set; }
        public string ChequeName1 { get; set; }
        public string ChequeName2 { get; set; }
        public string ChequeName3 { get; set; }
        public int? Amount { get; set; }
        public DateTime? Dated { get; set; }
        public DateTime? DateOutFromBank { get; set; }
        public int? Compid { get; set; }
        public string Remarks { get; set; }
        public int? ContactMyId { get; set; }
        public string Switch1 { get; set; }
        public bool? Active { get; set; }
        public long? CrupId { get; set; }
        public DateTime? SyncDate { get; set; }
    }
}
