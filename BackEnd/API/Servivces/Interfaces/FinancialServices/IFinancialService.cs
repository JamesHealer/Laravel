using API.DTOs;
using API.DTOs.DropDown;
using API.DTOs.EmployeeDto;
using API.DTOs.FinancialServicesDto;
using API.DTOs.RefTable;
using API.Helpers;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Servivces.Interfaces.FinancialServices
{
    public interface IFinancialService
    {
        Task<FinancialServiceResponse> AddFinancialServiceAsync(TransactionHdDto transactionHdDto);
        Task<FinancialServiceResponse> UpdateFinancialServiceAsync(TransactionHdDto transactionHdDto);
        Task<ReturnSingleFinancialServiceById> GetFinancialServiceByIdAsync(long id);
        Task<PagedList<ReturnTransactionHdDto>> GetFinancialServiceAsync([FromQuery] PaginationModel paginationModel, int filterVal, int ServiceStatusFilterVal, int DraftStatusFilterVal);
        Task<int> DeleteFinancialServiceAsync(long id);
        Task<ServiceSetupDto> GetServiceByServiceTypeAndSubType(int serviceType, int serviceSubType,int tenentId);
        Task<PagedList<ManagerApprovalDto>> GetServiceApprovalsAsync([FromQuery] PaginationModel paginationModel,long periodCode, int tenentId, int locationId,bool isShowAll);

        Task<IEnumerable<ReturnApprovalsByEmployeeId>> GetServiceApprovalsByEmployeeIdForManager(int employeeId, int tenentId, int locationId);

        Task<string> ManagerApproveServiceAsync(ApproveRejectServiceDto approveRejectServiceDto);        
        Task<string> ManagerRejectServiceAsync(ApproveRejectServiceDto approveRejectServiceDto);
        Task<IEnumerable<RefTableDto>> GetRejectionType();
        Task<IEnumerable<ReturnServiceApprovals>> GetServiceApprovalsByEmployeeId(int employeeId);
        Task<IEnumerable<ReturnServiceApprovalDetails>> GetServiceApprovalDetailByTransId(int transId);
        IEnumerable<SelectServiceTypeDto> GetServiceType(int tenentId);

        Task<int> MakeFinancialTransactionAsync(CostCenterDto costCenterDto);
        Task<IEnumerable<SelectSubServiceTypeDto>> GetSubServiceTypeByServiceType(int tenentId, int refId);

        Task<ReturnApprovalDetailsDto> GetServiceApprovalsByTransIdAsync(int tenentId, int locationId,int transId);

        long GetPeriodCode();

        /// <summary>
        /// Search employee by EmployeeId,PF Id and C Id
        /// </summary>
        /// <returns></returns>
        Task<ReturnSearchResultDto> SearchEmployee(SearchEmployeeDto searchEmployeeDto);

        Task<PagedList<CashierApprovalDto>> GetCashierApprovals([FromQuery] PaginationModel paginationModel, long periodCode, int tenentId, int locationId, bool isShowAll);

        Task<int> CreateCahierDelivery(CashierApprovalDto cashierApprovalDto);
        int GenerateFinancialServiceSerialNo();

        Task<ReturnSearchResultDto> SearchSponsor(SearchEmployeeDto searchEmployeeDto);

        Task<ReturnSearchResultDto> SearchNewSubscriber(SearchEmployeeDto searchEmployeeDto);

        Task<PagedList<CashierApprovalDto>> GetFinacialApprovals([FromQuery] PaginationModel paginationModel, long periodCode, int tenentId, int locationId, bool isShowAll);

        Task<string> FinanceApproveServiceAsync(ApproveRejectServiceDto approveRejectServiceDto);

        Task<string> FinanceRejectServiceAsync(ApproveRejectServiceDto approveRejectServiceDto);
        Task<int> CreateCahierDraft(CashierApprovalDto cashierApprovalDto);

        Task<IEnumerable<ReturnTransactionHdDto>> GetFinancialServiceData(int pageNo, int itemCount, string searchKeyword);

        Task<IEnumerable<ReturnTransactionHdDto>> GetFinancialServicesToExportExcel(int filterVal, int ServiceStatusFilterVal, int DraftStatusFilterVal);

        Task<PagedList<ReturnTransactionHdDto>> GetFinancialServicesByServiceTypeAndServiceSubType([FromQuery] PaginationModel paginationModel, int filterVal, int ServiceStatusFilterVal, int DraftStatusFilterVal, int ServiceTypeId, int ServiceSubTypeId);

        Task<IEnumerable<SeriveTypeSubServiceTypeMDL>> GetServiceTypeSubServiceTypeByTenentId(int tenentId);
    }
}
