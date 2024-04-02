using System.Collections.Generic;

namespace API.DTOs
{
    public class TestCompaniesDto
    {       
        public string Name { get; set; }        
        public ICollection<TestEmployeesDto> Employees { get; set; }
    }
}