using Microsoft.AspNetCore.Http;
using System;

namespace API.DTOs
{
    public class OffersDto
    {
        public int TenentId { get; set; }
        public int? ServiceId { get; set; }
        public string Active { get; set; }
        public long? CrupId { get; set; }
        public string Userid { get; set; }
        public DateTime? Entrydate { get; set; }
        public DateTime? Entrytime { get; set; }
        public DateTime? Updttime { get; set; }
        public DateTime? UploadDate { get; set; }
        public string Uploadby { get; set; }
        public DateTime? SyncDate { get; set; }
        public string Syncby { get; set; }
        public int? SynId { get; set; }
        public IFormFile? File1 { get; set; }
        public IFormFile? ElectronicForm1Attachment { get; set; }
        public string? ElectronicForm1 { get; set; }
        public IFormFile? ElectronicForm2Attachment { get; set; }
        public string? ElectronicForm2 { get; set; }
        public string? OfferName { get; set; }
        public string? OfferImage { get; set; }
        public string? OfferType { get; set; }
        public string? Offer { get; set; }
        public DateTime? OfferStartDate { get; set; }
        public DateTime? OfferEndDate { get; set; }
        public decimal? OfferAmount { get; set; }
        public string? ElectronicForm1URL { get; set; }
        public string? ElectronicForm2URL { get; set; }
        public string? EnglishHTML { get; set; }
        public string? EnglishWebPageName { get; set; }
        public string? ArabicHTML { get; set; }
        public string? ArabicWebPageName { get; set; }
        public string? OfferTypeName { get; set; }
        // menu name arabic
        public string? WebArabic { get; set; }
        // menu name english
        public string? WebEnglish { get; set; }
        public bool? IsElectronicForm { get; set; }
        public int? ServiceType { get; set; }
        public int? ServiceSubType { get; set; }
    }
}
