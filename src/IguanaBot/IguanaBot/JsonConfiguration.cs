using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace IguanaBot
{
    public struct JsonConfiguration
    {
        [JsonProperty("token")]
        public string Token { get; private set; }

        [JsonProperty("prefix")]
        public string Prefix { get; private set; }
    }
}
