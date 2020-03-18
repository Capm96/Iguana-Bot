using IguanaBot.Services.Interfaces;
using NUnit.Framework;
using System.Collections.Generic;

namespace IguanaBot.Services.Tests.LeagueTests
{
    [TestFixture]
    public class LeagueServiceProviderTests
    {
        private ILeagueServiceProvider _leagueServiceProvider;

        [SetUp]
        public void InitializeNasaImagesProvider()
        {
            _leagueServiceProvider = ServiceFactory.GetLeagueServiceProvider();
        }

        [Test]
        public void GetTwoTeamsWithOneChampionFromEachRole_WorksAsExpected()
        {
            // Act - 
            var teams = _leagueServiceProvider.GetTwoTeamsWithOneChampionFromEachRole();

            // Assert -
            Assert.True(teams.Count == 2);
            Assert.True(teams[0].Length > 0);
            Assert.True(teams[1].Length > 0);
        }

        [Test]
        public void GetTwoFullyRandomTeams_WorksAsExpected()
        {
            // Act - 
            var teams = _leagueServiceProvider.GetTwoFullyRandomTeams();

            // Assert -
            Assert.True(teams.Count == 2);
            Assert.True(teams[0].Length > 0);
            Assert.True(teams[1].Length > 0);
        }

        [Test]
        public void GetTwoFullyRandomTeamsWithADC_WorksAsExpected()
        {
            // Act - 
            var teams = _leagueServiceProvider.GetTwoFullyRandomTeamsWithOneADC();

            // Assert -
            Assert.True(teams.Count == 2);
            Assert.True(teams[0].Length > 0);
            Assert.True(teams[1].Length > 0);
        }

        [Test]
        public void GetOneTeamForNormalGame_WorksAsExpected()
        {
            // Arrange - 
            var test = string.Empty;

            // Act - 
            test = _leagueServiceProvider.GetATeamWithOneChampionFromEachRole();

            // Assert -
            Assert.True(test.Length > 20);
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
            bool teamOneIsRepeated = _leagueServiceProvider.IsThereARepeatedChampion(teamOne);
            bool teamTwoIsRepeated = _leagueServiceProvider.IsThereARepeatedChampion(teamTwo);

            // Assert - 
            Assert.True(teamOneIsRepeated);
            Assert.False(teamTwoIsRepeated);
        }

        [Test]
        public void CheckForRepeatedChampionsWithinTwoTeams_WorksAsExpected()
        {
            // Arrange - 
            var teamOne = new List<string>()
            {
                "champ",
                "champ 1",
            };

            var teamTwo = new List<string>()
            {
                "champ",
                "champ 1",
            };

            var teamThree = new List<string>()
            {
                "champ 5",
                "champ 6",
            };

            var teamFour = new List<string>()
            {
                "champ 7",
                "champ 8",
            };

            // Act -
            bool teamsOneAndTwoAreRepeated = _leagueServiceProvider.TeamsContainRepeteadChampion(teamOne, teamTwo);
            bool teamsThreeAndFourAreRepeated = _leagueServiceProvider.TeamsContainRepeteadChampion(teamThree, teamFour);

            // Assert - 
            Assert.True(teamsOneAndTwoAreRepeated);
            Assert.False(teamsThreeAndFourAreRepeated);
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
            var actual = _leagueServiceProvider.GetTeamAsSingleString(team);

            // Assert - 
            Assert.AreEqual(expected, actual);
        }
    }
}
