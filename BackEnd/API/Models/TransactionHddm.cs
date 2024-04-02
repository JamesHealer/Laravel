using System;
using System.Collections.Generic;

#nullable disable

namespace API.Models
{
    public partial class TransactionHddm
    {
        public int TenentId { get; set; }
        public long Mytransid { get; set; }
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
        public long? CrupId { get; set; }
        public int? ShareId { get; set; }
        public int? Catid { get; set; }
        public string Subject { get; set; }
        public string Keywords { get; set; }
        public string MetaTags { get; set; }
        public string Remarks { get; set; }
        public string Action { get; set; }
        public int? RoutId { get; set; }
    }
}
