
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System.Threading.Tasks;

namespace IguanaBot.Commands
{
    public class FunCommands : BaseCommandModule
    {
        [Command("ping")]
        [Description("Returns pong")]
        public async Task Ping(CommandContext ctx)
        {
            await ctx.Channel.SendMessageAsync("Pong").ConfigureAwait(false);
            await ctx.RespondAsync("Pong");
        }

        [Command("organizado")]
        [Description("Returns pong")]
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

        [Command("add")]
        [Description("Adds two numbers together")]
        public async Task Add(CommandContext ctx,
            [Description("First Number")] int numberOne,
            [Description("Second Number")]int numberTwo)
        {
            await ctx.Channel
                .SendMessageAsync((numberOne + numberTwo).ToString())
                .ConfigureAwait(false);
        }
    }
}