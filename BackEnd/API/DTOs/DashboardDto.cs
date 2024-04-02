namespace API.DTOs
{
    public class loanPercentageDto
    {
        public int total_count { get; set; }
        public int hajjloan_count { get; set; }
        public int hajjloan_per { get; set; }
        public int socloan_count { get; set; }
        public int socloan_per { get; set; }
        public int finloange_count { get; set; }
        public int consloan_count { get; set; }
        public int finloange_per { get; set; }
        public int consloan_per { get; set; }
    }

    public class dashboardResponseDto
    {
        public string myperiodcode { get; set; }
        public long? myid { get; set; }
        public string mylabel1 { get; set; }
        public long? myvalue1 { get; set; }
        public string mylabel2 { get; set; }
        public long? myvalue2 { get; set; }

    }
}
