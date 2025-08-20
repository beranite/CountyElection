using System.Collections.Generic;

namespace CountyElectionFunc
{


    public class PlaceEntry
    {
        public string Id { get; set; }
        public int OrigVotes { get; set; }
        public int Mandates { get; set; }
        public decimal VoteWeight { get; set; }

        public PlaceEntry(string id, int origVotes)
        {
            Id = id;
            OrigVotes = origVotes;
            Mandates = 0;
            VoteWeight = origVotes;
        }

        override public string ToString()
        {
            return $"{Id} - Votes: {OrigVotes}, Mandates: {Mandates}, VoteWeight: {VoteWeight}";
        }
    }

    public class PlaceMandates
    {
        int Mandates { get; set; }
        List<PlaceEntry> Entries { get; set; }
        public PlaceMandates(int mandates, List<PlaceEntry> entries)
        {
            Mandates = mandates;
            Entries = entries;
        }


        public void AssignMandates()
        {
            for (int i = 0; i < Mandates; i++)
            {
                var nextEntry = FindNextEntry();
                if (nextEntry != null)
                {
                    nextEntry.Mandates++;
                    nextEntry.VoteWeight = ((decimal)nextEntry.OrigVotes) / (nextEntry.Mandates + 1);
                }
            }
        }

        private PlaceEntry FindNextEntry()
        {
            PlaceEntry nextEntry = null;
            foreach (var entry in Entries)
            {
                if (nextEntry == null || entry.VoteWeight > nextEntry.VoteWeight)
                {
                    nextEntry = entry;
                }
            }
            return nextEntry;
        }
    }
    
}