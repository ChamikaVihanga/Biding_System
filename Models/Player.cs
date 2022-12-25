namespace SampleBid2.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string PlayerName { get; set; }
        public string PerFormance { get; set; }
        public  string CotractNo { get; set; }
        public string? Address { get; set; }
        public string BacePrice { get; set; }
         
        public bool Sold { get; set; }

 

        public int? TeamId { get; set; }
        public Team? Team { get; set; }
    }
}
