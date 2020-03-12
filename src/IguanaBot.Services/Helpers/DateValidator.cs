using DSharpPlus.CommandsNext;
using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace IguanaBot.Services.Helpers
{
    public static class DateValidator
    {
        public static bool CheckIfDataIsValid(string date)
        {
            var dateFormatRegex = new Regex(@"^\d{4}-((0[1-9])|(1[012]))-((0[1-9]|[12]\d)|3[01])$");
            var dateIsInCorrectFormat = dateFormatRegex.IsMatch(date);
            return dateIsInCorrectFormat ? DateExists(date) : false;
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

        public static async Task AlertUserThereWasAnErrorWithTheDate(CommandContext ctx)
        {
            await ctx.Channel.SendMessageAsync("Houve um erro com a data selecionada.");
            await ctx.Channel.SendMessageAsync("Por favor escolha alguma data no formato: ano-mês-dia (2020-01-01)");
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
    }
}
