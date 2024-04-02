using System;
using System.Collections.Generic;

#nullable disable

namespace API.Models
{
    public partial class CostCenter
    {
        public int TenentId { get; set; }
        public int LocationId { get; set; }
        public int CostCenterId { get; set; }
        public int? CostCenterNumber { get; set; }
        public string CostCenterName { get; set; }
        public string ArabicCostCenterName { get; set; }
        public string OtherCostCenterName { get; set; }
        public bool? IsActive { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public long? Crupid { get; set; }
    }
}
