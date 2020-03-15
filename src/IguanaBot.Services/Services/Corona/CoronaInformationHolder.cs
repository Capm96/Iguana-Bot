using Newtonsoft.Json;

namespace IguanaBot.Services.Services.Corona
{
    public class CoronaInformationHolder
    {
        [JsonProperty("cases")]
        public int Cases { get; private set; }

        [JsonProperty("todayCases")]
        public int TodayCases { get; private set; }

        [JsonProperty("deaths")]
        public int Deaths { get; private set; }

        [JsonProperty("todayDeaths")]
        public int TodayDeaths { get; private set; }

        [JsonProperty("recovered")]
        public int Recovered { get; private set; }

        [JsonProperty("critical")]
        public int Critical { get; private set; }

        [JsonProperty("country")]
        public string Country { get; private set; }
    }
}
