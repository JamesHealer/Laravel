using API.DTOs.LocalizationDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class MenuHeadingDto
    {
        public MenuHeadingDto()
        {
            MenuItems = new List<MenuItemsDto>();
            ListMenuHeadingDto = new List<MenuHeadingDto>();
        }
        public string HeadingNameEnglish { get; set; }
        public string HeadingNameArabic { get; set; }
        public int HeadingMenuId { get; set; }
        public string HeadingIconPath { get; set; }
        public string HeadingSmallText { get; set; }
        public string HeadingFullName { get; set; }
        public string HeadingLink { get; set; }
        public string HeadingURLOption { get; set; }
        public string HeadingURLRewrite { get; set; }
        public string HeadingMenuLocation { get; set; }
        public decimal? HeadingMenuOrder { get; set; }
        public string HeadingDocParent { get; set; }
        public int? HeadingAddFlage { get; set; }
        public int? HeadingEditFlage { get; set; }
        public int? HeadingDelFlage { get; set; }
        public int? HeadingPrintFlage { get; set; }
        public int? HeadingAmIGlobale { get; set; }
        public int? HeadingMyPersonal { get; set; }
        public DateTime HeadingActiveTillDate { get; set; }
        public int HeadingLabelFlage { get; set; }
        public int? HeadingSp1 { get; set; }
        public int? HeadingSp2 { get; set; }
        public int? HeadingSp3 { get; set; }
        public int? HeadingSp4 { get; set; }
        public int? HeadingSp5 { get; set; }
        public string HeadingSpName1 { get; set; }
        public string HeadingSpName2 { get; set; }
        public string HeadingSpName3 { get; set; }
        public string HeadingSpName4 { get; set; }
        public string HeadingSpName5 { get; set; }
        public bool ActiveMenu { get; set; }
        public DateTime MenuDate { get; set; }
        public List<MenuItemsDto> MenuItems { get; set; }
        public List<MenuHeadingDto> ListMenuHeadingDto { get; set; }
        public List<FormTitleDTLanguageDto> listMenuHighLightHeading  { get; set; }
    }
    public class ListMenuHighLightHeading
    {
        public string FormID { get; set; }
        public int Language { get; set; }
        public string LabelId { get; set; }
        public string Title { get; set; }
        public string ArabicTitle { get; set; }
        public string RL { get; set; }
    }
}
