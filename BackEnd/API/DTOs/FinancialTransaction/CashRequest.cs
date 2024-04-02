using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs.FinancialTransaction
{
    public class CashRequest : RequestParamters
    {
        public int VoucherType_ID { get; set; }
        public string InvoiceNo { get; set; }
        public DateTime VoucherDate { get; set; }
        public int UserID { get; set; }
        public int CostCenter_ID { get; set; }
        public int Account_ID { get; set; }
        public decimal Amount { get; set; }
    }
    public class VoucherRequest : RequestParamters
    {
        public DateTime VoucherDate { get; set; }
        public int VoucherType_ID { get; set; }
        public string InvoiceNo { get; set; }
        public int UserID { get; set; }
        public int CostCenter_ID { get; set; }
        public List<VoucherDetail> VoucherDetail { get; set; }
    }
    public class VoucherDetail
    {
        public int Account_ID { get; set; }
        public decimal Amount { get; set; }
        public string Particulars { get; set; }
    }

    public class COARequest : RequestParamters
    {
        public int AccountTypeID { get; set; }
    }
}
