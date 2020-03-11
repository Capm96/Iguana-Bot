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

        public static List<List<string>> GetTwoFullyRandomTeams()
        {
            var teamOne = GetAFullyRandomTeam();
            var teamTwo = GetAFullyRandomTeam();
            return new List<List<string>>() { teamOne, teamTwo };
        }

        public static List<List<string>> GetTwoFullyRandomTeamsWithOneADC()
        {
            var teamOne = GetAFullyRandomTeamWithOneADC();
            var teamTwo = GetAFullyRandomTeamWithOneADC();
            return new List<List<string>>() { teamOne, teamTwo };
        }

        private static List<string> GetAFullyRandomTeam()
        {
            var randomIndexOne = new Random().Next(1, LeagueChampionsPool.AllChampions.Count);
            var randomIndexTwo = new Random().Next(1, LeagueChampionsPool.AllChampions.Count);
            var randomIndexThree = new Random().Next(1, LeagueChampionsPool.AllChampions.Count);
            var randomIndexFour = new Random().Next(1, LeagueChampionsPool.AllChampions.Count);
            var randomIndexFive = new Random().Next(1, LeagueChampionsPool.AllChampions.Count);

            var teamOne = new List<string>();
            teamOne.Add(LeagueChampionsPool.AllChampions[randomIndexOne]);
            teamOne.Add(LeagueChampionsPool.AllChampions[randomIndexTwo]);
            teamOne.Add(LeagueChampionsPool.AllChampions[randomIndexThree]);
            teamOne.Add(LeagueChampionsPool.AllChampions[randomIndexFour]);
            teamOne.Add(LeagueChampionsPool.AllChampions[randomIndexFive]);

            bool thereIsARepeatedChampion = CheckForRepeatedChamps(teamOne);
            if (thereIsARepeatedChampion)
                return GetAFullyRandomTeam();
            else
                return teamOne;
        }

        private static List<string> GetAFullyRandomTeamWithOneADC()
        {
            var randomIndexOne = new Random().Next(1, LeagueChampionsPool.AllChampions.Count);
            var randomIndexTwo = new Random().Next(1, LeagueChampionsPool.AllChampions.Count);
            var randomIndexThree = new Random().Next(1, LeagueChampionsPool.AllChampions.Count);
            var randomADCIndex = new Random().Next(1, LeagueChampionsPool.ADC.Count);
            var randomIndexFive = new Random().Next(1, LeagueChampionsPool.AllChampions.Count);

            var teamOne = new List<string>();
            teamOne.Add(LeagueChampionsPool.AllChampions[randomIndexOne]);
            teamOne.Add(LeagueChampionsPool.AllChampions[randomIndexTwo]);
            teamOne.Add(LeagueChampionsPool.AllChampions[randomIndexThree]);
            teamOne.Add(LeagueChampionsPool.ADC[randomADCIndex]);
            teamOne.Add(LeagueChampionsPool.AllChampions[randomIndexFive]);

            bool thereIsARepeatedChampion = CheckForRepeatedChamps(teamOne);
            if (thereIsARepeatedChampion)
                return GetAFullyRandomTeamWithOneADC();
            else
                return teamOne;
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
