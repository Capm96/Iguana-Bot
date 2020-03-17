using System.Collections.Generic;

namespace IguanaBot.Services.Interfaces
{
    public interface ILeagueServiceProvider
    {
        List<string> GetTwoFullyRandomTeams();
        List<string> GetTwoFullyRandomTeamsWithOneADC();
        List<string> GetTwoTeamsWithOneChampionFromEachRole();
        bool IsThereARepeatedChampion(List<string> team);
        string GetTeamAsSingleString(List<string> team);
    }
}