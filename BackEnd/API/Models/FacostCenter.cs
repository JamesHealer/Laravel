using System;
using System.Collections.Generic;

#nullable disable

namespace API.Models
{
    public partial class FacostCenter
    {
        public int TenentId { get; set; }
        public int LocationId { get; set; }
        public string CostCenterId { get; set; }
        public string CostCenterName1 { get; set; }
        public string CostCenterName2 { get; set; }
        public string CostCenterName3 { get; set; }
        public int DepartmentId { get; set; }
        public int ProjectId { get; set; }
        public string GlcontrolAccountId { get; set; }
        public string SlrevenueAccountId { get; set; }
        public string SlexpenseAccountId { get; set; }
        public string SlstockInHandAccountId { get; set; }
        public string GroupUnder { get; set; }
        public int? DisplayOrder { get; set; }
        public string Active { get; set; }
        public long? CrupId { get; set; }
        public string Cuserid { get; set; }
    }
}
