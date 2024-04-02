using System;
using System.Collections.Generic;

#nullable disable

namespace API.Models
{
    public partial class RefTableAdmin
    {
        public int TenentId { get; set; }
        public int RefAdminId { get; set; }
        public string RefType { get; set; }
        public string RefSubType { get; set; }
        public string MySysName { get; set; }
        public string Descrip { get; set; }
        public string Admin { get; set; }
        public string NormalUser { get; set; }
        public string Switch1 { get; set; }
        public string Remarks { get; set; }
        public int? StartSerial { get; set; }
        public int? EndSerial { get; set; }
        public string Active { get; set; }
        public long? CrupId { get; set; }
        public string Infrastructure { get; set; }
        public DateTime? SyncDate { get; set; }
    }
}
