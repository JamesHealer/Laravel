using System;
using System.Collections.Generic;

#nullable disable

namespace API.Models
{
    public partial class DetailedEmployeeImport
    {
        public int TenentId { get; set; }
        public int LocationId { get; set; }
        public int EmployeeId { get; set; }
        public string Importdate { get; set; }
        public string Pfid { get; set; }
        public string EmployeeType { get; set; }
        public string ArabicName { get; set; }
        public string EnglishName { get; set; }
        public int? JobTitleCode { get; set; }
        public string JobTitleName { get; set; }
        public int? Department { get; set; }
        public string DepartmentName { get; set; }
        public short? EmpGender { get; set; }
        public DateTime? EmpBirthday { get; set; }
        public string EmpMaritalStatus { get; set; }
        public decimal? Salary { get; set; }
        public string EmpWorkTelephone { get; set; }
        public string EmpWorkEmail { get; set; }
        public string MobileNumber { get; set; }
        public string Next2KinName { get; set; }
        public string Next2KinMobNumber { get; set; }
        public int? NationCode { get; set; }
        public string EmpCidNum { get; set; }
        public string EmpPaciNum { get; set; }
        public int? EmpOtherId { get; set; }
        public int? EmpStatus { get; set; }
        public DateTime? JoinedDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? SubscriptionDate { get; set; }
        public DateTime? ReSubscripedDate { get; set; }
        public string LoanAct { get; set; }
        public string HajjAct { get; set; }
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
        public int? TerminationId { get; set; }
        public string Remarks { get; set; }
        public string UserId { get; set; }
        public string ActiveDirectoryId { get; set; }
        public int? MainHrroleId { get; set; }
        public string StudenLoginId { get; set; }
        public string Password { get; set; }
        public bool? Active { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? DateTime { get; set; }
        public string DeviceId { get; set; }
        public DateTime? UploadDate { get; set; }
        public string Uploadby { get; set; }
        public DateTime? SyncDate { get; set; }
        public string Syncby { get; set; }
        public int? SynId { get; set; }
    }
}
