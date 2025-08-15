using System;
using System.Collections.Generic;

namespace CountyElectionFunc
{
    public class VoteSession
    {
        public DateOnly Date { get; set; }
        public List<PollingStationVote> Stations { get; set; }

        public List<ElectionParty> Parties { get; set; }

        public VoteSession()
        {
            Stations = new List<PollingStationVote>();
        }
    }
}