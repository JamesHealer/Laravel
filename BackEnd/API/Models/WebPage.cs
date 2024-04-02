using System;
using System.Collections.Generic;

#nullable disable

namespace API.Models
{
    public partial class WebPage
    {
        public int WebPageId { get; set; }
        public int? ParentId { get; set; }
        public bool? IsVisible { get; set; }
        public string PageIcon { get; set; }
        public int? PageOrder { get; set; }
        public string PageTitle { get; set; }
        public string ControllerName { get; set; }
        public string ViewName { get; set; }
        public string Description { get; set; }
        public string ArabicPageTitle { get; set; }
    }
}
