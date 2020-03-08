using IguanaBot.JsonHandler;
using Newtonsoft.Json;
using System.IO;
using System.Text;

namespace IguanaBot.Services.JsonHandler
{
    public static class MyJsonReader
    {
        public static JsonConfiguration GetJsonConfigurationWithTokensInformation()
        {
            var json = string.Empty;

            using (var fs = File.OpenRead("config.json"))
                using (var streamReader = new StreamReader(fs, new UTF8Encoding(false)))
                    json = streamReader.ReadToEnd();

            return JsonConvert.DeserializeObject<JsonConfiguration>(json);
        }
    }
}
