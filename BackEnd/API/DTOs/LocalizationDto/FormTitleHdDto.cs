using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs.LocalizationDto
{
    public class FormTitleHdDto
    {
        public int TenentId { get; set; }
        public int Language { get; set; }        
        public string FormId { get; set; }
        public string FormName { get; set; }
        public string HeaderName { get; set; }
        public string SubHeader { get; set; }
        public string Navigation { get; set; }
        public string Remarks { get; set; }
        public string Status { get; set; }
        public ICollection<FormTitleDtDto> FormTitleDts { get; set; }
    }
}