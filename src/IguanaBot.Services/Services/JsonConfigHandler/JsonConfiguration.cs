using Newtonsoft.Json;

namespace IguanaBot.JsonHandler
{
    public struct JsonConfiguration
    {
        [JsonProperty("discordToken")]
        public string DiscordToken { get; private set; }

        [JsonProperty("nasaToken")]
        public string NasaToken { get; private set; }

        [JsonProperty("todaysExchangeRateToken")]
        public string TodaysExchangeRateToken { get; private set; }

        [JsonProperty("historicExchangeRateToken")]
        public string HistoricExchangeRateToken { get; private set; }

        [JsonProperty("searchEngineId")]
        public string SearchEngineId { get; private set; }

        [JsonProperty("searchToken")]
        public string SearchToken { get; private set; }

        [JsonProperty("prefix")]
        public string Prefix { get; private set; }
    }
}
