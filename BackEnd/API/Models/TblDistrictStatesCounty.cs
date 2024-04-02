using System;
using System.Collections.Generic;

#nullable disable

namespace API.Models
{
    public partial class TblDistrictStatesCounty
    {
        public int TenantId { get; set; }
        public int Countryid { get; set; }
        public int StateId { get; set; }
        public int DistrictId { get; set; }
        public int? PinCode { get; set; }
        public string DistrictEnglish { get; set; }
        public string DistrictArabic { get; set; }
        public string DistrictOther { get; set; }
        public string LandLine { get; set; }
        public string Active1 { get; set; }
        public string Active2 { get; set; }
        public long? CrupId { get; set; }
        public string AssignedRoute { get; set; }
        public string Shortcode { get; set; }
        public string Zone { get; set; }
        public DateTime? UploadDate { get; set; }
        public string Uploadby { get; set; }
        public DateTime? SyncDate { get; set; }
        public string Syncby { get; set; }
        public int? SynId { get; set; }
    }
}
