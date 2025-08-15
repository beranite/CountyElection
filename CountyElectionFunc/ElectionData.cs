namespace CountyElectionFunc
{
    public class ElectionData
    {
        public string ElectionName { get; set; }
        public DateTime ElectionDate { get; set; }
      
        public List<VoteSession> VoteSessions { get; set; }

        public ElectionData()
        {

        }
      
    }
}
