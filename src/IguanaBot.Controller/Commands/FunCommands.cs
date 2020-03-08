﻿
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using System.Threading.Tasks;

namespace IguanaBot.Controller.Commands
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
    }
}