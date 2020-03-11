using System.Threading.Tasks;

namespace IguanaBot.Services.Pokedollar.Interfaces
{
    public interface IPokedollarProvider
    {
        Task<string> GetExchangeRateForThisDate(string date);
        string GetPokedexNumberFromRate(string rate);
        string GetPokemonImageLink(string pokemonName);
        string GetPokemonName(string pokedexNumber);
        string GetTodaysExchangeRate();
    }
}