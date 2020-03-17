using DSharpPlus.Entities;
using System.Threading.Tasks;

namespace IguanaBot.Services.Interfaces
{
    public interface IPokedollarServiceProvider
    {
        DiscordEmbedBuilder GetTodaysExchangeRate();
        Task<DiscordEmbedBuilder> GetExchangeRateForThisDate(string date);
    }
}