using Microsoft.VisualBasic;
using System;

namespace API.DTOs
{
    public class EmployeeActivityLogDto
    {
        public string FieldName { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
        public string Severity { get; set; }
        public string CrudType { get; set; }        
        public DateTime CreatedDate { get; set; }
    }
}
