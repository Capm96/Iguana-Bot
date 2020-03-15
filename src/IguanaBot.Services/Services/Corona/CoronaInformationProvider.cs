using DSharpPlus.CommandsNext;
using DSharpPlus.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;

namespace IguanaBot.Services.Services.Corona
{
    public class CoronaInformationProvider
    {
        private readonly string _globalInformationURL = "https://corona.lmao.ninja/all";
        private readonly string _allCountriesInformationURL = "https://corona.lmao.ninja/countries";

        public DiscordEmbedBuilder GetMessageWithGlobalInformation()
        {
            var globalInformation = GetGlobalInformation();
            var message = new DiscordEmbedBuilder();
            AddStandardInformationToMessage(globalInformation, message);
            return message;
        }

        public DiscordEmbedBuilder GetMessageWithInformationForGivenCountry(string country)
        {
            var allCountriesInformation = GetAllCountriesInformation();
            var chosenCountryInformation = allCountriesInformation.FirstOrDefault(x => x.Country.ToLower() == country.ToLower());
            if (chosenCountryInformation != null)
                return CreateMessageWithInformationForCountry(chosenCountryInformation);
            else
                return new DiscordEmbedBuilder() { Title = "Nome do pais invalido, confira os nomes disponiveis usando ?corona-paises" };
        }

        public DiscordEmbedBuilder GetMessageWithAllInfectedCountryNames()
        {
            var allCountriesInformation = GetAllCountriesInformation();
            var countryNamesInBlocks = GetCountryNamesInBlocks(allCountriesInformation);

            var message = new DiscordEmbedBuilder();
            message.Title = "Lista de paises infectados, em ordem decrescente de numero de casos.";
            for (int i = 0; i < countryNamesInBlocks.Count; i++)
                message.AddField($"Paises #{i + 1}", countryNamesInBlocks[i], true);

            return message;
        }

        private CoronaInformationHolder GetGlobalInformation()
        {
            var jsonString = GetInformationFromAPI(_globalInformationURL);
            return JsonConvert.DeserializeObject<CoronaInformationHolder>(jsonString);
        }

        private List<CoronaInformationHolder> GetAllCountriesInformation()
        {
            var jsonString = GetInformationFromAPI(_allCountriesInformationURL);
            return JsonConvert.DeserializeObject<List<CoronaInformationHolder>>(jsonString);
        }

        private string GetInformationFromAPI(string requestURL)
        {
            var request = (HttpWebRequest)WebRequest.Create(requestURL);

            string jsonString;
            using (var response = (HttpWebResponse)request.GetResponse())
            using (var stream = response.GetResponseStream())
            using (var reader = new StreamReader(stream))
                jsonString = reader.ReadToEnd();
            return jsonString;
        }

        private static DiscordEmbedBuilder CreateMessageWithInformationForCountry(CoronaInformationHolder selectedCountry)
        {
            var message = new DiscordEmbedBuilder() { Title = selectedCountry.Country };
            AddStandardInformationToMessage(selectedCountry, message);
            message.AddField("Casos hoje", selectedCountry.TodayCases.ToString(), true);
            message.AddField("Estado critico", selectedCountry.Critical.ToString(), true);
            message.AddField("Mortes hoje", selectedCountry.TodayDeaths.ToString(), true);
            return message;
        }

        private static void AddStandardInformationToMessage(CoronaInformationHolder information, DiscordEmbedBuilder message)
        {
            message.AddField("Casos", information.Cases.ToString(), true);
            message.AddField("Recuperados", information.Recovered.ToString(), true);
            message.AddField("Mortos", information.Deaths.ToString(), true);

            var recuperados = Math.Round((double)information.Recovered / (double)information.Cases * 100, 2);
            message.AddField("% Recuperados", recuperados.ToString() + "%", true);

            var mortos = Math.Round((double)information.Deaths / (double)information.Cases * 100, 2);
            message.AddField("% Mortos", mortos.ToString() + "%", true);
        }

        private static List<string> GetCountryNamesInBlocks(List<CoronaInformationHolder> allCountriesInformation)
        {
            int numberOfBlocks = 3;
            int blockLength = allCountriesInformation.Count / numberOfBlocks;

            var countryBlocks = new List<string>();
            int currentCountryIndex = 0;
            for (int i = 0; i < numberOfBlocks; i++)
            {
                var countries = string.Empty;
                for (int j = 0; j < blockLength; j++)
                {
                    countries += allCountriesInformation[currentCountryIndex].Country + "\n";
                    currentCountryIndex++;
                }

                countryBlocks.Add(countries);
            }

            return countryBlocks;
        }
    }
}
