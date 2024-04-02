using System;
using System.Collections.Generic;

#nullable disable

namespace API.Models
{
    public partial class DrCrTemplate
    {
        public int TemplateId { get; set; }
        public string TemplateName { get; set; }
        public string ArabicTemplateName { get; set; }
        public bool? IsDrNote { get; set; }
        public int? AccountId { get; set; }
        public string Remarks { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
