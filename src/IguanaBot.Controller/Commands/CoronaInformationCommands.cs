using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using IguanaBot.Services.Services.Corona;
using System.Threading.Tasks;

namespace IguanaBot.Controller.Commands
{
    public class CoronaInformationCommands : BaseCommandModule
    {
        [Command("corona-all")]
        [Description("Retorna as estatisticas globais.")]
        public async Task CoronaAll(CommandContext ctx)
        {
            var provider = new CoronaInformationProvider();
            var message = provider.GetMessageWithGlobalInformation();
            await ctx.Message.RespondAsync(embed: message);
        }

        [Command("corona-pais")]
        [Description("Retorna as estatisticas do pais escolhido. Nome tem que ser em ingles. A lista de nomes disponiveis pode ser encontrada digitando ?corona-paises")]
        public async Task CoronaCountry(CommandContext ctx, string country)
        {
            var provider = new CoronaInformationProvider();
            var message = provider.GetMessageWithInformationForGivenCountry(country);
            await ctx.Message.RespondAsync(embed: message);
        }

        [Command("corona-paises")]
        [Description("Paises com informacao disponivel.")]
        public async Task CoronaCountriesAvailable(CommandContext ctx)
        {
            var provider = new CoronaInformationProvider();
            var message = provider.GetMessageWithAllInfectedCountryNames();
            await ctx.Message.RespondAsync(embed: message);
        }
    }
}
