using IguanaBot.Services.Services.Corona;
using NUnit.Framework;

namespace IguanaBot.Services.Tests.CoronaTests
{
    [TestFixture]
    public class CoronaInformationProviderTests
    {
        [Test]
        public void GetGlobalInformation_WorksAsExpected()
        {
            // Arrange - 
            var provider = new CoronaInformationProvider();

            // Act - 
            var globalInformation = provider.GetMessageWithGlobalInformation();

            // Assert - 
            Assert.True(globalInformation.Fields.Count >= 3);
        }

        [Test]
        public void GetInformationForGivenCountry_WorksAsExpected()
        {
            // Arrange - 
            var provider = new CoronaInformationProvider();

            // Act - 
            var globalInformation = provider.GetMessageWithInformationForGivenCountry("Brazil");

            // Assert - 
            Assert.True(globalInformation.Fields.Count >= 3);
        }

        [Test]
        public void GetAllCountryNames_WorksAsExpected()
        {
            // Arrange - 
            var provider = new CoronaInformationProvider();

            // Act - 
            var globalInformation = provider.GetMessageWithAllInfectedCountryNames();

            // Assert - 
            Assert.True(globalInformation.Fields.Count >= 3);
        }
    }
}
