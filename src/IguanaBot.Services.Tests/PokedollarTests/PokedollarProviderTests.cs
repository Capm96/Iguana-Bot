using IguanaBot.Services.Pokedollar;
using IguanaBot.Services.Pokedollar.Interfaces;
using NUnit.Framework;
using System.Threading.Tasks;

namespace IguanaBot.Services.Tests.PokedollarTests
{
    [TestFixture]
    public class PokedollarProviderTests
    {
        private IPokedollarProvider _pokeDollarProvider;

        [SetUp]
        public void InitializeProvider()
        {
            _pokeDollarProvider = new PokedollarProvider();
        }

        [Test]
        public void GetPokemonName_WorksAsExpected()
        {
            // Arrange - 
            var targetPokemonOne = AllPokemons.AllPokemonNames[100];
            var targetPokemonTwo = AllPokemons.AllPokemonNames[250];
            var targetPokemonThree = AllPokemons.AllPokemonNames[475];

            var rateOne = "1.00";
            var rateTwo = "2.50";
            var rateThree = "4.75";

            // Act - 
            var actualPokemonOne = _pokeDollarProvider.GetPokemonName(rateOne);
            var actualPokemonTwo = _pokeDollarProvider.GetPokemonName(rateTwo);
            var actualPokemonThree = _pokeDollarProvider.GetPokemonName(rateThree);

            // Assert -
            Assert.AreEqual(targetPokemonOne, actualPokemonOne);
            Assert.AreEqual(targetPokemonTwo, actualPokemonTwo);
            Assert.AreEqual(targetPokemonThree, actualPokemonThree);
        }

        [TestCase("4.6555", "465")]
        [TestCase("3.4312", "343")]
        [TestCase("1.5312", "153")]
        public void GetPokedexNumber_WorksAsExpected(string rate, string expected)
        {
            // Act - 
            var actual = _pokeDollarProvider.GetPokedexNumberFromRate(rate);

            // Assert -
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetPokemonImageLink_WorksAsExpected()
        {
            // Arrange -
            var imageLink = string.Empty;

            // Act - 
            imageLink = _pokeDollarProvider.GetPokemonImageLink("Pikachu");

            // Assert -
            Assert.True(imageLink.Length > 0);
        }

        [Test]
        public void GetExchangeRateForToday_WorksAsExpected()
        {
            // Arrange - 
            var exchangeRate = string.Empty;

            // Act -
            exchangeRate = _pokeDollarProvider.GetTodaysExchangeRate();

            // Assert -
            Assert.IsTrue(exchangeRate.Length > 0);
        }

        [Test]
        public async Task GetExchangeRateForGivenDate_WorksAsExpected()
        {
            // Arrange - 
            var exchangeRate = string.Empty;

            // Act -
            exchangeRate = await _pokeDollarProvider.GetExchangeRateForThisDate("2020-03-09");

            // Assert -
            Assert.IsTrue(exchangeRate.Length > 0);
        }
    }
}
