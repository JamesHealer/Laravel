using System;
using System.Collections.Generic;

#nullable disable

namespace API.Models
{
    public partial class WebPageUrl
    {
        public int WebPageUrlId { get; set; }
        public int? WebPageId { get; set; }
        public string Url { get; set; }
    }
}
