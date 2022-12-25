namespace SampleBid2.Models
{
    public class Trophy
    {
        public int Id { get; set; }
        public string Trop_Name { get; set; }
        public DateTime StartDate { get; set; }
        public int Duration { get; set; }


        /// <summary>
        /// 
        /// </summary>
/*        public int PlayerId { get; set; }
        public Player Player { get; set; }*/
        
        /// <summary>
        /// 
        /// </summary>
        public int TeamId { get; set; }
        public Team? Team { get; set; }

    }
}
