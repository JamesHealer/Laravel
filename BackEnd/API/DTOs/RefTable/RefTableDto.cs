using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs.RefTable
{
    public class RefTableDtoListObj
    {
        public int TotalRecords { get; set; }
        public List<RefTableDto> RefTableDto { get; set; }
        
    }
    public class RefTableDto
    {
        public int TenentId { get; set; }        
        public int Refid { get; set; }
        public string Reftype { get; set; }
        public string Refsubtype { get; set; }
        public string? Shortname { get; set; }
        public string? Refname1 { get; set; }
        public string Refname2 { get; set; }
        public string Refname3 { get; set; }
        public string? Switch1 { get; set; }
        public string? Switch2 { get; set; }
        public string? Switch3 { get; set; }
        public int? Switch4 { get; set; }
        public string? Remarks { get; set; }
        public string? Active { get; set; }
        public Int64? CrupId { get; set; }
        public string? Infrastructure { get; set; }
        public string? RefImage { get; set; }
        public DateTime? UploadDate { get; set; }
        public string? Uploadby { get; set; }
        public DateTime? SyncDate { get; set; }
        public string? Syncby { get; set; }
        public int? SynId { get; set; }
    }
}
