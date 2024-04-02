using System;
using System.Collections.Generic;

#nullable disable

namespace API.Models
{
    public partial class TblcontactDelAdre
    {
        public int TenentId { get; set; }
        public int ContactMyId { get; set; }
        public int DeliveryAdressId { get; set; }
        public int? CompId { get; set; }
        public int? CompLoc { get; set; }
        public string GoogleName { get; set; }
        public string Latitute { get; set; }
        public string Longitute { get; set; }
        public decimal? ContactId { get; set; }
        public string AdressShortName1 { get; set; }
        public string AdressName1 { get; set; }
        public string Addr1 { get; set; }
        public string Addr2 { get; set; }
        public string Addr3 { get; set; }
        public string Pacinumber { get; set; }
        public int? DistrictId { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int? Countryid { get; set; }
        public string Block { get; set; }
        public string Building { get; set; }
        public string Street { get; set; }
        public string Lane { get; set; }
        public string FloorNo { get; set; }
        public string ForFlat { get; set; }
        public string Remarks { get; set; }
        public long? CrupId { get; set; }
        public string Cuserid { get; set; }
        public DateTime? Entrydate { get; set; }
        public DateTime? Entrytime { get; set; }
        public DateTime? Updttime { get; set; }
        public string Active { get; set; }
        public bool? Defualt { get; set; }
        public DateTime? UploadDate { get; set; }
        public string Uploadby { get; set; }
        public DateTime? SyncDate { get; set; }
        public string Syncby { get; set; }
        public int? SynId { get; set; }
        public string SyncStatus { get; set; }
        public string PostCode { get; set; }
        public string Address3 { get; set; }
        public string UpdatedBy { get; set; }
        public string CreatedBy { get; set; }
    }
}
