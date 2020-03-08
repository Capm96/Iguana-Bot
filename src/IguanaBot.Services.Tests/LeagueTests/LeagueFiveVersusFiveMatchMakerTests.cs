using IguanaBot.Services.League;
using NUnit.Framework;
using System.Collections.Generic;

namespace IguanaBot.Services.Tests.LeagueTests
{
    [TestFixture]
    public class LeagueFiveVersusFiveMatchMakerTests
    {
        [Test]
        public void GetTwoTeamsWithOneChampionFromEachRole_WorksAsExpected()
        {
            // Act - 
            var teams = LeagueFiveVersusFiveMatchMaker.GetTwoTeamsWithOneChampionFromEachRole();

            // Assert -
            Assert.True(teams.Count == 2);
            Assert.True(teams[0].Count == 5);
            Assert.True(teams[1].Count == 5);
        }

        [Test]
        public void CheckForRepeatedChamps_WorksAsExpected()
        {
            // Arrange - 
            var teamOne = new List<string>()
            {
                "champ",
                "champ",
                "champ 1",
            };

            var teamTwo = new List<string>()
            {
                "champ",
                "champ 1",
                "champ 2",
            };

            // Act -
            bool teamOneIsRepeated = LeagueFiveVersusFiveMatchMaker.CheckForRepeatedChamps(teamOne);
            bool teamTwoIsRepeated = LeagueFiveVersusFiveMatchMaker.CheckForRepeatedChamps(teamTwo);

            // Assert - 
            Assert.True(teamOneIsRepeated);
            Assert.False(teamTwoIsRepeated);
        }
    }
}
