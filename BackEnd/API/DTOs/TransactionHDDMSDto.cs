using Microsoft.AspNetCore.Http;
using System;

namespace API.DTOs
{
    public class TransactionHDDMSDto
    {
        public int? TenentId { get; set; }
        public long? Mytransid { get; set; }
        public int? Serialno { get; set; }
        public decimal? DocumentType { get; set; }
        public IFormFile Document { get; set; }
        public string AttachmentPath { get; set; }
        public string AttachmentByName { get; set; }
        public string MetaTags { get; set; }
        public int AttachId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string Subject { get; set; }
        public string Remarks { get; set; }
        public byte[] Attachment { get; set; }


    }
}
