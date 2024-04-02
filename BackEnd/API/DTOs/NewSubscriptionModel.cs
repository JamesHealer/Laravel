namespace API.DTOs
{
    public class NewSubscriptionModel
    {
        public string EmpId { get; set; }
        public string CivilId { get; set; }
        public string EmpName { get; set; }
        public string EmpEmail { get; set; }
        public string EmpMobile { get; set; }
        public int IsKUEmp { get; set; }
        public int IsSickLeave { get; set; }
    }

    public class RecievedOffersModel
    {
        public string EmpId { get; set; }
        public string CivilId { get; set; }
        public string EmpName { get; set; }
        public string EmpEmail { get; set; }
        public string EmpMobile { get; set; }
       // public int IsKUEmp { get; set; }
        public string ServiceId { get; set; }
    }
}
