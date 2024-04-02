using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class FunctionUserDto
    {
        public int TenentID { get; set; }
        public int LOCATION_ID { get; set; }
        public int USER_ID { get; set; }
        public int ROLE_ID { get; set; }
        public int MENU_ID { get; set; }
        public int MASTER_ID { get; set; }
        public int MODULE_ID { get; set; }
        public string MENU_TYPE { get; set; }
        public string? MENU_NAMEEnglish { get; set; }
        public string? MENU_NAMEArabic { get; set; }
        public string? SMALLTEXT { get; set; }
        public string FULL_NAME { get; set; }
        public string? LOGIN_ID { get; set; }
        public string? PASSWORD { get; set; }
        public int? USER_TYPE { get; set; }
        public int? ACTIVE_FLAG { get; set; }
        public DateTime? ACTIVETILLDATE { get; set; }
        public string? LINK { get; set; }
        public string? Urloption { get; set; }
        public string? URLREWRITE { get; set; }
        public string? MENU_LOCATION { get; set; }
        public decimal? MENU_ORDER { get; set; }
        public string? DOC_PARENT { get; set; }
        public int? ADDFLAGE { get; set; }
        public int? EDITFLAGE { get; set; }
        public int? DELFLAGE { get; set; }
        public int? PRINTFLAGE { get; set; }
        public int? AMIGLOBALE { get; set; }
        public int? MYPERSONAL { get; set; }
        public string? ICONPATH { get; set; }
        public int? SP1 { get; set; }
        public int? SP2 { get; set; }
        public int? SP3 { get; set; }
        public int? SP4 { get; set; }
        public int? SP5 { get; set; }
        public string? SP1Name { get; set; }
        public string? SP2Name { get; set; }
        public string? SP3Name { get; set; }
        public string? SP4Name { get; set; }
        public string? SP5Name { get; set; }
        public DateTime? UploadDate { get; set; }
        public string? Uploadby { get; set; }
        public DateTime? SyncDate { get; set; }
        public string? Syncby { get; set; }
        public int? SynID { get; set; }
        public int CRUP_ID { get; set; }
        public int? Menu_Level { get; set; }
    }
}
