using Microsoft.AspNetCore.Http;

namespace API.DTOs
{
    public class OfferFilesDto
    {
        public int Id { get; set; }
        public string? ElectronicForm1Name { get; set; }
        public string? ElectronicForm2Name { get; set; }
        public string? OfferImageName { get; set; }
        
    }
}
