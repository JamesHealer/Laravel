using System;
using System.Collections.Generic;

#nullable disable

namespace API.Models
{
    public partial class AccountType
    {
        public int AccountTypeId { get; set; }
        public string AccountTypeName { get; set; }
        public string ArabicAccountTypeName { get; set; }
    }
}
