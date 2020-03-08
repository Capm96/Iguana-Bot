
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using IguanaBot.Services.League;
using System.Threading.Tasks;

namespace IguanaBot.Controller.Commands
{
    public class LeagueCommands : BaseCommandModule
    {
        [Command("organizado")]
        [Description("Gera dois times aleatorios com um campeao para cada role.")]
        public async Task Organizado(CommandContext ctx)
        {
            var teams = LeagueFiveVersusFiveMatchMaker.GetTwoTeamsWithOneChampionFromEachRole();
            for (int i = 1; i <= teams.Count; i++)
            {
                await ctx.RespondAsync($"Time {i} -");

                foreach (var champion in teams[i - 1])
                    await ctx.RespondAsync($"{champion}");

                if (i < teams.Count)
                    await ctx.RespondAsync("----------");
            }
        }
    }
}