using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class FUNCTION_MST
    {
        public int TenentID { get; set; }
        [Key]
        public int? MENU_ID { get; set; }
        public int? MASTER_ID { get; set; }
        public int? MODULE_ID { get; set; }
        public string? MENU_TYPE { get; set; }
        public string? MENU_NAMEEnglish { get; set; }
        public string? MENU_NAMEArabic { get; set; }
        public string? FULL_NAME { get; set; }
        public string? LINK { get; set; }
        public string? Urloption { get; set; }
        public string? URLREWRITE { get; set; }
        public string? MENU_LOCATION { get; set; }
        public decimal? MENU_ORDER { get; set; }
        public string? DOC_PARENT { get; set; }
        public Int64? CRUP_ID { get; set; }
        public int? ADDFLAGE { get; set; }
        public int? EDITFLAGE { get; set; }
        public int? DELFLAGE { get; set; }
        public int? PRINTFLAGE { get; set; }
        public int? AMIGLOBALE { get; set; }
        public int? MYPERSONAL { get; set; }
        public string? SMALLTEXT { get; set; }
        public DateTime? ACTIVETILLDATE { get; set; }
        public string? ICONPATH { get; set; }
        public string? COMMANLINE { get; set; }
        public int? ACTIVE_FLAG { get; set; }
        public string? METATITLE { get; set; }
        public string? METAKEYWORD { get; set; }
        public string? METADESCRIPTION { get; set; }
        public string? HEADERVISIBLEDATA { get; set; }
        public string? HEADERINVISIBLEDATA { get; set; }
        public string? FOOTERVISIBLEDATA { get; set; }
        public string? FOOTERINVISIBLEDATA { get; set; }
        public int? REFID { get; set; }
        public int? MYBUSID { get; set; }
        public int? LABLEFLAG { get; set; }
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
        public bool? ACTIVEMENU { get; set; }
        public DateTime? MENUDATE { get; set; }
        public int? Menu_Level { get; set; }
    }
}
