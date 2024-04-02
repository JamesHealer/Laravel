namespace API.DTOs
{
    public class SelectSubServiceTypeDto
    {
        public int RefId { get; set; }
        public string? ShortName { get; set; }
        public string? MenuId { get; set; }
        public string Tab1 { get; set; }
        public string Tab2 { get; set; }
        public string Tab3 { get; set; }
        public string Tab4 { get; set; }
        public string Tab5 { get; set; }
        public string Tab6 { get; set; }
        public int AllowSponser { get; set; }
    }

    public class SeriveTypeSubServiceTypeMDL
    {
        public int ServiceTypeId { get; set; }
        public string ServiceTypeName { get; set; }
        public int  SubServiceTypeId { get; set; }
        public string  SubServiceTypeName{ get; set; }
        public string ServiceTypeEnglishName { get; set; }
        public string ServiceTypeArabicName { get; set; }
        public string SubServiceTypeEnglishName { get; set; }
        public string SubServiceTypeArabicName { get; set; }
        public string  MenuId { get; set; }
        public string Tab1 { get; set; }
        public string Tab2 { get; set; }
        public string Tab3 { get; set; }
        public string Tab4 { get; set; }
        public string Tab5 { get; set; }
        public string Tab6 { get; set; }
        public int AllowSponser { get; set; }
    }
}
