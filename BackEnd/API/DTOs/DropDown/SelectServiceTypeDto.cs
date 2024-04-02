using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs.DropDown
{
    public class SelectServiceTypeDto
    {
        public int RefId { get; set; }
        public string? Shortname { get; set; }
        public string? MenuId { get; set; }   
    }
}
