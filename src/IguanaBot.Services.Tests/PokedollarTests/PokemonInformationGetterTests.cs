using IguanaBot.Helpers.Config;
using IguanaBot.Services.Pokedollar;
using NUnit.Framework;

namespace IguanaBot.Services.Tests.PokedollarTests
{
    [TestFixture]
    public class PokemonInformationGetterTests
    {
        [TestCase("4.6555", 465)]
        [TestCase("3.4312", 343)]
        [TestCase("1.5312", 153)]
        public void GetPokedexNumber_WorksAsExpected(string rate, int expected)
        {
            // Act - 
            var actual = PokemonInformationGetter.GetPokedexNumberFromRate(rate);

            // Assert -
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetPokemonImageLink_WorksAsExpected()
        {
            // Arrange -
            var imageLink = string.Empty;
            var configJson = JsonConfigurationReader.GetJsonConfigurationWithMyTokens();

            // Act - 
            imageLink = PokemonInformationGetter.GetPokemonImageLink(configJson.SearchToken, configJson.SearchEngineId, "Pikachu");

            // Assert -
            Assert.True(imageLink.Length > 0);
        }
    }
}
