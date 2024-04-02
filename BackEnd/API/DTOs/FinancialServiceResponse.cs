namespace API.DTOs
{
    public class FinancialServiceResponse
    {
        public string TransactionId { get; set; }
        public string AttachId { get; set; }
        public string PFId { get; set; }
        public string Response { get; set; }
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
