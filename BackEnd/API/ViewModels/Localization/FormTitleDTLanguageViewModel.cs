using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.ViewModels.Localization
{
    public class FormTitleDTLanguageViewModel
    {
        public int TenentId { get; set; }
        public Guid FormTitleHDLanguageId { get; set; }
        public int Language { get; set; }       
        public string LabelId { get; set; }
        public string Title { get; set; }
        public string ArabicTitle { get; set; }
        public string Rl { get; set; }
        public string Attiribute { get; set; }
        public string Remarks { get; set; }
        public string Status { get; set; }
        public int? OrderBy { get; set; }
    }
}