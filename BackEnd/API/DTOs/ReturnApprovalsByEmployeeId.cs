using System;

namespace API.DTOs
{
    public class ReturnApprovalsByEmployeeId
    {
        public int? TenentId { get; set; }
        public int? LocationId { get; set; }
        public string? ServiceType { get; set; }
        public string? ServiceSubType { get; set; }
        public long? TransId { get; set; }
        public string? Status { get; set; }
        public string? ApprovalRemarks { get; set; }
        public bool? Active { get; set; }
    }
}
