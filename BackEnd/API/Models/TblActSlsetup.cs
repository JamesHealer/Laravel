using System;
using System.Collections.Generic;

#nullable disable

namespace API.Models
{
    public partial class TblActSlsetup
    {
        public int TenentId { get; set; }
        public int LocationId { get; set; }
        public int Transid { get; set; }
        public int Transsubid { get; set; }
        public int? Module { get; set; }
        public int? DeliveryLocation { get; set; }
        public int? CompniId { get; set; }
        public int? LastClosePeriod { get; set; }
        public int? CurrentPeriod { get; set; }
        public int? PaymentDays { get; set; }
        public int? ReminderDays { get; set; }
        public int? AcceptWarantee { get; set; }
        public bool? DescWithWarantee { get; set; }
        public bool? DescWithSerial { get; set; }
        public bool? DescWithColor { get; set; }
        public bool? AllowMinusQty { get; set; }
        public string HeaderLine { get; set; }
        public string TagLine { get; set; }
        public string BottomTagLine { get; set; }
        public string PaymentDetails { get; set; }
        public string Tcquotation { get; set; }
        public string IntroLetter { get; set; }
        public int? Countryid { get; set; }
        public int? SalesAdminId { get; set; }
    }
}
