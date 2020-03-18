using System;
using System.Threading.Tasks;
using Apod;
using DSharpPlus.Entities;
using IguanaBot.Helpers.Config;
using IguanaBot.Helpers.Messages;
using IguanaBot.Services.Interfaces;

namespace IguanaBot.Services.Nasa
{
    public class NasaServiceProvider : INasaServiceProvider
    {
        private readonly ApodClient _apodClient;

        public NasaServiceProvider()
        {
            var jsonConfig = JsonConfigurationReader.GetJsonConfigurationWithMyTokens();
            _apodClient = new ApodClient(jsonConfig.NasaToken);
        }

        public async Task<DiscordEmbedBuilder> GetImageFromToday()
        {
            var result = await _apodClient.FetchApodAsync(DateTime.Today);
            return BuildNewDiscordEmbed(result);
        }

        public async Task<DiscordEmbedBuilder> GetImageWithGivenDate(string selectedDate)
        {
            var date = DateTime.Parse(selectedDate);
            var result = await _apodClient.FetchApodAsync(date);
            return BuildNewDiscordEmbed(result);
        }

        private static DiscordEmbedBuilder BuildNewDiscordEmbed(ApodResponse result)
        {
            if (result.StatusCode != ApodStatusCode.OK)
            {
                return ErrorMessageCreator.CreateErrorMessageDiscordEmbed();
            }
            else if (result.Content.MediaType == MediaType.Video)
            {
                return new DiscordEmbedBuilder
                {
                    Title = result.Content.Title,
                    Url = result.Content.ContentUrl,
                };
            }
            else
            {
                return new DiscordEmbedBuilder
                {
                    Title = result.Content.Title,
                    ImageUrl = result.Content.ContentUrlHD,
                };
            }
        }
    }
}
