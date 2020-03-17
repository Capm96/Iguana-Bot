using DSharpPlus.Entities;

namespace IguanaBot.Services.Interfaces
{
    public interface ICoronaServiceProvider
    {
        DiscordEmbedBuilder GetMessageWithAllInfectedCountryNames();
        DiscordEmbedBuilder GetMessageWithGlobalInformation();
        DiscordEmbedBuilder GetMessageWithInformationForGivenCountry(string country);
    }
}