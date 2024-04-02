using System;
using System.Collections.Generic;

#nullable disable

namespace API.Models
{
    public partial class FaactIntegSetup
    {
        public int TenentId { get; set; }
        public int LocationId { get; set; }
        public string ActIntegrationId { get; set; }
        public string Mysysname { get; set; }
        public int Transid { get; set; }
        public int Transsubid { get; set; }
        public string AccountId { get; set; }
        public string GroupId { get; set; }
        public string FromItemId { get; set; }
        public string ToItemId { get; set; }
        public int FromCatSubId { get; set; }
        public int ToCatSubId { get; set; }
        public string DefaultCc { get; set; }
        public string IntegrationDesc1 { get; set; }
        public string IntegrationDesc2 { get; set; }
        public string IntegrationDesc3 { get; set; }
        public bool? Consolidation { get; set; }
        public string ConsolidationType { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedById { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int UpdatedById { get; set; }
        public string Active { get; set; }
        public long? CrupId { get; set; }
    }
}
