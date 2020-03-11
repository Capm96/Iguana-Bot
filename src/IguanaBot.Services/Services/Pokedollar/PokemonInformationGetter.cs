using Google.Apis.Customsearch.v1;
using Google.Apis.Customsearch.v1.Data;
using Google.Apis.Services;
using IguanaBot.Services.Pokedollar;
using System.Collections.Generic;
using System.Text;

namespace IguanaBot.Services.Services.Pokedollar
{
    public static class PokemonInformationGetter
    {
        public static string GetPokemonNameFromRate(string pokedexNumber)
        {
            return AllPokemons.AllPokemonNames[int.Parse(pokedexNumber)];
        }

        public static string GetPokedexNumberFromRate(string rate)
        {
            var digits = rate.Split('.');

            var stringBuilder = new StringBuilder();
            stringBuilder.Append(digits[0]);
            stringBuilder.Append(digits[1].Substring(0, 2));
            return stringBuilder.ToString();
        }

        public static string GetPokemonImageLink(string apiKey, string searchEngineId, string pokemonName)
        {
            var customSearchService = new CustomsearchService(new BaseClientService.Initializer { ApiKey = apiKey });

            var listRequest = customSearchService.Cse.List(pokemonName);
            listRequest.SearchType = CseResource.ListRequest.SearchTypeEnum.Image;
            listRequest.Cx = searchEngineId;

            IList<Result> results = new List<Result>();
            results = listRequest.Execute().Items;

            return results[0].Image.ThumbnailLink;
        }
    }
}
