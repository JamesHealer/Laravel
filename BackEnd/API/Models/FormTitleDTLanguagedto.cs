using System.ComponentModel.DataAnnotations;
using System;

namespace API.Models
{
    public class FormTitleDTLanguagedto
    {
        [Key]
        public int Id { get; set; }
        public int TenentId { get; set; }
        public Guid FormTitleHDLanguageId { get; set; }
        public string FormID { get; set; }
        public int Language { get; set; }
        public string LabelId { get; set; }
        public string Title { get; set; }
        public string ArabicTitle { get; set; }
        public string RL { get; set; }
        public string Attiribute { get; set; }
        public string Remarks { get; set; }
        public string Status { get; set; }
        public int? OrderBy { get; set; }
    }
}
