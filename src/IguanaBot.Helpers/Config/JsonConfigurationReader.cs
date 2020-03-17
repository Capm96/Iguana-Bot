using IguanaBot.Entities.Config;
using Newtonsoft.Json;
using System.IO;
using System.Text;

namespace IguanaBot.Helpers.Config
{
    public static class JsonConfigurationReader
    {
        public static JsonConfiguration GetJsonConfigurationWithMyTokens()
        {
            var json = string.Empty;

            using (var fs = File.OpenRead("config.json"))
            using (var streamReader = new StreamReader(fs, new UTF8Encoding(false)))
                json = streamReader.ReadToEnd();

            return JsonConvert.DeserializeObject<JsonConfiguration>(json);
        }
    }
}
