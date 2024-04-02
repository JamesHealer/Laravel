using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class UpdatePasswordDto
    {
        public int UserId { get; set; }
        public string oldPassword { get; set; }
        public string newPassword { get; set; }
    }
}
