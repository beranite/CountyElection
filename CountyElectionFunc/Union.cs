using System.Collections.Generic;

namespace CountyElectionFunc
{
    public class Union
    {
        public string Name { get; set; }    
        // List of party IDs in the union
        public List<string> PartyIds { get; set; }

        public Union()
        {
            PartyIds = new List<string>();
        }
    }
}