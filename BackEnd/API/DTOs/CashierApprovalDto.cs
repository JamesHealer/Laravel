using System;

namespace API.DTOs
{
    public class CashierApprovalDto
    {
        public int? TenentId { get; set; }
        public int? LocationId { get; set; }
        public string? Pfid { get; set; }
        public string? EmpCidNum { get; set; }
        public string? EmployeeId { get; set; }
        public string? ArabicName { get; set; }
        public string? EnglishName { get; set; }
        public string? MobileNumber { get; set; }
        public string? PeriodCode { get; set; }
        public long? TransId { get; set; }
        public string? ServiceName { get; set; }
        public decimal? DraftAmount1 { get; set; }
        public decimal? DraftAmount2 { get; set; }
        public DateTime? DraftDate1 { get; set; }
        public DateTime? DraftDate2 { get; set; }
        public decimal? TotalAmount { get; set; }
        public DateTime? ReceivedDate { get; set; }
        public string? ReceivedBy1 { get; set; }
        public int? DraftNumber1 { get; set; }
        public int? DraftNumber2 { get; set; }
        public string? BankAccount1 { get; set; }
        public string? BankAccount2 { get; set; }
        public DateTime? DeliveryDate1 { get; set; }
        public string? DeliveredBy1 { get; set; }
        public DateTime? DeliveryDate2 { get; set; }
        public string? DeliveredBy2 { get; set; }
        public DateTime? ReceivedDate1 { get; set; }
        public DateTime? ReceivedDate2 { get; set; }
        public long? CrupId  { get; set; }
        public DateTime? EntryDate  { get; set; }
        public string? UserId { get; set; }
        public int? AccountantID { get; set; }
        public string? BenefeciaryName { get; set; }
        public string? ChequeNumber { get; set; }
        public DateTime? ChequeDate { get; set; }
        public decimal? ChequeAmount { get; set; }
        public DateTime? CollectedDate { get; set; }
        public string? CollectedBy { get; set; }
        public string? Relationship { get; set; }
        public string? CollectedPersonCID { get; set; }
        public bool IsDraftCreated { get; set; }
    }
}
