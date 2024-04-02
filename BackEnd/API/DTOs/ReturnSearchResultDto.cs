using System;

namespace API.DTOs
{
    public class ReturnSearchResultDto
    {     

        public int TenentId { get; set; }
        public int LocationId { get; set; }
        public string Pfid { get; set; }
        public string EmpCidNum { get; set; }
        public string EmployeeId { get; set; }
        public string ArabicName { get; set; }
        public string EnglishName { get; set; }
        public short? EmpGender { get; set; }
        public DateTime? JoinedDate { get; set; }
        public string MobileNumber { get; set; }
        public string? EmpMaritalStatus { get; set; }
        public string NationName { get; set; }
        public string ContractType { get; set; }
        public string Next2KinName { get; set; }
        public string Next2KinMobNumber { get; set; }
        public decimal SubscriptionAmount { get; set; }
        public decimal SubscriptionPaid { get; set; }
        public decimal LastSubscriptionPaid { get; set; }
        public decimal SubscriptionDueAmount { get; set; }
        public string SubscriptionStatus { get; set; }
        public DateTime? TerminationDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string EmployeeStatus { get; set; }
        public bool? IsKUEmployee { get; set; }
        public bool? IsOnSickLeave { get; set; }
        public bool? IsMemberOfFund { get; set; }
        public int? CountryId { get; set; }
        public string? CountryNameEnglish { get; set; }
        public string? CountryNameArabic { get; set; }
        // To send response type and error message.
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
        public decimal  Salary { get; set; }
    }
}
