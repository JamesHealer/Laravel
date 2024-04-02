using API.DTOs;
using System;
using System.Collections.Generic;

namespace API.Models
{
    public class OffersRecievedDto
    {

        public int TotalRecords { get; set; }
        public List<OffersRecievedList> OffersRecievedList { get; set; }
    }

    public class OffersRecievedList
    {
        public string ArabicName { get; set; }
        public string EnglishName { get; set; }
        public string employeeId { get; set; }
        public string ServiceId { get; set; }
        public string ServiceTypeId { get; set; }
        public string ServiceSubTypeId { get; set; }
        public string ServiceTypeName { get; set; }
        public string ServiceSubTypeName { get; set; }
        public string Status { get; set; }
        public string CivilId { get; set; }
        public string MobileNo { get; set; }
        public DateTime OffersRecievedDate { get; set; }
    }
}
