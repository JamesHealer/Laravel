using API.DTOs;
using API.DTOs.DropDown;
using API.DTOs.EmployeeDto;
using API.DTOs.FinancialServicesDto;
using API.DTOs.FinancialTransaction;
using API.DTOs.RefTable;
using API.Helpers;
using API.Models;
using API.Servivces.Interfaces;
using API.Servivces.Interfaces.FinancialServices;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FinancialServiceController : ControllerBase
    {
        private readonly KUPFDbContext _context;
        private readonly IFinancialService _financialService;
        public IMapper _mapper;
        private readonly IFinancialTransactionService _IFinancialTransactionService;
        public FinancialServiceController(KUPFDbContext context, 
            IFinancialService financialService, IMapper mapper, 
            IFinancialTransactionService IFinancialTransactionService)
        {
            _context = context;
            _mapper = mapper;
            _financialService = financialService;
            _IFinancialTransactionService = IFinancialTransactionService;
        }
        /// <summary>
        /// Api to add new record(s) in TransactionHd and TransactionDt
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("AddFinancialService")]
        public async Task<ActionResult<FinancialServiceResponse>> AddFinancialService([FromForm]TransactionHdDto transactionHdDto)
        {
            var response = await _financialService.AddFinancialServiceAsync(transactionHdDto);
            await _context.SaveChangesAsync();
            return response;
        }
        /// <summary>
        /// Api to update existing record(s) in TransactionHd and TransactionDt
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [Route("UpdateFinancialService")]
        public async Task<ActionResult<FinancialServiceResponse>> UpdateFinancialService([FromForm]TransactionHdDto transactionHdDto)
        {
            if (transactionHdDto != null)
            {
                var result = await _financialService.UpdateFinancialServiceAsync(transactionHdDto);
                return result;
            }
            return null;
        }
        /// <summary>
        /// Api to get existing record(s) in TransactionHd
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetFinancialServiceById")]
        public async Task<ReturnSingleFinancialServiceById> GetFinancialServiceById(long transId)
        {
            if (transId != 0)
            {
                var result = await _financialService.GetFinancialServiceByIdAsync(transId);
                return result;
            }
            return null;
        }
        /// <summary>
        /// Api to Get All Financial Services.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetFinancialServices")]
        public async Task<PagedList<ReturnTransactionHdDto>> GetEmployees([FromQuery] PaginationModel paginationModel, int filterVal, int ServiceStatusFilterVal, int DraftStatusFilterVal)
        {
            var result = await _financialService.GetFinancialServiceAsync(paginationModel, filterVal, ServiceStatusFilterVal, DraftStatusFilterVal);
            Response.AddPaginationHeader(result.CurrentPage, result.PageSize, result.TotalCount, result.TotalPages);
            return result;
        }
        /// <summary>
        /// Api to Delete Financial Service by Tranaction Id.
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        [Route("DeleteFinancialService")]
        public async Task<int> DeleteFinancialService(long transId)
        {
            int result = 0;
            if (transId != 0)
            {
                result = await _financialService.DeleteFinancialServiceAsync(transId);
            }

            return result;
        }

        /// <summary>
        /// Api to Get service type and service sub types for Transactions.
        /// </summary>
        /// <returns></returns>

        [HttpGet]
        [Route("GetServiceByServiceTypeAndSubType/{serviceType}/{serviceSubType}/{tenentId}")]
        public async Task<ServiceSetupDto> GetServiceTypeAndSubType(int serviceType, int serviceSubType, int tenentId)
        {
            var result = await _financialService.GetServiceByServiceTypeAndSubType(serviceType, serviceSubType, tenentId);
            return result;
        }
        /// <summary>
        /// Api to Get service approvals
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetServiceApprovalsAsync")]
        public async Task<IEnumerable<ManagerApprovalDto>> GetServiceApprovalsAsync([FromQuery] PaginationModel paginationModel,long periodCode, int tenentId, int locationId, bool isShowAll)
        {
            var result = await _financialService.GetServiceApprovalsAsync(paginationModel,periodCode, tenentId, locationId, isShowAll);
            Response.AddPaginationHeader(result.CurrentPage, result.PageSize, result.TotalCount, result.TotalPages);
            return result;
        }
        /// <summary>
        /// Api to approve service
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [Route("ManagerApproveServiceAsync")]
        public async Task<ActionResult<string>> ManagerApproveServiceAsync(ApproveRejectServiceDto approveRejectServiceDto)
        {
            var result = await _financialService.ManagerApproveServiceAsync(approveRejectServiceDto);
            return result;
        }
        [HttpPut]
        [Route("FinanceApproveServiceAsync")]
        public async Task<ActionResult<string>> FinanceApproveServiceAsync(ApproveRejectServiceDto approveRejectServiceDto)
        {
            var result = await _financialService.FinanceApproveServiceAsync(approveRejectServiceDto);
            return result;
        }
        /// <summary>
        /// Api to get rejection type
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetRejectionType")]
        public async Task<IEnumerable<RefTableDto>> GetRejectionType()
        {
            var result = await _financialService.GetRejectionType();
            return result;
        }
        /// <summary>
        /// Api to reject service.
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [Route("ManagerRejectServiceAsync")]
        public async Task<ActionResult<string>> ManagerRejectServiceAsync(ApproveRejectServiceDto approveRejectServiceDto)
        {
            var result = await _financialService.ManagerRejectServiceAsync(approveRejectServiceDto);
            return result;
        }
        /// <summary>
        /// Api to Get service approvals by employee Id
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetServiceApprovalsByEmployeeId")]
        public async Task<IEnumerable<ReturnServiceApprovals>> GetServiceApprovalsByEmployeeId(int employeeId)
        {
            var result = await _financialService.GetServiceApprovalsByEmployeeId(employeeId);
            return result;
        }
        /// <summary>
        /// Api to get service approval details by transaction Id...
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetServiceApprovalDetailByTransId")]
        public async Task<IEnumerable<ReturnServiceApprovalDetails>> GetServiceApprovalDetailByTransId(int transId)
        {
            var result = await _financialService.GetServiceApprovalDetailByTransId(transId);
            return result;
        }
        /// <summary>
        /// Api to Get service type.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetServiceType")]
        public IEnumerable<SelectServiceTypeDto> GetServiceType(int tenentId)
        {
            var result = _financialService.GetServiceType(tenentId);
            return result;
        }
        /// <summary>
        /// Api to make final tranaction...
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("MakeFinancialTransactionAsync")]
        public async Task<ActionResult<int>> MakeFinancialTransactionAsync(CostCenterDto costCenterDto)
        {
            return await _financialService.MakeFinancialTransactionAsync(costCenterDto);            
        }

        [HttpPost]
        [Route("SaveCOA")]
        public async Task<Response> SaveCOA(List<AccountRequest> accounts)
        {
            var result = _IFinancialTransactionService.SaveCOA(accounts);
            return result;
        }
        [HttpPost]
        [Route("SaveVoucher")]
        public async Task<Response> SaveVoucher(VoucherRequest voucherRequest)
        {
            var result = _IFinancialTransactionService.SaveVoucher(voucherRequest);
            return result;
        }
        [HttpPost]
        [Route("CashVoucher")]
        public async Task<Response> CashVoucher(CashRequest Req)
        {
            var result = _IFinancialTransactionService.CashVoucher(Req);
            return result;
        }
        /// <summary>
        /// Api to get sub service type by service type 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetSubServiceTypeByServiceType")]
        public async Task<IEnumerable<SelectSubServiceTypeDto>> GetSubServiceTypeByServiceType(int tenentId, int refId)
        {
            var result = await _financialService.GetSubServiceTypeByServiceType(tenentId, refId);
            return result;
        }
        /// <summary>
        /// Api to get Get Service Approvals By Transation Id 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetServiceApprovalsByTransIdAsync")]
        public async Task<ReturnApprovalDetailsDto> GetServiceApprovalsByTransIdAsync(int tenentId, int locationId,int transId)
        {
            var result = await _financialService.GetServiceApprovalsByTransIdAsync(tenentId, locationId, transId);
            return result;
        }
        /// <summary>
        /// Api to search employee by EmployyeId,PFId,CId
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("SearchEmployee")]
        public async Task<ReturnSearchResultDto> SearchEmployee(SearchEmployeeDto searchEmployeeDto)
        {
            var result = await _financialService.SearchEmployee(searchEmployeeDto);
            return result;
        }
        /// <summary>
        /// Api to search employee by EmployyeId,PFId,CId
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetCashierApprovals")]
        public async Task<PagedList<CashierApprovalDto>> GetCashierApprovals([FromQuery] PaginationModel paginationModel, long periodCode, int tenentId, int locationId, bool isShowAll)
        {
            var result = await _financialService.GetCashierApprovals(paginationModel, periodCode, tenentId, locationId,isShowAll);
            Response.AddPaginationHeader(result.CurrentPage, result.PageSize, result.TotalCount, result.TotalPages);
            return result;
        }
        /// <summary>
        /// Create Cahier Delivery
        /// </summary>
        /// <param name="cashierApprovalDto"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("CreateCahierDelivery")]
        public async Task<int> CreateCahierDelivery(CashierApprovalDto cashierApprovalDto)
        {
            var result = await _financialService.CreateCahierDelivery(cashierApprovalDto);
            return result;
        }
        /// <summary>
        /// Create Cahie rDraft
        /// </summary>
        /// <param name="cashierApprovalDto"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("CreateCahierDraft")]
        public async Task<int> CreateCahierDraft(CashierApprovalDto cashierApprovalDto)
        {
            var result = await _financialService.CreateCahierDraft(cashierApprovalDto);
            return result;
        }
        /// <summary>
        /// Generate Financial Service Serial No (Max + 1)
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GenerateFinancialServiceSerialNo")]
        public int GenerateFinancialServiceSerialNo()
        {
            var result = _financialService.GenerateFinancialServiceSerialNo();
            return result;
        }
        /// <summary>
        /// Search Sponsor
        /// </summary>
        /// <param name="searchEmployeeDto"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("SearchSponsor")]
        public async Task<ReturnSearchResultDto> SearchSponsor(SearchEmployeeDto searchEmployeeDto)
        {
            var result = await _financialService.SearchSponsor(searchEmployeeDto);
            return result;
        }
        /// <summary>
        /// Search New Subscriber...
        /// </summary>
        /// <param name="searchEmployeeDto"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("SearchNewSubscriber")]
        public async Task<ReturnSearchResultDto> SearchNewSubscriber(SearchEmployeeDto searchEmployeeDto)
        {
            var result = await _financialService.SearchNewSubscriber(searchEmployeeDto);
            return result;
        }
        /// <summary>
        /// Api to Get service approvals for Employee
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetServiceApprovalsByEmployeeIdForManager")]
        public async Task<IEnumerable<ReturnApprovalsByEmployeeId>> GetServiceApprovalsByEmployeeIdForManager(int employeeId, int tenentId, int locationId)
        {
            var result = await _financialService.GetServiceApprovalsByEmployeeIdForManager(employeeId, tenentId, locationId);
            return result;
        }
        [HttpGet]
        [Route("GetFinacialApprovals")]
        public async Task<PagedList<CashierApprovalDto>> GetFinacialApprovals([FromQuery] PaginationModel paginationModel, long periodCode, int tenentId, int locationId,bool isShowAll)
        {
            var result = await _financialService.GetFinacialApprovals(paginationModel,periodCode, tenentId, locationId,isShowAll);
            Response.AddPaginationHeader(result.CurrentPage, result.PageSize, result.TotalCount, result.TotalPages);
            return result;
        }

        [HttpPut]
        [Route("FinanceRejectServiceAsync")]
        public async Task<ActionResult<string>> FinanceRejectServiceAsync(ApproveRejectServiceDto approveRejectServiceDto)
        {
            var result = await _financialService.FinanceRejectServiceAsync(approveRejectServiceDto);
            return result;
        }

        [HttpGet]
        [Route("GetFinancialServicesFilterData/{pageNo}/{itemCount}")]
        public async Task<IEnumerable<ReturnTransactionHdDto>> GetEmployeesFilter(int pageNo, int itemCount, string searchKeyword = null)
        {
            var result = await _financialService.GetFinancialServiceData(pageNo, itemCount, searchKeyword);
            return result;
        }

        /// <summary>
        /// Api to Get All Financial Services to export in excel.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetFinancialServicesToExportExcel")]
        public async Task<IEnumerable<ReturnTransactionHdDto>> GetFinancialServicesToExportExcel(int filterVal, int ServiceStatusFilterVal, int DraftStatusFilterVal)
        {
            var result = await _financialService.GetFinancialServicesToExportExcel(filterVal, ServiceStatusFilterVal, DraftStatusFilterVal);
            return result;
        }

        /// <summary>
        /// Api to Get All Financial Services by service typeid and service  sub-typeid
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetFinancialServicesByServiceTypeAndServiceSubType")]
        public async Task<PagedList<ReturnTransactionHdDto>> GetFinancialServicesByServiceTypeAndServiceSubType([FromQuery] PaginationModel paginationModel, int filterVal, int ServiceStatusFilterVal, int DraftStatusFilterVal, int ServiceTypeId, int ServiceSubTypeId)
        {
            var result = await _financialService.GetFinancialServicesByServiceTypeAndServiceSubType(paginationModel, filterVal, ServiceStatusFilterVal, DraftStatusFilterVal, ServiceTypeId, ServiceSubTypeId);
            Response.AddPaginationHeader(result.CurrentPage, result.PageSize, result.TotalCount, result.TotalPages);
            return result;
        }

        /// <summary>
        /// Api to get  all service type and sub-service type data
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetServiceTypeSubServiceTypeByTenentId")]
        public async Task<IEnumerable<SeriveTypeSubServiceTypeMDL>> GetServiceTypeSubServiceTypeByTenentId(int tenentId)
        {
            var result = await _financialService.GetServiceTypeSubServiceTypeByTenentId(tenentId);
            return result;
        }
    }
}
