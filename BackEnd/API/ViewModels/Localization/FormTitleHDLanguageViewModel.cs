using System;
using System.Collections.Generic;

namespace API.ViewModels.Localization
{
    public class FormTitleHDLanguageViewModel
    {
        public Guid Id { get; set; }
        public int TenentId { get; set; }
        public int Language { get; set; }        
        public string FormId { get; set; }
        public string FormName { get; set; }
        public string HeaderName { get; set; }
        public string SubHeader { get; set; }
        public string Navigation { get; set; }
        public string Remarks { get; set; }
        public string Status { get; set; }
        public int? OrderBy { get; set; }
        public ICollection <FormTitleDTLanguageViewModel> FormTitleDTLanguage { get; set; }
    
}
}