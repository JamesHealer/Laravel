using System;
using System.Collections.Generic;

#nullable disable

namespace API.Models
{
    public partial class UserPage
    {
        public int UserWebPageId { get; set; }
        public int? UserId { get; set; }
        public int? WebPageId { get; set; }
        public bool? HasInsert { get; set; }
        public bool? HasUpdate { get; set; }
        public bool? HasDelete { get; set; }
    }
}
