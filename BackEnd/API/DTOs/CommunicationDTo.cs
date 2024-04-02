using Microsoft.VisualBasic;

namespace API.DTOs
{
    public class SelectLetterTypeDTo
    {
        public int refId { get; set; }
        public string shortName { get; set; }
    }


    public class SelectPartyTypeDTo
    {
        public int refId { get; set; }
        public string refname1 { get; set; }
        public string refname2 { get; set; }
    }


    public class IncommingCommunicationDto
    {
        public long? mytransid { get; set; }
        public string? searchtag { get; set; }
        public string? description { get; set; }
        public string? filledat { get; set; }
        public string? lettertype { get; set; }
        public string? letterdated { get; set; }

        public string? UserDocumentNo { get; set; }
        public string? approvedBy { get; set; }
    }
    public class SelectFilledTypeDTo
    {
        public int refId { get; set; }
        public string shortName { get; set; }
    }



}
