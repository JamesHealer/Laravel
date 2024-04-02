using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;

namespace API.Models
{
    public class FormTitleHDLanguagedto
    {
        [Key]
        public Guid Id { get; set; }
        public int TenentId { get; set; }
        public int Language { get; set; }
        public string FormID { get; set; }
        public string FormName { get; set; }
        public string HeaderName { get; set; }
        public string SubHeaderName { get; set; }
        public string Navigation { get; set; }
        public string Remarks { get; set; }
        public string Status { get; set; }
        public int? OrderBy { get; set; }
        public ICollection<FormTitleDTLanguagedto> FormTitleDTLanguagedto { get; set; }
    }
}
