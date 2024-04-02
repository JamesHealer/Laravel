using System;
using System.Collections.Generic;

#nullable disable

namespace API.Models
{
    public partial class Faslaccount
    {
        public int TenentId { get; set; }
        public int LocationId { get; set; }
        public string GlaccountId { get; set; }
        public string SlaccountId { get; set; }
        public bool? Header { get; set; }
        public string MasterAccountId { get; set; }
        public string PredAccountId { get; set; }
        public string ConsolidationType { get; set; }
        public string Glsltype { get; set; }
        public string ActGroupId { get; set; }
        public int InternalGroupId { get; set; }
        public string SlaccountName1 { get; set; }
        public string SlaccountName2 { get; set; }
        public string SlaccountName3 { get; set; }
        public int ActType { get; set; }
        public int ActSubType { get; set; }
        public int AnalysisType { get; set; }
        public string DefaultCc { get; set; }
        public int Opamount { get; set; }
        public int OpdrCr { get; set; }
        public long OpperiodCode { get; set; }
        public string Reference { get; set; }
        public string Remarks { get; set; }
        public int Compid { get; set; }
        public int ContactMyId { get; set; }
        public string Switch1 { get; set; }
        public string Switch2 { get; set; }
        public string Switch3 { get; set; }
        public string Active { get; set; }
        public DateTime? SyncDate { get; set; }
        public long? CrupId { get; set; }
    }
}
