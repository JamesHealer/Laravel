using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class ReturnTransactionHdDto
    {
        public long MYTRANSID { get; set; }
        public int? EmployeeId { get; set; }
        public string PFId { get; set; }
        public string CID { get; set; }
        public string EnglishName { get; set; }
        public string ArabicName { get; set; }
        public string? ServiceType { get; set; }
        public string? ServiceSubType { get; set; }
        public decimal? Installment { get; set; }
        public decimal? Amount { get; set; }
        public decimal? Paid { get; set; }
        public string PayDate { get; set; }
        public decimal? Discounted { get; set; }
    }
}
