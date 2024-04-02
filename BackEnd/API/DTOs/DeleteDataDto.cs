namespace API.DTOs
{
    public class DeleteDataDto
    {
        public string Id { get; set; }
        public int  LocationId { get; set; }
        public int  TenentId { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
    }
}
