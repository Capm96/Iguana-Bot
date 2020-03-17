using Google.Apis.Customsearch.v1;
using Google.Apis.Customsearch.v1.Data;
using Google.Apis.Services;
using System.Collections.Generic;

namespace IguanaBot.Services.Pokedollar
{
    public static class PokemonInformationGetter
    {
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

        public static int GetPokedexNumberFromRate(string rate)
        {
            return int.Parse(rate.Replace(".", "").Substring(0, 3));
        }
    }
}
