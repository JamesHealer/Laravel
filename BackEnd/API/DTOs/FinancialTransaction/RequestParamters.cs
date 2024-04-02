using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs.FinancialTransaction
{
    public class RequestParamters
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public int TenantID { get; set; }
        public int LocationID { get; set; }
    }
    public class Response
    {
        public int ID { get; set; }
        public string Message { get; set; }
        public int Status { get; set; }
        public System.Data.DataTable Result { get; set; }
    }
}
