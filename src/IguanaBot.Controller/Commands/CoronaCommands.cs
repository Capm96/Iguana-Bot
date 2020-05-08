using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using IguanaBot.Services;
using IguanaBot.Services.Interfaces;
using System.Threading.Tasks;

namespace IguanaBot.Controller.Commands
{
    public class CoronaCommands
    {
        private readonly ICoronaServiceProvider _serviceProvider = ServiceFactory.GetCoronaServiceProvider();

        [Command("corona-all")]
        [Description("Retorna as estatisticas globais.")]
        public async Task CoronaAll(CommandContext ctx)
        {
            var message = _serviceProvider.GetMessageWithGlobalInformation();
            await ctx.Message.RespondAsync(embed: message);
        }

        [Command("corona-pais")]
        [Description("Retorna as estatisticas do pais escolhido. Nome tem que ser em ingles. A lista de nomes disponiveis pode ser encontrada digitando ?corona-paises")]
        public async Task CoronaCountry(CommandContext ctx, string country)
        {
            var message = _serviceProvider.GetMessageWithInformationForGivenCountry(country);
            await ctx.Message.RespondAsync(embed: message);
        }

        [Command("corona-paises")]
        [Description("Paises com informacao disponivel.")]
        public async Task CoronaCountriesAvailable(CommandContext ctx)
        {
            var message = _serviceProvider.GetMessageWithAllInfectedCountryNames();
            await ctx.Message.RespondAsync(embed: message);
        }
    }
}
