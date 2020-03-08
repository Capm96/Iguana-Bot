using Newtonsoft.Json;

namespace IguanaBot.JsonHandler
{
    public struct JsonConfiguration
    {
        [JsonProperty("discordToken")]
        public string DiscordToken { get; private set; }

        [JsonProperty("nasaToken")]
        public string NasaToken { get; private set; }

        [JsonProperty("financeToken")]
        public string PokedollarToken { get; private set; }

        [JsonProperty("prefix")]
        public string Prefix { get; private set; }
    }
}
