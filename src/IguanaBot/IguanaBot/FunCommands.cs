
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using IguanaBot;
using System.Threading.Tasks;

namespace DiscordBotTutorial.Commands
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
            var champs = LeagueFiveVersusFiveMatchMaker.GetOneChampionFromEachRole();

            foreach (var team in champs)
            {
                foreach (var champ in team)
                {
                    await ctx.RespondAsync($"{champ}");
                }
            }
        }

        [Command("add")]
        [Description("Adds two numbers together")]
        [RequireRoles(RoleCheckMode.Any, "Moderator", "Owner")]
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