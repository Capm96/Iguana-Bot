using System;
using System.Threading.Tasks;
using DSharpPlus.Entities;
using IguanaBot.Entities.Pokedollar;
using IguanaBot.Helpers.Config;
using IguanaBot.Services.Interfaces;

namespace IguanaBot.Services.Pokedollar
{
    public class PokedollarServiceProvider : IPokedollarServiceProvider
    {
        private readonly string _todaysExchangeRateToken;
        private readonly string _historicExchangeRateToken;
        private readonly string _searchEngineId;
        private readonly string _searchToken;

        public PokedollarServiceProvider()
        {
            var configJson = JsonConfigurationReader.GetJsonConfigurationWithMyTokens();

            _todaysExchangeRateToken = configJson.TodaysExchangeRateToken;
            _historicExchangeRateToken = configJson.HistoricExchangeRateToken;
            _searchEngineId = configJson.SearchEngineId;
            _searchToken = configJson.SearchToken;
        }

        public DiscordEmbedBuilder GetTodaysExchangeRate()
        {
            var exchangeRate = string.Empty;
            var task = Task.Run(() =>
            {
                exchangeRate = ExchangeRateGetter.GetExchangeRateForToday(_todaysExchangeRateToken);
            });

            bool taskCompletedSuccessfully = task.Wait(TimeSpan.FromSeconds(3));
            return taskCompletedSuccessfully ? CreateMessageWithCorrectInformation(exchangeRate) : CreateErrorMessage();
        }

        public async Task<DiscordEmbedBuilder> GetExchangeRateForThisDate(string date)
        {
            var exchangeRate = string.Empty;
            var task = Task.Run(async() =>
            {
                exchangeRate = await ExchangeRateGetter.GetExchangeRateForGivenDate(date, _historicExchangeRateToken);
            });

            bool taskCompletedSuccessfully = task.Wait(TimeSpan.FromSeconds(5));
            return taskCompletedSuccessfully ? CreateMessageWithCorrectInformation(exchangeRate) : CreateErrorMessage();
        }

        private DiscordEmbedBuilder CreateMessageWithCorrectInformation(string exchangeRate)
        {
            var pokedexNumber = PokemonInformationGetter.GetPokedexNumberFromRate(exchangeRate);
            var pokemonName = Pokemons.AllPokemonNames[pokedexNumber];
            var pokemonImageLink = PokemonInformationGetter.GetPokemonImageLink(_searchToken, _searchEngineId, pokemonName);

            var message = new DiscordEmbedBuilder
            {
                Title = $"1 dolar = {exchangeRate} reais",
                Description = $"Pokedex numero {pokedexNumber} = {pokemonName}!",
                ImageUrl = pokemonImageLink
            };

            return message;
        }

        private DiscordEmbedBuilder CreateErrorMessage()
        {
            var message = new DiscordEmbedBuilder
            {
                Title = $"Houve algum erro...",
                Description = $"Por favor entre em contato com o caco macaco.",
            };

            return message;
        }
    }
}
