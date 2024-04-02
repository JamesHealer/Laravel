using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class CrupMstDto
    {
        public int TenantId { get; set; }
        public int LocationId { get; set; }
        public Int64 CrupId { get; set; }
        public int? MySerial { get; set; }
        public int? MenuId { get; set; }
        public string Physicallocid { get; set; }
        public string ActivityNote { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDt { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDt { get; set; }
    }
}
