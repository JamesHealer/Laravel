using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class CoaDto
    {
        public int TenentId { get; set; }
        public int LocationId { get; set; }
        public int AccountId { get; set; }
        public int? FamilyId { get; set; }
        public int HeadId { get; set; }
        public int? SubHeadId { get; set; }
        public Int64 AccountNumber { get; set; }
        public string AccountName { get; set; }
        public string ArabicAccountName { get; set; }
        public string OtherAccountName { get; set; }
        public int AccountTypeId { get; set; }
        public bool IsActive { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public long? Crupid { get; set; }
        public string BankAccountNo { get; set; }
        public int? SubSubHeadId { get; set; }
    }
}
