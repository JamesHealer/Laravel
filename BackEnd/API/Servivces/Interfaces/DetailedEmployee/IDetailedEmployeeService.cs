using API.DTOs;
using API.DTOs.EmployeeDto;
using API.Helpers;
using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace API.Servivces.Interfaces.DetailedEmployee
{
    public interface IDetailedEmployeeService
    {
        Task<int> AddEmployeeAsync(DetailedEmployeeDto detailedEmployeeDto);
        Task<int> UpdateEmployeeAsync(DetailedEmployeeDto user);
        Task<DetailedEmployeeDto> GetEmployeeByIdAsync(int id);
        Task<PagedList<DetailedEmployeeDto>> GetEmployeesAsync(PaginationModel paginationModel);
        Task<TransData> DeleteEmployeeAsync(DetailedEmployeeDto detailedEmployeeDto);
        
        Task<string> ValidateEmployeeData(DetailedEmployeeDto detailedEmployeeDto);
        Task<PagedList<DetailedEmployeeDto>> FilterEmployeeListAsync(PaginationParams paginationParams, int filterVal);

        Task<ResultMDL> UploadEmployeeExcelFile(string xmlDocumentWithoutNs,int tenantId,string username,string UploaderName, int PeriodCode);
        Task<List<ImportEmployeeServiceMDL>> GetEmployeeImportServiceData(int tenantId, int periodCode, int DataImportFilterValue, string UploaderType);
        Task<ResultMDL> AddEmployeeServiceDataFinalSubmit(EmployeeServiceTransList employeeServiceTransList);
        Task<ResultMDL> EmployeeServiceDataDraftSubmit(EmployeeServiceTransList employeeServiceTransList);
        Task<ResultMDL> DeletEmployeeImportServiceData(EmployeeServiceTransList employeeServiceTransList);
        Task<IEnumerable<EmployeeDetailsWithAllServiceData>> GetEmployeeDataByEmpId(long employeeId);
        Task<bool> ValidateEmployeeId(long tenantId, int locationId, long employeeId);

        Task<ResultMDL> ImportEmployeeData(ImportEmpDataModel data);
        Task<List<CheckMonthlyDataMDL>> CheckMonthlyData(ImportMonthlyDataModel data);
        Task<ResultMDL> ImportMonthlyData(ImportMonthlyDataModel data);
        
        Task<PagedList<DetailedEmployeeDto>> SixMonthSubcriptionDateFilterEmployeeListAsync(PaginationParams paginationParams, int filterVal);
    }
}
