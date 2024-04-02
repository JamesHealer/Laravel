using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class TestCompany
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        
        public ICollection<TestEmployee> Employees { get; set; }
    }
}