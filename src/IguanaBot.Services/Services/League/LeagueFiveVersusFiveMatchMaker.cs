using IguanaBot.Serivces.League;
using System;
using System.Collections.Generic;

namespace IguanaBot.Services.League
{
    public static class LeagueFiveVersusFiveMatchMaker
    {
        public static List<string> GetTwoTeamsWithOneChampionFromEachRole()
        {
            var teamOne = GetTeamWithOneChampionFromEachRole();
            var teamTwo = GetTeamWithOneChampionFromEachRole();
            return new List<string>() { GetTeamAsSingleString(teamOne), GetTeamAsSingleString(teamTwo) };
        }

        public static List<string> GetTwoFullyRandomTeams()
        {
            var teamOne = GetAFullyRandomTeam(5);
            var teamTwo = GetAFullyRandomTeam(5);
            return new List<string>() { GetTeamAsSingleString(teamOne), GetTeamAsSingleString(teamTwo) };
        }

        public static List<string> GetTwoFullyRandomTeamsWithOneADC()
        {
            var teamOne = GetAFullyRandomTeamWithOneADC();
            var teamTwo = GetAFullyRandomTeamWithOneADC();
            return new List<string>() { GetTeamAsSingleString(teamOne), GetTeamAsSingleString(teamTwo) };
        }

        public static bool IsThereARepeatedChampion(List<string> teamOne)
        {
            foreach (var champion in teamOne)
                if (teamOne.FindAll(x => x == champion).Count >= 2)
                    return true;

            return false;
        }

        public static string GetTeamAsSingleString(List<string> team)
        {
            var output = "";

            foreach (var champion in team)
                output += champion + "\n";

            return output;
        }

        private static List<string> GetTeamWithOneChampionFromEachRole()
        {
            var team = new List<string>();

            var randomTopIndex = new Random().Next(1, LeagueChampionsPool.Top.Count);
            team.Add($"Top: {LeagueChampionsPool.Top[randomTopIndex]}");
            var randomJungleIndex = new Random().Next(1, LeagueChampionsPool.Jungle.Count);
            team.Add($"Jungle: {LeagueChampionsPool.Jungle[randomJungleIndex]}");
            var randomMidIndex = new Random().Next(1, LeagueChampionsPool.Mid.Count);
            team.Add($"Mid: {LeagueChampionsPool.Mid[randomMidIndex]}");
            var randomAdIndex = new Random().Next(1, LeagueChampionsPool.ADC.Count);
            team.Add($"ADC: {LeagueChampionsPool.ADC[randomAdIndex]}");
            var randomSupIndex = new Random().Next(1, LeagueChampionsPool.Support.Count);
            team.Add($"Support: {LeagueChampionsPool.Support[randomSupIndex]}");

            return IsThereARepeatedChampion(team) ? GetTeamWithOneChampionFromEachRole() : team;
        }

        private static List<string> GetAFullyRandomTeam(int numberOfChampions)
        {
            var team = new List<string>();

            for (int i = 0; i < numberOfChampions; i++)
            {
                var randomIndex = new Random().Next(1, LeagueChampionsPool.AllChampions.Count);
                team.Add(LeagueChampionsPool.AllChampions[randomIndex]);
            }

            return IsThereARepeatedChampion(team) ? GetAFullyRandomTeam(numberOfChampions) : team;
        }

        private static List<string> GetAFullyRandomTeamWithOneADC()
        {
            var team = GetAFullyRandomTeam(4);

            var randomADCIndex = new Random().Next(1, LeagueChampionsPool.ADC.Count);
            team.Add(LeagueChampionsPool.ADC[randomADCIndex]);

            return team;
        }
    }
}
