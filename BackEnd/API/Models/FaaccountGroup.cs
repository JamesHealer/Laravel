using System;
using System.Collections.Generic;

#nullable disable

namespace API.Models
{
    public partial class FaaccountGroup
    {
        public int TenentId { get; set; }
        public int LocationId { get; set; }
        public string ActGroupId { get; set; }
        public string Glsl { get; set; }
        public int InternalGroupId { get; set; }
        public string DefaultCc { get; set; }
        public string GroupUnder { get; set; }
        public int GroupType { get; set; }
        public int GroupSubType { get; set; }
        public string GroupNatureType { get; set; }
        public string GroupDesc1 { get; set; }
        public string GroupDesc2 { get; set; }
        public string GroupDesc3 { get; set; }
        public int DisplayOrder { get; set; }
        public int EffectGrossProfit { get; set; }
        public bool? IsDefault { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedById { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int UpdatedById { get; set; }
        public string Active { get; set; }
        public long? CrupId { get; set; }
        public string Cuserid { get; set; }
    }
}
