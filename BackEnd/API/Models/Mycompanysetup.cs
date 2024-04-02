using System;
using System.Collections.Generic;

#nullable disable

namespace API.Models
{
    public partial class Mycompanysetup
    {
        public int TenentId { get; set; }
        public int? TenantGroupId { get; set; }
        public string Physicallocid { get; set; }
        public string Compname1 { get; set; }
        public string Compname2 { get; set; }
        public string Compname3 { get; set; }
        public int Countryid { get; set; }
        public string Addr1 { get; set; }
        public string Addr2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Postalcode { get; set; }
        public string Zipcode { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string Arabic { get; set; }
        public decimal Decimalcurrency { get; set; }
        public string Reportdefault { get; set; }
        public string Reportdirectory { get; set; }
        public string Datadirectory { get; set; }
        public string Backupdirectory { get; set; }
        public string Executabledirectory { get; set; }
        public string Invdatabasename { get; set; }
        public string Actdatabasename { get; set; }
        public string Language1 { get; set; }
        public string Language2 { get; set; }
        public string Language3 { get; set; }
        public string Userid { get; set; }
        public DateTime Entrydate { get; set; }
        public DateTime Entrytime { get; set; }
        public DateTime Updttime { get; set; }
        public int? RecRunningSrl { get; set; }
        public long? CrupId { get; set; }
        public int? Companyid { get; set; }
        public string Compname { get; set; }
        public string Compnameo { get; set; }
        public string Compnamech { get; set; }
        public int? Approved { get; set; }
        public int? Companytype { get; set; }
        public bool? StockTaking { get; set; }
        public string Sysname { get; set; }
        public string PeriodId { get; set; }
        public string PeriodStartDate { get; set; }
        public string PeriodEndDate { get; set; }
        public decimal? SalePrice1 { get; set; }
        public decimal? SalePrice2 { get; set; }
        public decimal? SalePrice3 { get; set; }
        public decimal? Msrp { get; set; }
        public string LogotoDisplay { get; set; }
        public string LogotoPrint { get; set; }
        public string Logo3 { get; set; }
        public bool? Activetenent { get; set; }
        public DateTime? Tenentdate { get; set; }
    }
}
