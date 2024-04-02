using System;
using System.Collections.Generic;

namespace API.DTOs
{
    public class VoucherDtoListObj
    {
        public int TotalRecords { get; set; }
        public  List<VoucherDto>  VoucherDto { get; set; }
       // public VoucherDto[] VoucherDto { get; set; }
    }

    public class VoucherDto
    {
        public long JvId { get; set; }
        public long MYTRANSID { get; set; }
        public DateTime JvDate { get; set; }
        public string JvCode { get; set; }
        public string ArabicName { get; set; }
        public string EnglishName { get; set; }
        public string employeeID { get; set; }
        public string LoanAccountNumber { get; set; }
        public string ServiceType { get; set; }
        public string ServiceSubType { get; set; }
        public string Status { get; set; }
        public string PFID { get; set; }
        public string CivilId { get; set; }
        public string Narrations { get; set; }
        public bool IsPosted { get; set; }
        public double TotalAmount { get; set; }
    }
}
