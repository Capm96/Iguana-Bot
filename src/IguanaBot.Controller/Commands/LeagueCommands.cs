using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using IguanaBot.Services.League;
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