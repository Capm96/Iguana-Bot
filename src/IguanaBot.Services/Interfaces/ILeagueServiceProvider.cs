﻿using System.Collections.Generic;

namespace IguanaBot.Services.Interfaces
{
    public interface ILeagueServiceProvider
    {
        List<string> GetTwoFullyRandomTeams();
        List<string> GetTwoFullyRandomTeamsWithOneADC();
        List<string> GetTwoTeamsWithOneChampionFromEachRole();
        string GetATeamWithOneChampionFromEachRole();
        bool IsThereARepeatedChampion(List<string> team);
        string GetTeamAsSingleString(List<string> team);
        bool TeamsContainRepeteadChampion(List<string> teamOne, List<string> teamTwo);
    }
}