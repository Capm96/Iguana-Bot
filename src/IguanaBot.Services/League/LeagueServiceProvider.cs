using IguanaBot.Entities.League;
using IguanaBot.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace IguanaBot.Services.League
{
    public class LeagueServiceProvider : ILeagueServiceProvider
    {
        public List<string> GetTwoTeamsWithOneChampionFromEachRole()
        {
            var teamOne = GetTeamWithOneChampionFromEachRole();
            var teamTwo = GetTeamWithOneChampionFromEachRole();
            return new List<string>() { GetTeamAsSingleString(teamOne), GetTeamAsSingleString(teamTwo) };
        }

        public List<string> GetTwoFullyRandomTeams()
        {
            var teamOne = GetAFullyRandomTeam(5);
            var teamTwo = GetAFullyRandomTeam(5);
            return new List<string>() { GetTeamAsSingleString(teamOne), GetTeamAsSingleString(teamTwo) };
        }

        public List<string> GetTwoFullyRandomTeamsWithOneADC()
        {
            var teamOne = GetAFullyRandomTeamWithOneADC();
            var teamTwo = GetAFullyRandomTeamWithOneADC();
            return new List<string>() { GetTeamAsSingleString(teamOne), GetTeamAsSingleString(teamTwo) };
        }

        public bool IsThereARepeatedChampion(List<string> teamOne)
        {
            foreach (var champion in teamOne)
                if (teamOne.FindAll(x => x == champion).Count >= 2)
                    return true;

            return false;
        }

        public string GetTeamAsSingleString(List<string> team)
        {
            var output = "";

            foreach (var champion in team)
                output += champion + "\n";

            return output;
        }

        private List<string> GetTeamWithOneChampionFromEachRole()
        {
            var team = new List<string>();

            var randomTopIndex = new Random().Next(1, ChampionPools.Top.Count);
            team.Add($"Top: {ChampionPools.Top[randomTopIndex]}");
            var randomJungleIndex = new Random().Next(1, ChampionPools.Jungle.Count);
            team.Add($"Jungle: {ChampionPools.Jungle[randomJungleIndex]}");
            var randomMidIndex = new Random().Next(1, ChampionPools.Mid.Count);
            team.Add($"Mid: {ChampionPools.Mid[randomMidIndex]}");
            var randomAdIndex = new Random().Next(1, ChampionPools.ADC.Count);
            team.Add($"ADC: {ChampionPools.ADC[randomAdIndex]}");
            var randomSupIndex = new Random().Next(1, ChampionPools.Support.Count);
            team.Add($"Support: {ChampionPools.Support[randomSupIndex]}");

            return IsThereARepeatedChampion(team) ? GetTeamWithOneChampionFromEachRole() : team;
        }

        private List<string> GetAFullyRandomTeam(int numberOfChampions)
        {
            var team = new List<string>();

            for (int i = 0; i < numberOfChampions; i++)
            {
                var randomIndex = new Random().Next(1, ChampionPools.AllChampions.Count);
                team.Add(ChampionPools.AllChampions[randomIndex]);
            }

            return IsThereARepeatedChampion(team) ? GetAFullyRandomTeam(numberOfChampions) : team;
        }

        private List<string> GetAFullyRandomTeamWithOneADC()
        {
            var team = GetAFullyRandomTeam(4);

            var randomADCIndex = new Random().Next(1, ChampionPools.ADC.Count);
            team.Add(ChampionPools.ADC[randomADCIndex]);

            return team;
        }
    }
}
