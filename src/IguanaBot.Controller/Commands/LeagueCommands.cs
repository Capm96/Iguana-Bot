using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using IguanaBot.Services.League;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IguanaBot.Controller.Commands
{
    public class LeagueCommands : BaseCommandModule
    {
        [Command("times_organizados")]
        [Description("Gera dois times aleatórios, porem com um campeão para cada role. Garante que cada time vai ter um top, um jungle, um mid, um adc, e um suporte.")]
        public async Task Organizado(CommandContext ctx)
        {
            var teams = LeagueFiveVersusFiveMatchMaker.GetTwoTeamsWithOneChampionFromEachRole();

            var teamOne = GetTeamAsSingleString(teams[0]);
            var embedOne = new DiscordEmbedBuilder
            {
                Title = "Time #1",
                Description = teamOne,
                Color = DiscordColor.Azure
            };
            await ctx.RespondAsync(embed: embedOne);

            var teamTwo = GetTeamAsSingleString(teams[1]);
            var embedTwo = new DiscordEmbedBuilder
            {
                Title = "Time #2",
                Description = teamTwo,
                Color = DiscordColor.Red
            };
            await ctx.RespondAsync(embed: embedTwo);
        }

        private string GetTeamAsSingleString(List<string> team)
        {
            var output = "";

            foreach (var champion in team)
            {
                output += champion;
                output += "\n";
            }

            return output;
        }
    }
}