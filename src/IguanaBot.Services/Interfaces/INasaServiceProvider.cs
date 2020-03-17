using DSharpPlus.Entities;
using System.Threading.Tasks;

namespace IguanaBot.Services.Interfaces
{
    public interface INasaServiceProvider
    {
        Task<DiscordEmbedBuilder> GetImageFromToday();
        Task<DiscordEmbedBuilder> GetImageWithGivenDate(string selectedDate);
    }
}