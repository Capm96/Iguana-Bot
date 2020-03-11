using IguanaBot.Services.Helpers;
using NUnit.Framework;

namespace IguanaBot.Services.Tests.HelpersTests
{
    [TestFixture]
    public class DateValidatorTests
    {
        [TestCase("2020/01/01", false)]
        [TestCase("2050-01-01", false)]
        [TestCase("2020a-01-01", false)]
        [TestCase("2010-30-01", false)]
        [TestCase("2015-02-30", false)]
        [TestCase("2015-00-00", false)]
        [TestCase("2015-02-30", false)]
        [TestCase("2020-01-01", true)]
        [TestCase("2000-01-01", true)]
        [TestCase("2000-1-1", false)]
        public void DataValidator_WorksAsExpected(string date, bool expected)
        {
            // Act -
            bool actual = DateValidator.CheckIfDataIsValid(date);

            // Assert -
            Assert.AreEqual(expected, actual);
        }
    }
}
