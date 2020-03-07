using System;
using System.Collections.Generic;
using System.Text;

namespace IguanaBot
{
    public static class LeagueFiveVersusFiveMatchMaker
    {
        public static List<List<string>> GetOneChampionFromEachRole()
        {
            // Team one.
            var teamOne = GetATeam();
            var teamTwo = GetATeam();

            return new List<List<string>>() { teamOne, teamTwo };
        }

        private static List<string> GetATeam()
        {
            var randomTopIndex = new Random().Next(1, LeagueChampionsPool.Top.Count);
            var randomJungleIndex = new Random().Next(1, LeagueChampionsPool.Jungle.Count);
            var randomMidIndex = new Random().Next(1, LeagueChampionsPool.Mid.Count);
            var randomAdIndex = new Random().Next(1, LeagueChampionsPool.ADCarries.Count);
            var randomSupIndex = new Random().Next(1, LeagueChampionsPool.Supports.Count);

            var teamOne = new List<string>();
            teamOne.Add(LeagueChampionsPool.Top[randomTopIndex]);
            teamOne.Add(LeagueChampionsPool.Jungle[randomJungleIndex]);
            teamOne.Add(LeagueChampionsPool.Mid[randomMidIndex]);
            teamOne.Add(LeagueChampionsPool.ADCarries[randomAdIndex]);
            teamOne.Add(LeagueChampionsPool.Supports[randomSupIndex]);

            return teamOne;
        }
    }
}
