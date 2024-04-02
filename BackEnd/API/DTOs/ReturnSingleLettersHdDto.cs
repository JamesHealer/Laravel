using System;
using System.Collections.Generic;

namespace API.DTOs
{
    public class ReturnSingleLettersHdDto
    {
        public int TenentId { get; set; }
        public long Mytransid { get; set; }
        public int LetterType { get; set; }
        public int? SenderReceiverParty { get; set; }
        public int? FilledAt { get; set; }
        public int? LocationId { get; set; }
        public int? EmployeeId { get; set; }
        public DateTime? LetterDated { get; set; }
        public string Representative { get; set; }
        public DateTime? ReceivedSentDate { get; set; }
        public string SearchTag { get; set; }
        public string Description { get; set; }
        public int? Dmsid { get; set; }
        public string Status { get; set; }
        public long? CrupId { get; set; }
        public string Userid { get; set; }
        public bool? Active { get; set; }
        public DateTime? Entrydate { get; set; }
        public DateTime? Entrytime { get; set; }
        public DateTime? Updttime { get; set; }
        public List<TransactionHDDMSDto>  TransactionHDDMSDtos { get; set; }
        public string UserDocumentNo { get; set; }
        public string approvedBy { get; set; }
    }
}
