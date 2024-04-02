using System;
using System.Collections.Generic;

#nullable disable

namespace API.Models
{
    public partial class TblAccountMst
    {
        public int TenentId { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneOffice { get; set; }
        public string Phone { get; set; }
        public string PhoneFax { get; set; }
        public string PhoneAlternate { get; set; }
        public string Website { get; set; }
        public string Email1 { get; set; }
        public string Email2 { get; set; }
        public string AnnualRevenue { get; set; }
        public string Employee { get; set; }
        public int? IndustryId { get; set; }
        public string Ownership { get; set; }
        public int? AccountType { get; set; }
        public string TickerSymbol { get; set; }
        public string Rating { get; set; }
        public string SicCode { get; set; }
        public string BillingAddressStreet { get; set; }
        public string BillingAddressCity { get; set; }
        public string BillingAddressState { get; set; }
        public string BillingAddressPostalcode { get; set; }
        public string BillingAddressCountry { get; set; }
        public string ShippingAddressStreet { get; set; }
        public string ShippingAddressCity { get; set; }
        public string ShippingAddressState { get; set; }
        public string ShippingAddressPostalcode { get; set; }
        public string ShippingAddressCountry { get; set; }
        public string ParentName { get; set; }
        public DateTime? DateEntered { get; set; }
        public DateTime? DateModified { get; set; }
        public string Description { get; set; }
        public int? TeamName { get; set; }
        public string AssignedToName { get; set; }
        public int? CreatedBy { get; set; }
        public int? ModifiedBy { get; set; }
        public string ContactName { get; set; }
        public bool? Active { get; set; }
        public bool? Deleted { get; set; }
        public long? CrupId { get; set; }
    }
}
