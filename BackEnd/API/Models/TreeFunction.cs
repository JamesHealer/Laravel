using System;
using System.Collections.Generic;

#nullable disable

namespace API.Models
{
    public partial class TreeFunction
    {
        public int RoleId { get; set; }
        public int NodeId { get; set; }
        public string NodeImageUrl { get; set; }
        public string NodeNavUrl { get; set; }
        public byte IsParent { get; set; }
        public int ParentId { get; set; }
        public string ReadAllow { get; set; }
        public string WriteAllow { get; set; }
        public string PrintAllow { get; set; }
        public string DeleteAllow { get; set; }
        public string Other1Allow { get; set; }
        public string Other2Allow { get; set; }
        public string Other3Allow { get; set; }
        public string Other4Allow { get; set; }
        public string Other5Allow { get; set; }
        public string PagePath { get; set; }
        public string PageTitle { get; set; }
        public string PageTitle1 { get; set; }
        public string PageTitle2 { get; set; }
        public string DashBoardImage { get; set; }
        public int? MenuOrder { get; set; }
        public bool? IsGraph { get; set; }
        public byte? MenuType { get; set; }
        public bool? IsVisibleInMenu { get; set; }
        public int TenentId { get; set; }
    }
}
