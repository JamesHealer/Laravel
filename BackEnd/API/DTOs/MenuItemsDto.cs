using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class MenuItemsDto
    {
        public MenuItemsDto()
        {
            MenuItems = new List<MenuItemsDto>();
            
        }
        public string MenuItemNameEnglish { get; set; }
        public string MenuItemNameArabic { get; set; }
        public string MenuItemIconPath { get; set; }
        public string MenuItemSmallText { get; set; }
        public string MenuItemFullName { get; set; }
        public string MenuItemLink { get; set; }
        public string MenuItemURLOption { get; set; }
        public string MenuItemURLRewrite { get; set; }
        public string MenuItemMenuLocation { get; set; }
        public decimal? MenuItemMenuOrder { get; set; }
        public string MenuItemDocParent { get; set; }
        public int? MenuItemAddFlage { get; set; }
        public int? MenuItemEditFlage { get; set; }
        public int? MenuItemDelFlage { get; set; }
        public int? MenuItemPrintFlage { get; set; }
        public int? MenuItemAmIGlobale { get; set; }
        public int? MenuItemMyPersonal { get; set; }
        public DateTime MenuItemActiveTillDate { get; set; }
        public int MenuItemLabelFlage { get; set; }
        public int? MenuItemSp1 { get; set; }
        public int? MenuItemSp2 { get; set; }
        public int? MenuItemSp3 { get; set; }
        public int? MenuItemSp4 { get; set; }
        public int? MenuItemSp5 { get; set; }
        public int? MenuLevel { get; set; }
        public string MenuItemSpName1 { get; set; }
        public string MenuItemSpName2 { get; set; }
        public string MenuItemSpName3 { get; set; }
        public string MenuItemSpName4 { get; set; }
        public string MenuItemSpName5 { get; set; }
        public bool ActiveMenu { get; set; }
        public DateTime MenuDate { get; set; }
        public int MENU_ID { get; set; }
        public int MASTER_ID { get; set; }
        public int MODULE_ID { get; set; }
        public List<MenuItemsDto> MenuItems { get; set; }
    }
}
