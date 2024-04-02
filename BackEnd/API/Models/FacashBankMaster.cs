using System;
using System.Collections.Generic;

#nullable disable

namespace API.Models
{
    public partial class FacashBankMaster
    {
        public int TenentId { get; set; }
        public int LocationId { get; set; }
        public int AcountId { get; set; }
        public string PreDefinedAccount { get; set; }
        public int? ActGroupId { get; set; }
        public string SortingOrder { get; set; }
        public string AccountName1 { get; set; }
        public string AccountName2 { get; set; }
        public string AccountName3 { get; set; }
        public int? ActType { get; set; }
        public int? AnalysisType { get; set; }
        public string VoucherNo { get; set; }
        public DateTime? VoucherDate { get; set; }
        public string VoucherMiti { get; set; }
        public int? LedgerId { get; set; }
        public string CurrentBalance { get; set; }
        public string ChequeNo { get; set; }
        public DateTime? ChequeDate { get; set; }
        public int? CurrencyId { get; set; }
        public string Rate { get; set; }
        public string Remarks { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedById { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedById { get; set; }
        public bool? IsApproved { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public int? ApprovedBy { get; set; }
        public int? DocId { get; set; }
        public int? Fyid { get; set; }
        public int? BranchId { get; set; }
        public bool? IsDeleted { get; set; }
        public string ChequeMiti { get; set; }
    }
}
