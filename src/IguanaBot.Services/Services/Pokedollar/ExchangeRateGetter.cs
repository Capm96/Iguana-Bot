using Newtonsoft.Json;
using RatesExchangeApi;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace IguanaBot.Services.Services.Pokedollar
{
    // TODO: Error handling.
    public static class ExchangeRateGetter
    {
        public const string TodaysRateBaseURL = "https://free.currconv.com/api/v7/";

        public static string GetTodaysRate(string apiKey)
        {
            var jsonString = RequestTodaysExchangeRateFromAPI(apiKey);
            var resultInformation = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, decimal>>>(jsonString);
            var exchangeRate = resultInformation.First().Value.First().Value;
            return Math.Round(exchangeRate, 2).ToString();
        }

        private static string RequestTodaysExchangeRateFromAPI(string apiKey)
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

        public static async Task<string> GetRateForThisDate(string date, string apiKey)
        {
            var client = new RatesExchangeApiService(apiKey);

            var isoCurrencies = new List<string> { "BRL" };
            var rates = await client.GetHistoryRates("USD", date, isoCurrencies);

            var rate = rates.Rates["BRL"];
            var roundedRate = Math.Round(rate, 2);
            return roundedRate.ToString();
        }
    }
}
