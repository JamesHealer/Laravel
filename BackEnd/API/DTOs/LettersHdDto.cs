using Microsoft.AspNetCore.Http;
using System;

namespace API.DTOs
{
    public class LettersHdDto
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
        public string Username { get; set; }
        public string Subject { get; set; }
        public string MetaTags { get; set; }
        public string Remarks { get; set; }
        public int personalPhotoDocType { get; set; }
        public IFormFile personalPhotoDocument { get; set; }

        public int appplicationFileDocType { get; set; }
        public IFormFile appplicationFileDocument { get; set; } = null;

        public int workIdDocType { get; set; }
        public IFormFile workIdDocument { get; set; }

        public int civilIdDocType { get; set; }
        public IFormFile civilIdDocument { get; set; }

        public int salaryDataDocType { get; set; }
        public IFormFile salaryDataDocument { get; set; }
        public int AttachId { get; set; }
        public int Serialno { get; set; }
        public decimal? DocumentType { get; set; }
        public string AttachmentPath { get; set; }
        public string AttachmentByName { get; set; }
        public string AttachmentsDetail { get; set; }
        public bool? Actived { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? CreatedBy { get; set; }
        public int? ShareId { get; set; }
        public int? Catid { get; set; }
        public string Keywords { get; set; }
        public string Action { get; set; }
        public int? RoutId { get; set; }
        public string UserDocumentNo { get; set; }
        public string ApprovedBy { get; set; }
    }
}
