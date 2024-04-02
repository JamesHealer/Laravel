using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs.LocalizationDto
{
    public class FormTitleHDLanguageDto
    {
        public Guid Id{ get; set; }
        public int TenentId{ get; set; }
        public int Language { get; set; }  
        public string FormID { get; set; }   
        public string FormName { get; set; }
        public string HeaderName { get; set; }
        public string SubHeaderName { get; set; }
        public string Navigation { get; set; }
        public string Remarks { get; set; }
        public string Status { get; set; }
        public int? OrderBy { get; set; }
        public ICollection<FormTitleDTLanguageDto> FormTitleDTLanguage { get; set; }
    }

    public class FormTitleHDLanguageDtoObj
    {
        public int TotalRecords { get; set; }
        public List<FormTitleHDLanguageDto> FormTitleHDLanguageDto { get; set; } 
    }
}