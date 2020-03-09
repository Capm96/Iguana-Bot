using System;
using System.Drawing.Imaging;
using System.IO;
using System.Threading.Tasks;
using Apod;
using DSharpPlus.Entities;
using IguanaBot.JsonHandler;
using IguanaBot.Services.JsonHandler;

namespace IguanaBot.Services.Nasa
{
    public class NasaImagesProvider
    {
        public ApodClient ApodClient { get; set; }
        public JsonConfiguration JsonConfiguration { get; set; }
        public string LocalImagePath { get; set; }

        public NasaImagesProvider()
        {
            JsonConfiguration = MyJsonReader.GetJsonConfigurationWithTokensInformation();
            ApodClient = new ApodClient(JsonConfiguration.NasaToken);
            LocalImagePath = Path.GetTempPath() + $@"\today.jpeg";
        }

        public async Task<DiscordEmbedBuilder> GetImageOfTheDayFromToday()
        {
            var result = await ApodClient.FetchApodAsync(DateTime.Today);

            if (result.StatusCode != ApodStatusCode.OK || result.Content.MediaType != MediaType.Image)
            {
                return new DiscordEmbedBuilder
                {
                    Title = "",
                };
            }

            return new DiscordEmbedBuilder
            {
                Title = result.Content.Title,
                ImageUrl = result.Content.ContentUrlHD //or some other random image url
            };
        }

        public async Task<DiscordEmbedBuilder> GetImageWithGivenDate(string selectedDate)
        {
            var date = DateTime.Parse(selectedDate);
            var result = await ApodClient.FetchApodAsync(date);

            if (result.StatusCode != ApodStatusCode.OK || result.Content.MediaType != MediaType.Image)
            {
                return new DiscordEmbedBuilder
                {
                    Title = "",
                };
            }

            return new DiscordEmbedBuilder
            {
                Title = result.Content.Title,
                ImageUrl = result.Content.ContentUrlHD //or some other random image url
            };
        }
    }
}
