using System;
using System.Collections.Generic;

#nullable disable

namespace API.Models
{
    public partial class ChequeBook
    {
        public int TenentId { get; set; }
        public int LocationId { get; set; }
        public int ChequeBookId { get; set; }
        public int? AccountId { get; set; }
        public int? FromChequeNo { get; set; }
        public int? ToChequeNo { get; set; }
        public int? TotalCheques { get; set; }
        public int? UsedCheques { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? EntryDate { get; set; }
    }
}
