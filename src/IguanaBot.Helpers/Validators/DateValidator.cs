using System;
using System.Text.RegularExpressions;

namespace IguanaBot.Helpers.Validators
{
    public static class DateValidator
    {
        public static bool CheckIfDataIsValid(string date)
        {
            var dateFormatRegex = new Regex(@"^\d{4}-((0[1-9])|(1[012]))-((0[1-9]|[12]\d)|3[01])$");
            var dateIsInCorrectFormat = dateFormatRegex.IsMatch(date);
            return dateIsInCorrectFormat ? DateExists(date) : false;
        }

        public static bool IsWeekend(string date)
        {
            var dateTime = DateTime.Parse(date);
            return dateTime.DayOfWeek == DayOfWeek.Saturday || dateTime.DayOfWeek == DayOfWeek.Sunday;
        }

        public static void GetEarliestWeekday(ref string date)
        {
            var dateTime = DateTime.Parse(date);

            DateTime newDateTime;
            if (dateTime.DayOfWeek == DayOfWeek.Saturday)
                newDateTime = dateTime.Date - TimeSpan.FromDays(1);
            else
                newDateTime = dateTime.Date.AddDays(-2);

            date = newDateTime.ToString("yyyy-MM-dd h:mm tt").Substring(0, 10);
        }

        private static bool DateExists(string date)
        {
            var dateTime = new DateTime();
            var dateCanBeParsed = DateTime.TryParse(date, out dateTime);
            return dateCanBeParsed ? DateIsValid(dateTime) : false;
        }

        private static bool DateIsValid(DateTime dateTime)
        {
            return dateTime <= DateTime.Today ? true : false;
        }
    }
}
