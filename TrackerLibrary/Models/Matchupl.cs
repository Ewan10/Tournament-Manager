using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary.Models
{
    public class Matchup 
    {
        public int id { get; set; }

        public List<MatchupEntry> Entries { get; set; } = new List<MatchupEntry>();

        public Team Winner { get; set; }

        public int MatchupRound { get; set; }
    }
}