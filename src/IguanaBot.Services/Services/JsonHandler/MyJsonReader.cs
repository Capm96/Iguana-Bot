using IguanaBot.JsonHandler;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace IguanaBot.Services.JsonHandler
{
    public static class MyJsonReader
    {
        public static async Task<JsonConfiguration> ReadJsonConfig()
        {
            var json = string.Empty;

            using (var fs = File.OpenRead("config.json"))
            {
                using (var streamReader = new StreamReader(fs, new UTF8Encoding(false)))
                {
                    json = await streamReader.ReadToEndAsync().ConfigureAwait(false);
                }
            }

            return JsonConvert.DeserializeObject<JsonConfiguration>(json);
        }
    }
}
