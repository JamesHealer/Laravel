using System;
using System.Collections.Generic;

#nullable disable

namespace API.Models
{
    public partial class TblCountry
    {
        public int TenentId { get; set; }
        public int Countryid { get; set; }
        public string Region1 { get; set; }
        public string Couname1 { get; set; }
        public string Couname2 { get; set; }
        public string Couname3 { get; set; }
        public string Capital { get; set; }
        public string Nationality1 { get; set; }
        public string Nationality2 { get; set; }
        public string Nationality3 { get; set; }
        public string Currencyname1 { get; set; }
        public string Currencyname2 { get; set; }
        public string Currencyname3 { get; set; }
        public decimal Currentconvrate { get; set; }
        public string Currencyshortname1 { get; set; }
        public string Currencyshortname2 { get; set; }
        public string Currencyshortname3 { get; set; }
        public string CountryType { get; set; }
        public string CountryTsubType { get; set; }
        public string Sovereignty { get; set; }
        public string Iso4217curCode { get; set; }
        public string Iso4217curName { get; set; }
        public string ItuttelephoneCode { get; set; }
        public int? FaxLength { get; set; }
        public int? TelLength { get; set; }
        public string Iso316612letterCode { get; set; }
        public string Iso316613letterCode { get; set; }
        public string Iso31661number { get; set; }
        public string IanacountryCodeTld { get; set; }
        public string Zone1 { get; set; }
        public string Zone2 { get; set; }
        public string Zone3 { get; set; }
        public string Zone4 { get; set; }
        public string Zone5 { get; set; }
        public string Zone6 { get; set; }
        public string Zone7 { get; set; }
        public string Active { get; set; }
        public long? CrupId { get; set; }
        public DateTime? UploadDate { get; set; }
        public string Uploadby { get; set; }
        public DateTime? SyncDate { get; set; }
        public string Syncby { get; set; }
        public int? SynId { get; set; }
    }
}
