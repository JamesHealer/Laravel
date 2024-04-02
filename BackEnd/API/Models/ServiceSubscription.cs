using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class ServiceSubscription
    {
        public int TenentId { get; set; }
        public int Id { get; set; }
        public string EmployeeId { get; set; }
        public string EnglishName { get; set; }
        public string ArabicName { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Department { get; set; }
        public string Occupation { get; set; }
        public string Service { get; set; }

    }
}
