using Newtonsoft.Json;

namespace IguanaBot.Entities.Corona
{
    public class CoronaBaseInformation
    {
        [JsonProperty("cases")]
        public int Cases { get; private set; }

        [JsonProperty("deaths")]
        public int Deaths { get; private set; }

        [JsonProperty("recovered")]
        public int Recovered { get; private set; }
    }
}
