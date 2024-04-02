using System;
using System.Collections.Generic;

#nullable disable

namespace API.Models
{
    public partial class UserMst
    {
        public int TenentId { get; set; }
        public int UserId { get; set; }
        public int LocationId { get; set; }
        public int CrupId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FirstName1 { get; set; }
        public string LastName1 { get; set; }
        public string FirstName2 { get; set; }
        public string LastName2 { get; set; }
        public string LoginId { get; set; }
        public string Password { get; set; }
        public int? UserType { get; set; }
        public string Remarks { get; set; }
        public string ActiveFlag { get; set; }
        public DateTime? LastLoginDt { get; set; }
        public int? UserDetailId { get; set; }
        public string AccLock { get; set; }
        public string FirstTime { get; set; }
        public string PasswordChng { get; set; }
        public string ThemeName { get; set; }
        public DateTime? ApprovalDt { get; set; }
        public string VerificationCd { get; set; }
        public string EmailAddress { get; set; }
        public DateTime? TillDt { get; set; }
        public bool? IsSignature { get; set; }
        public string SignatureImage { get; set; }
        public string Avtar { get; set; }
        public int? CompId { get; set; }
        public int? EmpId { get; set; }
        public bool? CheckinSwitch { get; set; }
        public long? LoginActive { get; set; }
        public bool? Activeuser { get; set; }
        public DateTime? Userdate { get; set; }
        public string Language1 { get; set; }
        public string Language2 { get; set; }
        public string Language3 { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string EmployeePosition { get; set; }
        public string Salary { get; set; }
        public DateTime? DateOfJoining { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public int ROLEID { get; set; }
    }
}
