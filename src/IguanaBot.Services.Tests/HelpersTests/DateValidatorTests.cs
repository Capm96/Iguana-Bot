using IguanaBot.Services.Helpers;
using NUnit.Framework;

namespace IguanaBot.Services.Tests.HelpersTests
{
    [TestFixture]
    public class DateValidatorTests
    {
        [TestCase("2020/01/01", false)]
        [TestCase("2050-01-01", false)]
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

        [TestCase("2020-03-12", false)]
        [TestCase("2050-03-11", false)]
        [TestCase("2020-03-08", true)]
        [TestCase("2010-03-07", true)]
        [TestCase("2015-03-06", false)]
        public void CheckIfItsWeekened_WorksAsExpected(string date, bool expected)
        {
            // Act -
            bool actual = DateValidator.IsWeekend(date);

            // Assert -
            Assert.AreEqual(expected, actual);
        }

        [TestCase("2020-03-08", "2020-03-06")]
        [TestCase("2020-03-07", "2020-03-06")]
        public void GetEarliestWeekday_WorksAsExpected(string date, string expected)
        {
            // Act -
            DateValidator.GetEarliestWeekday(ref date);

            // Assert -
            Assert.AreEqual(expected, date);
        }
    }
}
