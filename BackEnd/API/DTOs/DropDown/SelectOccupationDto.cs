using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class SelectOccupationDto
    {
        public int Refid { get; set; }
        public string Shortname { get; set; }
    }

    public class ImportExcelDataDto
    {
        public int Refid { get; set; }
        public string Shortname { get; set; }
        public string REFNAME1 { get; set; }
        public string REFNAME2 { get; set; }
    }
}
