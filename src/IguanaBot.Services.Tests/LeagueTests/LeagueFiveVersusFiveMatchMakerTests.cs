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
            Assert.True(teams[0].Length > 0);
            Assert.True(teams[1].Length > 0);
        }

        [Test]
        public void GetTwoFullyRandomTeams_WorksAsExpected()
        {
            // Act - 
            var teams = LeagueFiveVersusFiveMatchMaker.GetTwoFullyRandomTeams();

            // Assert -
            Assert.True(teams.Count == 2);
            Assert.True(teams[0].Length > 0);
            Assert.True(teams[1].Length > 0);
        }

        [Test]
        public void GetTwoFullyRandomTeamsWithADC_WorksAsExpected()
        {
            // Act - 
            var teams = LeagueFiveVersusFiveMatchMaker.GetTwoFullyRandomTeamsWithOneADC();

            // Assert -
            Assert.True(teams.Count == 2);
            Assert.True(teams[0].Length > 0);
            Assert.True(teams[1].Length > 0);
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
            bool teamOneIsRepeated = LeagueFiveVersusFiveMatchMaker.IsThereARepeatedChampion(teamOne);
            bool teamTwoIsRepeated = LeagueFiveVersusFiveMatchMaker.IsThereARepeatedChampion(teamTwo);

            // Assert - 
            Assert.True(teamOneIsRepeated);
            Assert.False(teamTwoIsRepeated);
        }

        [Test]
        public void GetTeamAsSingleString_WorksAsExpected()
        {
            // Arrange - 
            var team = new List<string>()
            {
                "champ",
                "champ 1",
                "champ 2",
            };

            var expected = "champ\n" + "champ 1\n" + "champ 2\n";

            // Act -
            var actual = LeagueFiveVersusFiveMatchMaker.GetTeamAsSingleString(team);

            // Assert - 
            Assert.AreEqual(expected, actual);
        }
    }
}
