using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class ReturnServiceApprovalDetails
    {
        public int MyTransId { get; set; }
        public int MyId { get; set; }
        public decimal? InstallmentAmount { get; set; }
        public decimal? ReceivedAmount { get; set; }
        public decimal? PendingAmount { get; set; }
        public decimal? DiscountedAmount { get; set; }
    }
}
