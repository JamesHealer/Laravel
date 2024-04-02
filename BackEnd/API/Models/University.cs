using System;
using System.Collections.Generic;

#nullable disable

namespace API.Models
{
    public partial class University
    {
        public int TenentId { get; set; }
        public int? Myconlocid { get; set; }
        public int UnivIdbyUser { get; set; }
        public string Physicallocid { get; set; }
        public string UnivName1 { get; set; }
        public string UnivName2 { get; set; }
        public string UnivName3 { get; set; }
        public DateTime? BeginDate { get; set; }
        public string Paciid { get; set; }
        public string CivilId { get; set; }
        public string Email { get; set; }
        public string Email1 { get; set; }
        public string Email2 { get; set; }
        public string Addr1 { get; set; }
        public string Addr2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int? Countryid { get; set; }
        public string Busphone1 { get; set; }
        public string Mobphone { get; set; }
        public string Altmobphone { get; set; }
        public string Fax { get; set; }
        public string Fax1 { get; set; }
        public string Fax2 { get; set; }
        public string Primlanguge { get; set; }
        public string Webpage { get; set; }
        public string Remarks { get; set; }
        public string Keyword { get; set; }
        public string LoanAct { get; set; }
        public int? ServiceTypeRegular { get; set; }
        public int? ServiceTypeInfrastructure { get; set; }
        public int? ServiceTypeCustom { get; set; }
        public int? ServiceTypeTermination { get; set; }
        public int? ServiceTypeReimbursement { get; set; }
        public string HajjAct { get; set; }
        public string PersLoanAct { get; set; }
        public string OtherAct1 { get; set; }
        public string OtherAct2 { get; set; }
        public string OtherAct3 { get; set; }
        public string OtherAct4 { get; set; }
        public string OtherAct5 { get; set; }
        public string SerApproval1 { get; set; }
        public string SerApproval2 { get; set; }
        public string SerApproval3 { get; set; }
        public string SerApproval4 { get; set; }
        public string SerApproval5 { get; set; }
        public string Active { get; set; }
        public long? CrupId { get; set; }
        public string Userid { get; set; }
        public DateTime? Entrydate { get; set; }
        public DateTime? Entrytime { get; set; }
        public DateTime? Updttime { get; set; }
        public DateTime? UploadDate { get; set; }
        public string Uploadby { get; set; }
        public DateTime? SyncDate { get; set; }
        public string Syncby { get; set; }
        public int? SynId { get; set; }
    }
}
