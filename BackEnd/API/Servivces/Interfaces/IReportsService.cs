using API.DTOs;
using API.Helpers;
using API.Models;
using System.Threading.Tasks;

namespace API.Servivces.Interfaces
{
    public interface IReportsService
    {
        Task<VoucherDetailReport> GetVoucherDetailsReport(ReportInputModel reportInputModel);
        Task<byte[]> GenerateSubscribersMembersReport(EmployeeDetailsWithHistoryDtoObj obj);
        Task<byte[]> GenerateAssemblyReport(EmployeeDetailsWithHistoryDtoObj obj);
        Task<byte[]> GenerateEmployeeLoansStatementsReport(EmployeeDetailsWithHistoryDto obj);
        Task<byte[]> GenerateLoansDeducationReport(EmployeeDetailsWithHistoryDtoObj obj);
        Task<byte[]> GenerateSubscribeDeducationReport(EmployeeDetailsWithHistoryDtoObj obj);
        Task<byte[]> GenerateCertificatesReport(EmployeeDetailsWithHistoryDto obj);
    }
}
