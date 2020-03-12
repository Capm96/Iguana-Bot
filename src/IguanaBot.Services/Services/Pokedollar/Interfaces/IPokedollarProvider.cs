using DSharpPlus.Entities;
using System.Threading.Tasks;

namespace IguanaBot.Services.Pokedollar.Interfaces
{
    public interface IPokedollarProvider
    {
        DiscordEmbedBuilder GetTodaysExchangeRate();
        Task<DiscordEmbedBuilder> GetExchangeRateForThisDate(string date);
    }
}