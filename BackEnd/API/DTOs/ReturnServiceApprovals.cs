using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class ReturnServiceApprovals
    {
        public int? MyTransId { get; set; }
        public int? EmployeeId { get; set; }
        public string? EnglishName { get; set; }
        public string? ArabicName { get; set; }
        public string? Services { get; set; }
        public string? Source { get; set; }
        public int? TotalInstallments { get; set; }
        public decimal? Amount { get; set; }
        public string? Discounted { get; set; }
        public DateTime? InstallmentBeginDate { get; set; }
        public string UntilMonth { get; set; }
        public string? ServiceType { get; set; }
        public string? ServiceSubType { get; set; }
        public decimal? TotalAmount { get; set; }

    }
}
