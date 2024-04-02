using API.DTOs;
using API.DTOs.EmployeeDto;
using API.DTOs.FinancialTransaction;
using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Servivces.Interfaces
{
    public interface IFinancialTransactionService
    {
        Response SaveCOA(List<AccountRequest> accounts);
        Response SaveVoucher(VoucherRequest Re);
        Response GetAccountByType(COARequest Req);
        Response GetCostCenters(RequestParamters Req);
        Response CashVoucher(CashRequest Req);

        int IfAccountExists(int tenantId, int locationId, int headId, int accountNo);

    }
}
