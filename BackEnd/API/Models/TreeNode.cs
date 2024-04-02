using System;
using System.Collections.Generic;

#nullable disable

namespace API.Models
{
    public partial class TreeNode
    {
        public int TenentId { get; set; }
        public int NodeId { get; set; }
        public int? LocationId { get; set; }
        public string NodeValue { get; set; }
        public string NodeImageUrl { get; set; }
        public string NodeNavUrl { get; set; }
        public byte IsParent { get; set; }
        public int ParentId { get; set; }
        public byte? IsSubParent { get; set; }
        public int? SubParentId { get; set; }
        public string ReadAllow { get; set; }
        public string WriteAllow { get; set; }
        public string PrintAllow { get; set; }
        public string DeleteAllow { get; set; }
        public string Other1 { get; set; }
        public string Other2 { get; set; }
        public string Other3 { get; set; }
        public string Other4 { get; set; }
        public string Other5 { get; set; }
        public string PagePath { get; set; }
        public string PageTitle { get; set; }
        public string PageTitle1 { get; set; }
        public string PageTitle2 { get; set; }
        public string DashBoardImage { get; set; }
        public int? MenuOrder { get; set; }
        public int? SortBy { get; set; }
        public bool? IsGraph { get; set; }
        public byte? MenuType { get; set; }
        public bool? IsVisibleInMenu { get; set; }
        public string CommandName { get; set; }
        public string Position { get; set; }
    }
}
