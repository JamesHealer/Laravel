using System;
using System.Collections.Generic;

#nullable disable

namespace API.Models
{
    public partial class Location
    {
        public int LocationId { get; set; }
        public int? TenentId { get; set; }
        public string LocationName { get; set; }
        public string LocationNameArabic { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? UserId { get; set; }
        public bool? IsActive { get; set; }
    }
}
