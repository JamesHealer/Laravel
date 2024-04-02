using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class SelectApprovalRoleDto
    {
        public int RefId { get; set; }
        public string RefSubType { get; set; }
        public string RefName1 { get; set; }
        public string RefName2{ get; set; }
    }

}
