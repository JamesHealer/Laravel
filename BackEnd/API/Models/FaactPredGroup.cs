using System;
using System.Collections.Generic;

#nullable disable

namespace API.Models
{
    public partial class FaactPredGroup
    {
        public int TenentId { get; set; }
        public int LocationId { get; set; }
        public string ActPredGroupId { get; set; }
        public string Description1 { get; set; }
        public string Description2 { get; set; }
        public string Description3 { get; set; }
        public string GroupUnder { get; set; }
        public string Glsl { get; set; }
        public int? InternalGroupId { get; set; }
        public int? GroupType { get; set; }
        public int? GroupSubType { get; set; }
        public string GroupNatureType { get; set; }
        public string LeftRight { get; set; }
        public string DefaultCc { get; set; }
        public int? DisplayOrder { get; set; }
        public string Active { get; set; }
        public long? CrupId { get; set; }
        public string Cuserid { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedById { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedById { get; set; }
    }
}
