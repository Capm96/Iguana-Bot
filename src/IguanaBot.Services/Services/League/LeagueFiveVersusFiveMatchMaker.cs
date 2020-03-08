using IguanaBot.Serivces.League;
using System;
using System.Collections.Generic;

namespace IguanaBot.Services.League
{
    public static class LeagueFiveVersusFiveMatchMaker
    {
        public static List<List<string>> GetTwoTeamsWithOneChampionFromEachRole()
        {
            var teamOne = GetTeamWithOneChampionFromEachRole();
            var teamTwo = GetTeamWithOneChampionFromEachRole();
            return new List<List<string>>() { teamOne, teamTwo };
        }

        private static List<string> GetTeamWithOneChampionFromEachRole()
        {
            var randomTopIndex = new Random().Next(1, LeagueChampionsPool.Top.Count);
            var randomJungleIndex = new Random().Next(1, LeagueChampionsPool.Jungle.Count);
            var randomMidIndex = new Random().Next(1, LeagueChampionsPool.Mid.Count);
            var randomAdIndex = new Random().Next(1, LeagueChampionsPool.ADC.Count);
            var randomSupIndex = new Random().Next(1, LeagueChampionsPool.Support.Count);

            var teamOne = new List<string>();
            teamOne.Add($"Top: {LeagueChampionsPool.Top[randomTopIndex]}");
            teamOne.Add($"Jungle: {LeagueChampionsPool.Jungle[randomJungleIndex]}");
            teamOne.Add($"Mid: {LeagueChampionsPool.Mid[randomMidIndex]}");
            teamOne.Add($"ADC: {LeagueChampionsPool.ADC[randomAdIndex]}");
            teamOne.Add($"Support: {LeagueChampionsPool.Support[randomSupIndex]}");

            bool thereIsARepeatedChampion = CheckForRepeatedChamps(teamOne);
            if (thereIsARepeatedChampion)
                return GetTeamWithOneChampionFromEachRole();
            else
                return teamOne;
        }

        public static bool CheckForRepeatedChamps(List<string> teamOne)
        {
            foreach (var champion in teamOne)
                if (teamOne.FindAll(x => x == champion).Count >= 2)
                    return true;

            return false;
        }
    }
}
