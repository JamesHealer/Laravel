using System;
using System.Collections.Generic;

#nullable disable

namespace API.Models
{
    public partial class TblImportCoav2
    {
        public string FamilyName { get; set; }
        public string HeadName { get; set; }
        public string ArabicHeadName { get; set; }
        public string HeadCode { get; set; }
        public string SubHeadName { get; set; }
        public string ArabicSubHeadName { get; set; }
        public string SubHeadCode { get; set; }
        public string AccountName { get; set; }
        public string ArabicAccountName { get; set; }
        public string AccountNumber { get; set; }
        public string BankAccountNo { get; set; }
        public string AccountTypeName { get; set; }
        public int? TanentId { get; set; }
        public int? LocationId { get; set; }
        public int? UserId { get; set; }
        public DateTime? ActivityDateTime { get; set; }
        public string SubSubHeadCode { get; set; }
        public string SubSubHeadName { get; set; }
        public string SubSubHeadNameArabic { get; set; }
        public decimal? Amount { get; set; }
        public int? FamilyCode { get; set; }
        public int AccountId { get; set; }
    }
}
