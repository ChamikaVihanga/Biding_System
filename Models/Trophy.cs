namespace SampleBid2.Models
{
    public class Trophy
    {
        public int Id { get; set; }
        public string TropName { get; set; }
        public DateTime dateTime { get; set; }
        public string Duration { get; set; }


        /// <summary>
        /// 
        /// </summary>
/*        public int PlayerId { get; set; }
        public Player Player { get; set; }*/
        
        /// <summary>
        /// 
        /// </summary>
        public int TeamId { get; set; }
        public Team Team { get; set; }

    }
}
