using System;

namespace API
{
    public class CashierInformationDto
    {
        public decimal? PayPer1 { get; set; }
        public string? DraftNumber1 { get; set; }
        public DateTime? DraftDate1 { get; set; }
        public decimal? DraftAmount1 { get; set; }
        public string? BankAccount1 { get; set; }
        public DateTime? DeliveryDate1 { get; set; }
        public string? ReceivedBy1 { get; set; }
        public string? DeliveredBy1 { get; set; }

        public decimal? PayPer2 { get; set; }
        public string? DraftNumber2 { get; set; }
        public DateTime? DraftDate2 { get; set; }
        public decimal? DraftAmount2 { get; set; }
        public string? BankAccount2 { get; set; }
        public DateTime? DeliveryDate2 { get; set; }
        public string? ReceivedBy2 { get; set; }
        public string? DeliveredBy2 { get; set; }
    }
}
