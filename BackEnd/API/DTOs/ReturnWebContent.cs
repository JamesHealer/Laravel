using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class ReturnWebContent
    {
        public string? EnglishHTML { get; set; }
        public string? EnglishWebPageName { get; set; }
        public string? ArabicHTML { get; set; }
        public string? ArabicWebPageName { get; set; }
        public string? ElectronicForm1 { get; set; }
        public string? ElectronicForm1URL { get; set; }
        public string? ElectronicForm2 { get; set; }
        public string? ElectronicForm2URL { get; set; }
    }
}
