namespace API.DTOs
{
    public class ServiceSetupServicesDto
    {
        public int ServiceID { get; set; }
        // menu name arabic
        public string? WebArabic { get; set; }
        // menu name english
        public string? WebEnglish { get; set; }
        // english web content
        public string? EnglishHTML { get; set; }
        // arabic web content
        public string? ArabicHTML { get; set; }
        public string? EnglishWebPageName { get; set; }
        public string? ArabicWebPageName { get; set; }
        public string? ElectronicForm1 { get; set; }
        public string? ElectronicForm1URL { get; set; }
        public string? ElectronicForm2 { get; set; }
        public string? ElectronicForm2URL { get; set; }
        public bool? IsElectronicForm { get; set; }
        public byte[] OfferImageFile { get; set; }
        public string? OfferImage { get; set; }
        public string? Remarks { get; set; }

    }
}
