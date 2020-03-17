using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using IguanaBot.Services;
using IguanaBot.Services.Interfaces;
using System.Threading.Tasks;

namespace IguanaBot.Controller.Commands
{
    public class LeagueCommands : BaseCommandModule
    {
        private readonly ILeagueServiceProvider _serviceProvider = ServiceFactory.GetLeagueServiceProvider();

        [Command("times-organizados")]
        [Description("Gera dois times aleatórios, porem com um campeão para cada role. Garante que cada time vai ter um top, um jungle, um mid, um adc, e um suporte.")]
        public async Task TimesOrganizados(CommandContext ctx)
        {
            var teams = _serviceProvider.GetTwoTeamsWithOneChampionFromEachRole();
            await SendMessageWithTeam(ctx, teams[0], 0);
            await SendMessageWithTeam(ctx, teams[1], 1);
        }

        [Command("times-random")]
        [Description("Gera dois times totalmente aleatórios. Aram style.")]
        public async Task TimesFullAleatorios(CommandContext ctx)
        {
            var teams = _serviceProvider.GetTwoFullyRandomTeams();
            await SendMessageWithTeam(ctx, teams[0], 0);
            await SendMessageWithTeam(ctx, teams[1], 1);
        }

        [Command("times-adc")]
        [Description("Gera dois times totalmente aleatórios, porem garante que vao ter no minimo um ADC.")]
        public async Task TimesAleatoriosComADC(CommandContext ctx)
        {
            var teams = _serviceProvider.GetTwoFullyRandomTeamsWithOneADC();
            await SendMessageWithTeam(ctx, teams[0], 0);
            await SendMessageWithTeam(ctx, teams[1], 1);
        }

        private async Task SendMessageWithTeam(CommandContext ctx, string team, int teamIndex)
        {
            var message = new DiscordEmbedBuilder
            {
                Title = teamIndex == 0 ? "Time #1" : "Time #2",
                Description = team,
                Color = teamIndex == 0 ? DiscordColor.Azure : DiscordColor.Red
            };

            await ctx.RespondAsync(embed: message);
        }
    }
}