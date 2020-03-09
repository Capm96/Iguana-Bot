using RatesExchangeApi;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace IguanaBot.Services.Pokedollar
{
    public class PokedollarProvider
    {
        public string APIKey { get; set; }

        public PokedollarProvider(string apiKey)
        {
            APIKey = apiKey;
        }

        public async Task<string> GetRate()
        {
            var client = new RatesExchangeApiService(APIKey);

            List<string> isoCurrencies = new List<string> { "BRL" };
            var rates = await client.GetLatestRates("USD", isoCurrencies);

            var rate = rates.Rates["BRL"];

            return rate.ToString();
        }

        public async Task<string> GetPokemon(string rate)
        {
            var chars = rate.Split('.');

            var sb = new StringBuilder();

            sb.Append(chars[0]);
            sb.Append(chars[1].Substring(0, 2));

            var pokemonName = $"Pokedex {sb.ToString()}: " + AllPokemons.allPokemons[int.Parse(sb.ToString()) - 1];

            return pokemonName;
        }
    }
}
