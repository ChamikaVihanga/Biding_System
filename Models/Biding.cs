namespace SampleBid2.Models
{
    public class Biding
    {
        public int Id { get; set; }
        public string BidPrice { get; set; }
        public DateTime Date { get; set; }

        public int PlayerId { get; set; }
        public Player Player { get; set; } 
    }
}
