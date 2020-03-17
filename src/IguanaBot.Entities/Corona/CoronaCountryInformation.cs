using Newtonsoft.Json;

namespace IguanaBot.Entities.Corona
{
    public class CoronaCountryInformation : CoronaBaseInformation
    {
        [JsonProperty("todayCases")]
        public int TodayCases { get; private set; }

        [JsonProperty("todayDeaths")]
        public int TodayDeaths { get; private set; }

        [JsonProperty("critical")]
        public int Critical { get; private set; }

        [JsonProperty("country")]
        public string Name { get; private set; }
    }
}
