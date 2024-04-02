using Microsoft.TeamFoundation.Build.WebApi;
using System.Collections.Generic;

namespace API.Models
{
    public class ImportEmployeeServiceMDL
    {
        public int Id { get; set; }
        public int FinancialYear { get; set; }
        public string UploadType { get; set; }
        public string PeriodCode { get; set; }
        public int YearMonth { get; set; }
        public int IsException { get; set; }
        public string EmployeeId { get; set; }
        public string EnglishName { get; set; }
        public string ArabicName { get; set; }
        public string Reference { get; set; }
        public decimal Amount { get; set; }
        public decimal Previous_Amount { get; set; }
    }
    public class EmployeeServiceTransList
    {
        public List<ImportEmployeeServiceMDL> importEmployeeServiceMDLs { get; set; }
        public int tenantId { get; set; }
        public string loginUserName { get; set; }
    }

    public class CheckMonthlyDataMDL
    {
        public string YearMonth { get; set; }
        public int EmployeeId { get; set; }
        public List<string> Exceptions { get; set; }
        public List<string> Warnings { get; set; }
    }
}
