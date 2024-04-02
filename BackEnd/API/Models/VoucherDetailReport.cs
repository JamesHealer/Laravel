using System;
using System.Collections.Generic;
using System.Numerics;

namespace API.Models
{
    public class VoucherDetailReport
    {
        public int ReportId { get; set; }
        public string ReportContent { get; set; }
    }

    public class VoucherDetailReportModel
    {
        public string  	EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string VoucherType { get; set; }
        public string VoucherNumber { get; set; }
        public string VoucherDate { get; set; }
        public string DraftNumber { get; set; }
        public string DraftDate { get; set; }
        public string VoucherDescription { get; set; }
        public List<VoucherDetailTrans> voucherDetailTrans { get; set; }
    }

    public class VoucherDetailTrans
    {
        public string AccountNumber { get; set; }
        public string AccountName { get; set; }
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
    }

    public class  ReportInputModel
    {
        public int TransId { get; set; }
        public int VoucherId { get; set; } 
    }
}
