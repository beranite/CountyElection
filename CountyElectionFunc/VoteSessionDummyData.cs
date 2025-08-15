using System;
using System.Collections.Generic;

namespace CountyElectionFunc
{
    public static class VoteSessionDummyData
    {
        public static void SaveToFile()
        {
        
            var electionData = VoteSessionDummyData.CreateDummyElectionData();
            string filePath = "c:\\temp\\electiondata.json";

            ElectionDataFileHandler.SaveToFile(filePath, electionData);
        }

        /// <summary>
        public static ElectionData CreateDummyElectionData()
        {
            var electionData = new ElectionData
            {
                ElectionName = "County Council Election 2023",
                ElectionDate = new DateTime(2023, 5, 15),
                VoteSessions = new List<VoteSession>
                {
                    CreateDummyVoteSession()
                }
            };

            return electionData;
        }

        public static VoteSession CreateDummyVoteSession()
        {
            var party1 = new ElectionParty { Id = "P1", Name = "Party One" };
            var party2 = new ElectionParty { Id = "P2", Name = "Party Two" };

            var station1 = new PollingStation { Name = "Central School" };
            var station2 = new PollingStation { Name = "Town Hall" };

            var pollingStationVote1 = new PollingStationVote
            {
                Station = station1,
                PartyVotes = new List<PartyVote>
                {
                    new PartyVote { Party = "P1", Votes = 120 },
                    new PartyVote { Party = "P2", Votes = 80 }
                }
            };

            var pollingStationVote2 = new PollingStationVote
            {
                Station = station2,
                PartyVotes = new List<PartyVote>
                {
                    new PartyVote { Party = "P1", Votes = 95 },
                    new PartyVote { Party = "P2", Votes = 105 }
                }
            };

            return new VoteSession
            {
                Date = DateOnly.FromDateTime(DateTime.Today),
                Parties = new List<ElectionParty> { party1, party2 },
                Stations = new List<PollingStationVote> { pollingStationVote1, pollingStationVote2 }
            };
        }
    }
}