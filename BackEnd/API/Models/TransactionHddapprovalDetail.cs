using System;
using System.Collections.Generic;

#nullable disable

namespace API.Models
{
    public partial class TransactionHddapprovalDetail
    {
        public int TenentId { get; set; }
        public long Mytransid { get; set; }
        public int LocationId { get; set; }
        public int SerApprovalId { get; set; }
        public string SerApproval { get; set; }
        public int? EmployeeId { get; set; }
        public int? ServiceType { get; set; }
        public int? ServiceSubType { get; set; }
        public int? ServiceId { get; set; }
        public int? MasterServiceId { get; set; }
        public DateTime? ApprovalDate { get; set; }
        public int? RejectionType { get; set; }
        public string RejectionRemarks { get; set; }
        public int? AttachId { get; set; }
        public string Status { get; set; }
        public long? CrupId { get; set; }
        public string Userid { get; set; }
        public bool? Active { get; set; }
        public DateTime? Entrydate { get; set; }
        public DateTime? Entrytime { get; set; }
        public DateTime? Updttime { get; set; }
        public string ApprovalRemarks { get; set; }
        public int? mySeq { get; set; }
        public long? DisplayPERIOD_CODE { get; set; }
    }
}
