using API.DTOs;
using API.DTOs.DropDown;
using API.DTOs.EmployeeDto;
using API.Helpers;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DTOs.RefTable;
namespace API.Servivces.Interfaces
{
    public interface ICommonService 
    {             
        Task<IEnumerable<SelectOccupationDto>> GetOccupationsAsync();
        Task<IEnumerable<SelectDepartmentDto>> GetDepartmentsAsync();
        Task<IEnumerable<SelectTerminationDto>> GetTerminationsAsync();
        Task<IEnumerable<SelectHajjLoanDto>> GetHajjLoanAsync();
        Task<IEnumerable<SelectLoanActDto>> GetLoanActAsync();
        Task<IEnumerable<SelectConsumerLoanActDto>> GetConsumerLoanActAsync();
        Task<IEnumerable<SelectPerLoanActDto>> GetPerLoanActAsync();
        Task<IEnumerable<SelectOtherAct1Dto>> GetOtherAcc1Async();
        Task<IEnumerable<SelectOtherAct2Dto>> GetOtherAcc2Async();
        Task<IEnumerable<SelectOtherAct3Dto>> GetOtherAcc3Async();
        Task<IEnumerable<SelectOtherAct4Dto>> GetOtherAcc4Async();

        Task<IEnumerable<CoaDto>> VerifyAccount(Int64 accountNo);

        Task<IEnumerable<SelectUserDto>> GetUsers();

        Task<IEnumerable<SelectMasterIdDto>> GetMasterId();

        /// <summary>
        /// Get All RefTypes
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<SelectRefTypeDto>> GetRefType();
        /// <summary>
        /// Get All RefSubTypes
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<SelectRefSubTypeDto>> GetRefSubType();
        /// <summary>
        /// Get RefSubType by RefType....
        /// </summary>
        /// <param name="refType"></param>
        /// <returns></returns>
        Task<IEnumerable<SelectRefSubTypeDto>> GetRefSubTypeByRefType(string refType);

        /// <summary>
        /// Get Service Type
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<SelectServiceTypeDto>> GetServiceTypeByMasterIds(int[] masterIds);
        /// <summary>
        /// Get Service Type
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<SelectServiceSubTypeDto>> GetServiceSubType(string switchNo);
        /// <summary>
        /// Get Master Service Type
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<SelectMasterServiceTypeDto>> GetMasterGetServiceType();
        /// <summary>
        /// GetMinMonthOfServices
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<SelectMinMonthOfServicesDto>> GetMinMonthOfServices();
        /// <summary>
        /// GetMinInstallments
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<SelectMinInstallmentDto>> GetMinInstallments();
        /// <summary>
        /// GetMaxInstallments
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<SelectMaxInstallmentDto>> GetMaxInstallments();

        Task<IEnumerable<SelectApprovalRoleDto>> GetApprovalRoles();

        /// <summary>
        /// Search employee by EmployeeId,PF Id and C Id
        /// </summary>
        /// <returns></returns>
        Task<DetailedEmployeeDto> SearchEmployee(SearchEmployeeDto searchEmployeeDto);

        /// <summary>
        /// Get Selected Service Types to display services on add service page
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<SelectedServiceTypeDto>> GetSelectedServiceType(int tenentId);
        /// <summary>
        /// Get Selected Service Sub Types to display services on add service page
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<SelectedServiceSubTypeDto>> GetSelectedServiceSubType(int tenentId);

        Task<IEnumerable<SelectServiceTypeDto>> GetServiceType(int tenentId);
        Task<IEnumerable<SelectServiceTypeDto>> GetSubServiceTypeByServiceType(int tenentId,int refId);
        Task<IEnumerable<SelectServiceTypeDto>> GetDocTypes(int tenentId);

        Task<IEnumerable<SelectOccupationDto>> GetContractTypeAsync();
        Task<IEnumerable<ServiceSetupServicesDto>> GetServicesForWebMenu();

        Task<IEnumerable<SelectServiceTypeDto>> GetOffers();

        Task<FinanaceCalculationDto> GetFinancialCalculationByEmployeeId(int employeeId, int tenentId, int locationId, DateTime transactionDate);
        Task<CashierInformationDto> GetCashierInformationByEmployeeId(int employeeId, int tenentId, int locationId, int transactionId);

        Task<IEnumerable<SelectBankAccount>> GetBankAccounts(int tenentId, int locationId);

        Task<CashierApprovalDto> GetDraftInformationByEmployeeId(int employeeId, int tenentId, int locationId, int transactionId);

        Task<IEnumerable<SelectLetterTypeDTo>> GetLetterTypeAsync();
        Task<IEnumerable<SelectPartyTypeDTo>> GetPartyTypeAsync();

        loanPercentageDto GetDashboardLoanDetails();

        Task<IEnumerable<SelectFilledTypeDTo>> GetFilledAtAsync();

        Task<List<CountriesDto>> GetCountryList();

        Task<List<UniversityDto>> GetUniversityList();
        long CreateMyTransIdForTransactionHD();
        long CreateEmployeePFId(int tenentId, int locationId);


        List<dashboardResponseDto> GetDashboardTotalEmployees();

        Task<int> AddNewSubscription(NewSubscriptionModel newSubscriptionModel);

        Task<NewSubscriberDto> GetNewSubscription(PaginationParams paginationParams, int tenentId, int locationId);
        Task<IEnumerable<SelectUserDto>> GetUsersBytenentidandlocationid(int tenentid, int locationid);
        Task<int> AddRecievedOffersByWebsite(RecievedOffersModel recievedOffersModel);

        Task<IEnumerable<ImportExcelDataDto>> GetImportDataUploaderAsync(int tenentid);

        Task<ResultMDL> AddFormLabelsInEnglishAndArabic(FormLabelsLanguageModel formLabelsLanguageModel);

        Task<IEnumerable<ServiceSetupDto>> GetOffersForWebsite();
        Task<OffersRecievedDto> GetRecievedOffersByWebsite(PaginationParams paginationParams, int tenentId, int locationId);

        Task<ResultMDL> RefreshUpdatedData(int tenentid);
        Task<List<RefTableDto>> GetLocations();
        Task<List<TransactionHdDto>> GetContracts();
        Task<IEnumerable<SelectServiceTabDto>> GetServiceTabAsync();
        Task<List<long>> GetPeriods();
    }
}
