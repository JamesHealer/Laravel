using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models
{
    public class TestEmployee
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int TestCompanyId { get; set; }
    }
}