using IguanaBot.Helpers.Validators;
using Newtonsoft.Json;
using RatesExchangeApi;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace IguanaBot.Services.Pokedollar
{
    public static class ExchangeRateGetter
    {
        public const string TodaysRateBaseURL = "https://free.currconv.com/api/v7/";

        public static string GetExchangeRateForToday(string apiKey)
        {
            var jsonString = GetTodaysInformationFromAPI(apiKey);
            var resultInformation = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, decimal>>>(jsonString);
            var exchangeRate = resultInformation.First().Value.First().Value;
            return RoundedRate(exchangeRate);
        }

        public static async Task<string> GetExchangeRateForGivenDate(string date, string apiKey)
        {
            GetEarliestWeekdayIfDateIsOnWeekend(ref date); // API was not getting exchange rates properly when date was a weekend.
            var rate = await GetExchangeRateForDate(date, apiKey);
            return RoundedRate(rate);
        }

        private static string GetTodaysInformationFromAPI(string apiKey)
        {
            var today = DateTime.Now.ToString("yyyy-MM-dd h:mm tt").Substring(0, 10);
            var requestURL = TodaysRateBaseURL + $@"convert?q=USD_BRL&compact=ultra&date={today}&apiKey={apiKey}";
            var request = (HttpWebRequest)WebRequest.Create(requestURL);

            string jsonString;
            using (var response = (HttpWebResponse)request.GetResponse())
            using (var stream = response.GetResponseStream())
            using (var reader = new StreamReader(stream))
                jsonString = reader.ReadToEnd();
            return jsonString;
        }

        private static string RoundedRate(decimal exchangeRate)
        {
            return Math.Round(exchangeRate, 2).ToString();
        }

        private static void GetEarliestWeekdayIfDateIsOnWeekend(ref string date)
        {
            if (DateValidator.IsWeekend(date))
                DateValidator.GetEarliestWeekday(ref date);
        }

        private static async Task<decimal> GetExchangeRateForDate(string date, string apiKey)
        {
            var client = new RatesExchangeApiService(apiKey);
            var isoCurrencies = new List<string> { "BRL" };
            var rates = await client.GetHistoryRates("USD", date, isoCurrencies);
            var rate = rates.Rates["BRL"];
            return rate;
        }
    }
}
