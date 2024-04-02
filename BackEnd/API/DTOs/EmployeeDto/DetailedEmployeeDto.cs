using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs.EmployeeDto
{
    public class DetailedEmployeeDto
    {
        public int TenentId { get; set; }
        public int LocationId { get; set; }
        public int EmployeeId { get; set; }
        public string ContractType { get; set; }
        public string Pfid { get; set; }
        public string Token { get; set; }
        public DateTime? SubscribedDate { get; set; }
        public decimal? AgreedSubAmount { get; set; }
        public DateTime? ReSubscribed { get; set; }
        public string EmployeeType { get; set; }
        public string ArabicName { get; set; }
        public string EnglishName { get; set; }
        public int? JobTitleCode { get; set; }
        public string JobTitleName { get; set; }
        public int? Department { get; set; }
        public string DepartmentName { get; set; }
        public short? EmpGender { get; set; }
        public DateTime? EmpBirthday { get; set; }
        public string? EmpMaritalStatus { get; set; }
        public decimal? Salary { get; set; }
        public string EmpWorkTelephone { get; set; }
        public string EmpWorkEmail { get; set; }
        public string MobileNumber { get; set; }
        public string Next2KinName { get; set; }
        public string Next2KinMobNumber { get; set; }
        public int? NationCode { get; set; }
        public string NationName { get; set; }
        public string EmpCidNum { get; set; }
        public string EmpPaciNum { get; set; }
        public string EmpOtherId { get; set; }
        public int? EmpStatus { get; set; }
        public DateTime? JoinedDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? TerminationId { get; set; }
        public DateTime? SubscriptionDate { get; set; }
        public DateTime? ReSubscripedDate { get; set; }
        public string LoanAct { get; set; }
        public string HajjAct { get; set; }
        public string ConsumerLoanAct { get; set; }
        public string PersLoanAct { get; set; }
        public string OtherAct1 { get; set; }
        public string OtherAct2 { get; set; }
        public string OtherAct3 { get; set; }
        public string OtherAct4 { get; set; }
        public string OtherAct5 { get; set; }
        public string EmpStreet1 { get; set; }
        public string EmpStreet2 { get; set; }
        public string CityCode { get; set; }
        public int? CounCode { get; set; }
        public string Remarks { get; set; }
        public string UserId { get; set; }
        public string ActiveDirectoryId { get; set; }
        public int? MainHrroleId { get; set; }
        public string EmployeeLoginId { get; set; }
        public string EmployeePassword { get; set; }
        public bool? Active { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? DateTime { get; set; }
        public string DeviceId { get; set; }
        public DateTime? UploadDate { get; set; }
        public string Uploadby { get; set; }
        public DateTime? SyncDate { get; set; }
        public string Syncby { get; set; }
        public int? SynId { get; set; }
        public string RefName1 { get; set; }
        public string RefName2 { get; set; }
        public string? Membership { get; set; }
        public DateTime? MembershipJoiningDate { get; set; }
        public string? Termination { get; set; }
        public DateTime? TerminationDate { get; set; }

        public bool? IsKUEmployee { get; set; }
        public bool? IsOnSickLeave { get; set; }
        public bool? IsMemberOfFund { get; set; } = false;
        public long? CRUP_ID { get; set; }
        public int? SettlementSerMonths { get; set; }
        public decimal? SettlementAmount { get; set; }
        public DateTime? NextSetlementPayDate { get; set; }
        public decimal? NextSetlementPayAmount { get; set; }
        public int? Subscription_status { get; set; }
        public string Username { get; set; }
        public DateTime? CreatedDate { get; set; }

        public decimal? LoanOPNotPaidAmount { get; set; }
        public decimal? LoanOPAmount { get; set; }
        public decimal? SubOPNotPaidAmount { get; set; }
        public decimal? SubOPAmount { get; set; }
        public decimal? HoldQty { get; set; }
        public string HoldRemarks { get; set; }
        public DateTime? UnHoldDate { get; set; }
        public string UnHoldBy { get; set; }
        public bool TerminationBanned { get; set; }
        public bool IsChecked { get; set; }

    }

    public class UploadEmpDataInputModel
    {
        public string username { get; set; }
        public string tenantId { get; set; }
        public string UploaderName { get; set; }
        public int PeriodCode { get; set; }
        public IFormFile file { get; set; }
        // public FileType FileType { get; set; }
    }

    public class ImportEmployeeModel
    {
        public int EmployeeUnivNo { get; set; }
        public string EnglishNAme { get; set; }
        public string ArabicNAme { get; set; }
        public DateTime JoinedDate { get; set; }
        public int PFNo { get; set; }
        public DateTime SubscribedDate { get; set; }
        public int MemStatus { get; set; }
        public int AgreedSubmt { get; set; }
        public int AmountReceivedTillNow { get; set; }
        public int LastSalary { get; set; }
        public DateTime TerminationDate { get; set; }
        public string Occupation { get; set; }
        public int Gender { get; set; }
        public string Mobile { get; set; }
        public int CivilID { get; set; }
        public DateTime Birthday { get; set; }
        public int ContractType { get; set; }
        public string ContractTypeName { get; set; }
        public string Email { get; set; }
        public int EmpPaciNo { get; set; }
        public int Nationality { get; set; }
        public string NationalityName { get; set; }
        public string NextToKin { get; set; }
        public int Department { get; set; }
        public string DepartmentName { get; set; }
        public int JobTitleCode { get; set; }
        public string JobTitleName { get; set; }
    }

    public class ImportEmpDataModel
    {
        public int TenantId { get; set; }
        public int LocationId { get; set; }
        public string UserName { get; set; }
        public int UserId { get; set; }
        public List<ImportEmployeeModel> EmployeeData {get; set;}
    }

    public class ImportMonthlyModel
    {
        public string YearMonth { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string Reference { get; set; }
        public int Salary { get; set; }
        public decimal Amount { get; set; }
    }

    public class ImportMonthlyDataModel
    {
        public int TenantId { get; set; }
        public int LocationId { get; set; }
        public string UserName { get; set; }
        public int UserId { get; set; }
        public string PeriodCode { get; set; }
        public string NextPeriodCode { get; set; }
        public string UploadType { get; set; }
        public List<ImportMonthlyModel> MonthlyData { get; set; }
    }
}

