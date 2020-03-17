using IguanaBot.Services.Interfaces;
using NUnit.Framework;
using System.Threading.Tasks;

namespace IguanaBot.Services.Tests.PokedollarTests
{
    [TestFixture]
    public class PokedollarServiceProviderTests
    {
        private IPokedollarServiceProvider _pokedollarServiceProvider;

        [SetUp]
        public void InitializeProvider()
        {
            _pokedollarServiceProvider = ServiceFactory.GetPokedollarServiceProvider();
        }

        [Test]
        public void GetExchangeRateForToday_WorksAsExpected()
        {
            // Act -
            var exchangeRate = _pokedollarServiceProvider.GetTodaysExchangeRate();

            // Assert -
            Assert.IsTrue(exchangeRate.Title.Length > 0);
            Assert.IsTrue(exchangeRate.ImageUrl.Length > 0);
            Assert.IsTrue(exchangeRate.Description.Length > 0);
        }

        // TODO: Figure out what is wrong -- historic exchange rates not being picked up.
        [Test]
        public async Task GetExchangeRateForGivenDate_WorksAsExpected()
        {
            // Act -
            var exchangeRate = await _pokedollarServiceProvider.GetExchangeRateForThisDate("2020-03-17");

            // Assert -
            Assert.IsTrue(exchangeRate.Title.Length > 0);
            Assert.IsTrue(exchangeRate.ImageUrl.Length > 0);
            Assert.IsTrue(exchangeRate.Description.Length > 0);
        }
    }
}
