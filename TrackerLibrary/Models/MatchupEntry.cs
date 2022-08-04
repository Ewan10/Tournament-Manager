using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary.Modelss
{
    public class MatchupEntry
    {
        public int id { get; set; }

        public Team TeamCompeting { get; set; }

        public double Score { get; set; }

        // <summary>
        /// Represents the matchup that this team came from 
        /// as the winner of the previous round.
        // </summary>
        public Matchup ParentMatchup { get; set; }
    }
}