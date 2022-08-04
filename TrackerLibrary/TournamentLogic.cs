using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackerLibrary.Models
{
    public static class TournamentLogic
    {
        public static void CreateRounds(TournamentModel tournament)
        {
            List<TeamModel> randomizedTeams = RandomizeTeamOrder(tournament.EnteredTeams);
            int rounds = FindNumberOfRounds(randomizedTeams.Count);
            int byes = NumberOfByes(rounds, randomizedTeams.Count);

            model.Rounds.Add(CreateFirstRound(byes, randomizedTeams));
            
            CreateOtherRounds(model, rounds)
        }

        private static void CreateOtherRounds(TournamentModel tournament, int rounds) 
        {
            int round = 2;
            List<MatchupModel> previousRound = tournament.Rounds[0]);
            List<MatchupModel> currentRound = new List<MatchupModel>();
            MatchupModel currentMatchup = new MatchupModel();

            while (round <= rounds)
            {
                foreach (MatchupModel match in previousRound)
                {
                    currentMatchup.Entries.Add(new MatchupEntryModel { ParentMatchup = match });

                    if(currentMatchup.Entries.Count > 1)
                    {
                        currentMatchup.MatchupRound = round;
                        currentRound.Add(currentMatchup);
                        currentMatchup = new  MatchupModel();
                    }
                }

                tournament.Rounds.Add(currentRound);
                previousRound = currentRound;

                currentRound = new List<MatchupModel>();
                round += 1;
            }
        }

        private static List<MatchupModel> CreateFirstRound(int byes, List<TeamModel> teams)
        {
            List<MatchupModel> firstRound = new List<MatchupModel>();
            MatchupModel current = new MatchupModel();

            foreach(TeamModel team in teams)
            {
                current.Entries.Add(new MatchupModel { TeamCompeting = team});

                if(byes > 0 || current.Entries.Count > 1)
                {
                    current.MatchupModel = 1;
                    firstRound.Add(current);
                    current = new MatchupModel();

                    if(byes > 0)
                    {
                        byes -= 1;
                    }
                }
            }
            return firstRound;
        }

        private static int NumberOfByes(int rounds, int numberOfTeams) 
        {

        }

        private static int FindNumberOfRounds(List<TeamModel> teams)
        {
            int rounds = 1;
            int counter = 2;

            while(counter < teams)
            {
                rounds += 1;

                counter *= 2;
            }

            return rounds;
        }

        private static List<TeamModel> RandomizeTeamOrder(List<TeamModel> teams)
        {
            return teams.OrderBy(x => Guid.NewGuid()).ToList();
        }
    }
}