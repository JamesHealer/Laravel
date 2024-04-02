using System;
using System.Collections.Generic;

#nullable disable

namespace API.Models
{
    public partial class Mapping
    {
        public int TenentId { get; set; }
        public int LocationId { get; set; }
        public int MappingId { get; set; }
        public string EnglishDescription { get; set; }
        public string ArabicDescription { get; set; }
        public string OtherDescription { get; set; }
        public int AccountId { get; set; }
        public long? Crupid { get; set; }
    }
}
