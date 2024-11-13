namespace HovedOpgaveWebAPI.Models
{
    public class UserDetails
    {
        public required string Gender { get; set; }
        public int Volume { get; set; }
        public decimal Money { get; set; }
        public int Chips { get; set; }
        public List<string> RewardNames { get; set; } = new List<string>();
    }
}