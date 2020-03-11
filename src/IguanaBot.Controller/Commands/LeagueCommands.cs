using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using IguanaBot.Services.League;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IguanaBot.Controller.Commands
{
    public class LeagueCommands : BaseCommandModule
    {
        [Command("times-organizados")]
        [Description("Gera dois times aleatórios, porem com um campeão para cada role. Garante que cada time vai ter um top, um jungle, um mid, um adc, e um suporte.")]
        public async Task TimesOrganizados(CommandContext ctx)
        {
            var teams = LeagueFiveVersusFiveMatchMaker.GetTwoTeamsWithOneChampionFromEachRole();

            await SendMessageWithTeam(ctx, teams, 0);
            await SendMessageWithTeam(ctx, teams, 1);
        }

        [Command("times-random")]
        [Description("Gera dois times totalmente aleatórios. Aram style.")]
        public async Task TimesFullAleatorios(CommandContext ctx)
        {
            var teams = LeagueFiveVersusFiveMatchMaker.GetTwoFullyRandomTeams();

            await SendMessageWithTeam(ctx, teams, 0);
            await SendMessageWithTeam(ctx, teams, 1);
        }

        [Command("times-adc")]
        [Description("Gera dois times totalmente aleatórios, porem garante que vao ter no minimo um ADC.")]
        public async Task TimesAleatoriosComADC(CommandContext ctx)
        {
            var teams = LeagueFiveVersusFiveMatchMaker.GetTwoFullyRandomTeamsWithOneADC();

            await SendMessageWithTeam(ctx, teams, 0);
            await SendMessageWithTeam(ctx, teams, 1);
        }

        private async Task SendMessageWithTeam(CommandContext ctx, List<List<string>> teams, int teamIndex)
        {
            var team = GetTeamAsSingleString(teams[teamIndex]);

            var message = new DiscordEmbedBuilder
            {
                Title = teamIndex == 0 ? "Time #1" : "Time #2",
                Description = team,
                Color = teamIndex == 0 ? DiscordColor.Azure : DiscordColor.Red
            };
            await ctx.RespondAsync(embed: message);
        }

        private string GetTeamAsSingleString(List<string> team)
        {
            var output = "";

            foreach (var champion in team)
                output += champion + "\n";

            return output;
        }
    }
}