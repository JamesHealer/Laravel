using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace API.Models
{
    public partial class Crupaudit
    {
        public Int64 TenantId { get; set; }
        public int LocationId { get; set; }
        public Int64 CrupId { get; set; }
        public int MySerial { get; set; }
        [Key]
        public int AuditNo { get; set; }
        public string? AuditType { get; set; }
        public string TableName { get; set; }
        public string? FieldName { get; set; }
        public string? OldValue { get; set; }
        public string? NewValue { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? UpdateUserName { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? CreatedUserName { get; set; }
        public int UserId { get; set; }
        public string? Severity { get; set; }
        public string CrudType { get; set; }
    }
}
