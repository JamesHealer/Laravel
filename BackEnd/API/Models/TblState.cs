using System;
using System.Collections.Generic;

#nullable disable

namespace API.Models
{
    public partial class TblState
    {
        public int Countryid { get; set; }
        public int StateId { get; set; }
        public string Myname1 { get; set; }
        public string Myname2 { get; set; }
        public string Myname3 { get; set; }
        public string Statezipcode { get; set; }
        public string Active1 { get; set; }
        public string Active2 { get; set; }
        public long? CrupId { get; set; }
        public DateTime? UploadDate { get; set; }
        public string Uploadby { get; set; }
        public DateTime? SyncDate { get; set; }
        public string Syncby { get; set; }
        public int? SynId { get; set; }
    }
}
