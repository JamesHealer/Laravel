using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace API.Models
{
    public partial class FormTitleHd
    {   
        public int TenentId { get; set; }
        public int Language { get; set; }
         [Key]
        public string FormId { get; set; }
        public string FormName { get; set; }
        public string HeaderName { get; set; }
        public string SubHeaderName { get; set; }
        public string Navigation { get; set; }
        public string Remarks { get; set; }
        public string Status { get; set; }
        public ICollection<FormTitleDt> FormTitleDt { get; set; }
    }
}
