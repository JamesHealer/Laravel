using System;

namespace API.DTOs
{
    public class ReturnApprovalDetailsDto
    {
      
        public string? ServiceType { get; set; }
        public string? ServiceSubType { get; set; }        
        public decimal? Totamt { get; set; }
        public string? EnglishName { get; set; }
        public string? ArabicName { get; set; }
    }
}
