using IguanaBot.Services.Interfaces;
using NUnit.Framework;

namespace IguanaBot.Services.Tests.CoronaTests
{
    [TestFixture]
    public class CoronaServiceProviderTests
    {
        private ICoronaServiceProvider _coronaServiceProvider;

        [SetUp]
        public void InitializeNasaImagesProvider()
        {
            _coronaServiceProvider = ServiceFactory.GetCoronaServiceProvider();
        }

        [Test]
        public void GetGlobalInformation_WorksAsExpected()
        {
            // Act - 
            var globalInformation = _coronaServiceProvider.GetMessageWithGlobalInformation();

            // Assert - 
            Assert.True(globalInformation.Fields.Count >= 3);
        }

        [Test]
        public void GetInformationForGivenCountry_WorksAsExpected()
        {
            // Act - 
            var globalInformation = _coronaServiceProvider.GetMessageWithInformationForGivenCountry("Brazil");

            // Assert - 
            Assert.True(globalInformation.Fields.Count >= 3);
        }

        [Test]
        public void GetAllCountryNames_WorksAsExpected()
        {
            // Act - 
            var globalInformation = _coronaServiceProvider.GetMessageWithAllInfectedCountryNames();

            // Assert - 
            Assert.True(globalInformation.Fields.Count >= 3);
        }
    }
}
