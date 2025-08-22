namespace CountyElectionFunc
{
    public class PollingStationVote
    {
        public PollingStation Station { get; set; }
        public List<PartyVote> PartyVotes { get; set; }

        public PollingStationVote()
        {
            PartyVotes = new List<PartyVote>();
        }
    }

    public class PartyVote
    {
        public string Party { get; set; }
        public int Votes { get; set; }

        public int Mandates { get; set; }

        override public string ToString()
        {
            return $"{Party} - Votes: {Votes}, Mandates: {Mandates}";
        }   
    }
}