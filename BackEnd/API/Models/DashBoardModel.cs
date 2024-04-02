using System;
using System.Collections.Generic;

namespace API.Models
{
    public class DashBoardModel
    {
        public List<NewMembersDashBoardModel> newMembersDashBoardModel { get; set; }
        public List<NewMembersDashBoardModel> membersStatisticsDashBoardModel { get; set; }
        public List<NewMembersDashBoardModel> latestSubscriberDashBoardModel { get; set; }
        public List<NewSubscriberDashBoardModel> newSubscriberDashBoardModel { get; set; }
        public List<ToDoDashBoardModel>  toDoDashBoardModels { get; set; }
        public List<EmployeePerformanceDashBoardModel> employeePerformanceDashBoardModel { get; set; }
    }
    public class NewMembersDashBoardModel
    {
        public int employeeID { get; set; }
        public string EmployeeEnglishName { get; set; }
        public string EmployeeArabicName { get; set; } 
        public int TenentID { get; set; }
        public int LocationID { get; set; }
        public string PFID { get; set; }
        public DateTime joined_date { get; set; }
        public DateTime EmpUpdatedDate { get; set; }
        public int SubscriptionstatusId { get; set; }
        public string SubscriptionstatusEnglish { get; set; }
        public string SubscriptionstatusArabic { get; set; }
        public string DepartmentEnglish { get; set; }
        public string DepartmentArabic { get; set; }
        public string MobileNumber { get; set; }  
        public int SubscriptionStatusId { get; set; }
        public string EmployeeEnglishDescription { get; set; }
        public string EmployeeArabicDescription { get; set; }
        public string UniversityNameEnglish { get; set; }
        public string UniversityNameArabic { get; set; }
        public string ImageUrl { get; set; }
        public DateTime TRANSDATE { get; set; }
    }

    public class NewSubscriberDashBoardModel
    {
        public int employeeID { get; set; }
        public string EmployeeEnglishName { get; set; }
        public string EmployeeArabicName { get; set; }
        public int TenentID { get; set; }
        public int ServiceStatustatusId { get; set; }
        public string ServiceStatusEnglish { get; set; }
        public string ServiceStatusArabic { get; set; }
        public string DepartmentEnglish { get; set; }
        public string DepartmentArabic { get; set; }  
        public DateTime TRANSDATE { get; set; }
        public string ImageUrl { get; set; }
    }
    public class ToDoDashBoardModel
    {
        public int employeeID { get; set; }
        public string EmployeeEnglishName { get; set; }
        public string EmployeeArabicName { get; set; }
        public int TenentID { get; set; }
        public string PFID { get; set; }
        public int LocationID { get; set; }
        public string ServiceTypeEnglish { get; set; }
        public string ServiceTypeArabic { get; set; }
        public string ServicesSubTypeEnglish { get; set; }
        public string ServicesSubTypeArabic { get; set; } 
        public DateTime RecordCreated_Time { get; set; }
        public Int64 MYTRANSID { get; set; }
        public string ImageUrl { get; set; }
    }

    public class EmployeePerformanceDashBoardModel
    {
        public int UserID { get; set; }
        public int TenentID { get; set; }
        public int UsrTrns { get; set; }
        public string UserEnglishName { get; set; }
        public string UserArabicName { get; set; }
        public int EmployeePerFormancePercentage { get; set; }
        public string TransactionMonth { get; set; }
        public string TransactionYear { get; set; }
        public string ImageUrl { get; set; }
    }
}
