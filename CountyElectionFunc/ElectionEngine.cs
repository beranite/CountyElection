using System.Collections.Generic;

namespace CountyElectionFunc
{
    public class ElectionEngine
    {
        public VoteSession CurrentVoteSession { get; private set; }
        public List<int> Mandates { get; private set; }

        public Dictionary<string, PartyVote> PartyVotes { get; set; } = new Dictionary<string, PartyVote>();
        public Dictionary<string, int> UnionVotes { get; set; }

        public ElectionEngine(VoteSession voteSession)
        {
            CurrentVoteSession = voteSession;
            Mandates = new List<int>();
        }

        public void CalculateMandates()
        {

            // Logic to calculate mandates based on the current vote session
            // This is a placeholder for the actual implementation
            foreach (var station in CurrentVoteSession.Stations)
            {
                foreach (var partyVote in station.PartyVotes)
                {
                    if (!PartyVotes.ContainsKey(partyVote.Party))
                    {
                        PartyVotes[partyVote.Party] = new PartyVote { Party = partyVote.Party, Votes = 0 };
                    }
                    PartyVotes[partyVote.Party].Votes += partyVote.Votes;
                }

            }

            // Extra unions for single party
            UnionVotes = new Dictionary<string, int>();
            foreach (var party in PartyVotes)
            {
                bool found = false;
                foreach (var union in CurrentVoteSession.Unions)
                {
                    if (union.PartyIds.Contains(party.Key))
                    {
                        if (!UnionVotes.ContainsKey(union.Name))
                        {
                            UnionVotes[union.Name] = 0;
                        }
                        UnionVotes[union.Name] += PartyVotes[party.Key].Votes;
                        found = true;
                        break;
                    }
                }
                if (found) continue;
                // If the party is not in any union, add it as a single party union 
                UnionVotes[party.Key] = party.Value.Votes;
            }

            // Calculate mandates for each party
            var partyEntries = new List<PlaceEntry>();
            foreach (var entry in UnionVotes)
            {
                partyEntries.Add(new PlaceEntry(entry.Key, entry.Value));
            }
            var unionPlaceMandates = new PlaceMandates(23, partyEntries);
            unionPlaceMandates.AssignMandates();
            // Store the results in Mandates per party
            foreach (var entry in unionPlaceMandates.Entries)
            {
                bool unionFound = false;
                foreach (var union in CurrentVoteSession.Unions)
                {
                    if (union.Name == entry.Id)
                    {
                        partyEntries = new List<PlaceEntry>();
                        foreach (var party in union.PartyIds)
                        {
                            partyEntries.Add(new PlaceEntry(party, PartyVotes[party].Votes));
                        }
                        var placeMandates = new PlaceMandates(entry.Mandates, partyEntries);
                        placeMandates.AssignMandates();
                        foreach (var partyEntry in placeMandates.Entries)
                        {

                            PartyVotes[partyEntry.Id].Mandates = partyEntry.Mandates;
                        }
                        unionFound = true;

                        break;
                    }
                }
                if (!unionFound)
                {
                    PartyVotes[entry.Id].Mandates = entry.Mandates;
                }
            }
        }
    }
}