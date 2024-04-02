using System;
using System.Collections.Generic;

#nullable disable

namespace API.Models
{
    public partial class UserDtl
    {
        public int TenentId { get; set; }
        public int UserDetailId { get; set; }
        public long CrupId { get; set; }
        public int LocationId { get; set; }
        public string CountryCode { get; set; }
        public string Title { get; set; }
        public string HouseNo { get; set; }
        public string Street { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public int? Country { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string PhNo { get; set; }
        public string FaxNo { get; set; }
        public string FromRegDt { get; set; }
        public string VillageTownCity { get; set; }
        public string Tehsil { get; set; }
        public string PincodeNo { get; set; }
        public string PostOffice { get; set; }
        public string PanNo { get; set; }
        public string EmailAddress { get; set; }
        public decimal? MobileNum { get; set; }
        public string SecQues { get; set; }
        public string SecAns { get; set; }
    }
}
