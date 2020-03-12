using System.Threading.Tasks;
using IguanaBot.Services.JsonHandler;
using IguanaBot.Services.Pokedollar.Interfaces;
using IguanaBot.Services.Services.Pokedollar;

namespace IguanaBot.Services.Pokedollar
{
    public class PokedollarProvider : IPokedollarProvider
    {
        private readonly string _todaysExchangeRateToken;
        private readonly string _historicExchangeRateToken;
        private readonly string _searchEngineId;
        private readonly string _searchToken;

        public PokedollarProvider()
        {
            var configJson = JsonConfigurationReader.GetJsonConfigurationWithTokensInformation();

            _todaysExchangeRateToken = configJson.TodaysExchangeRateToken;
            _historicExchangeRateToken = configJson.HistoricExchangeRateToken;
            _searchEngineId = configJson.SearchEngineId;
            _searchToken = configJson.SearchToken;
        }

        public string GetTodaysExchangeRate()
        {
            return ExchangeRateGetter.GetExchangeRateForToday(_todaysExchangeRateToken);
        }

        public async Task<string> GetExchangeRateForThisDate(string date)
        {
            return await ExchangeRateGetter.GetExchangeRateForGivenDate(date, _historicExchangeRateToken);
        }

        public string GetPokemonName(string pokedexNumber)
        {
            return PokemonInformationGetter.GetPokemonNameFromRate(pokedexNumber);
        }

        public string GetPokemonImageLink(string pokemonName)
        {
            return PokemonInformationGetter.GetPokemonImageLink(_searchToken, _searchEngineId, pokemonName);
        }

        public string GetPokedexNumberFromRate(string rate)
        {
            return PokemonInformationGetter.GetPokedexNumberFromRate(rate);
        }
    }
}
