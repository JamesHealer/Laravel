using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs.DropDown
{
    public class SelectMinInstallmentDto
    {
        public int ServiceId { get; set; }
        public int MinInstallment { get; set; }
    }
}
