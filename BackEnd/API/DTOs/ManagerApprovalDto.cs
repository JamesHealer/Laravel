using System;

namespace API.DTOs
{
    public class ManagerApprovalDto
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
        public string? DraftNumber1 { get; set; }
        public string? DraftNumber2 { get; set; }
        public string? BankAccount1 { get; set; }
        public string? BankAccount2 { get; set; }
        public DateTime? DeliveryDate1 { get; set; }
        public string? DeliveredBy1 { get; set; }
        public DateTime? DeliveryDate2 { get; set; }
        public string? DeliveredBy2 { get; set; }
        public DateTime? ReceivedDate1 { get; set; }
        public DateTime? ReceivedDate2 { get; set; }
        public int? TotalInstallments { get; set; }
        public string? Status { get; set; }
        public bool? Active { get; set; }
        public long? CrupId { get; set; }
    }
}
