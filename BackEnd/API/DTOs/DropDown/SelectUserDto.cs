using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs.DropDown
{
    public class SelectUserDto
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int locationId { get; set; }
        public int roleId { get; set; }
        public string LoginId { get; set; }
        public string Password { get; set; }
    }
}
