using System;

namespace API.Models
{
    public class TokenAuthorizationModel
    {
        public int TokenId { get; set; }
        public int TokenValidDays { get; set; }
        public bool Isvalid { get; set; }
        public string TokenNo { get; set; }
        public string UserLoginId { get; set; }
        public DateTime TokenCreatedDate { get; set; }
        public DateTime TokenExpireDate { get; set; }
        public DateTime LastUsingTime { get; set; }
    }
}
