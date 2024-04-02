using System.Collections.Generic;
using System;

namespace API.DTOs
{
    public class NewSubscriberDto
    {

        public int TotalRecords { get; set; }
        public List<NewSubscriberDtoList> NewSubscriberList { get; set; }
    }

    public class NewSubscriberDtoList
    {
        public string ArabicName { get; set; }
        public string EnglishName { get; set; }
        public string employeeID { get; set; }
        public string Status { get; set; }
        public string CivilId { get; set; }
        public string MobileNo { get; set; }
        public DateTime SubscriptionAppliedDate { get; set; }
    }
}


