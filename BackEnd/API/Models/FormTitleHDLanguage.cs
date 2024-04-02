using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class FormTitleHDLanguage
    {       
       
        [Key]
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
        public ICollection<FormTitleDTLanguage> FormTitleDTLanguage { get; set; }
    }
}