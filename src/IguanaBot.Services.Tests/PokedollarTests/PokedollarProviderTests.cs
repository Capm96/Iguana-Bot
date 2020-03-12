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
        public void GetExchangeRateForToday_WorksAsExpected()
        {
            // Act -
            var exchangeRate = _pokeDollarProvider.GetTodaysExchangeRate();

            // Assert -
            Assert.IsTrue(exchangeRate.Title.Length > 0);
            Assert.IsTrue(exchangeRate.ImageUrl.Length > 0);
            Assert.IsTrue(exchangeRate.Description.Length > 0);
        }

        [Test]
        public async Task GetExchangeRateForGivenDate_WorksAsExpected()
        {
            // Act -
            var exchangeRate = await _pokeDollarProvider.GetExchangeRateForThisDate("2020-03-09");

            // Assert -
            Assert.IsTrue(exchangeRate.Title.Length > 0);
            Assert.IsTrue(exchangeRate.ImageUrl.Length > 0);
            Assert.IsTrue(exchangeRate.Description.Length > 0);
        }
    }
}
