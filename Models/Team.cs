namespace SampleBid2.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string TeamName { get; set; }
        public string Budget { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<Trophy>?Trophies { get; set; }

        ///
        public List<Player>? Players { get; set; }

    }
}

