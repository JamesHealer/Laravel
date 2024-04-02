using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class LoginDto
    {
        public string username { get; set; }
        public string password { get; set; }
        public int tenentId { get; set; }
        public int TenantId { get; set; }
        public int LocationId { get; set; }
        public int UserId { get; set; }
        public string Token { get; set; }
        public int RoleId { get; set; }
        public string PeriodCode { get; set; }
        public string PrevPeriodCode { get; set; }
        public string NextPeriodCode { get; set; }
    }
}
