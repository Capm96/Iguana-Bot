using System;
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

        public NasaImagesProvider()
        {
            var jsonConfig = MyJsonReader.GetJsonConfigurationWithTokensInformation();
            ApodClient = new ApodClient(jsonConfig.NasaToken);
        }

        public async Task<DiscordEmbedBuilder> GetImageFromToday()
        {
            var result = await ApodClient.FetchApodAsync(DateTime.Today);
            return BuildNewDiscordEmbed(result);
        }

        public async Task<DiscordEmbedBuilder> GetImageWithGivenDate(string selectedDate)
        {
            var date = DateTime.Parse(selectedDate);
            var result = await ApodClient.FetchApodAsync(date);
            return BuildNewDiscordEmbed(result);
        }

        private static DiscordEmbedBuilder BuildNewDiscordEmbed(ApodResponse result)
        {
            if (result.StatusCode != ApodStatusCode.OK || result.Content.MediaType != MediaType.Image)
            {
                return new DiscordEmbedBuilder
                {
                    Title = "",
                };
            }
            else
            {
                return new DiscordEmbedBuilder
                {
                    Title = result.Content.Title,
                    ImageUrl = result.Content.ContentUrlHD
                };
            }
        }
    }
}
