using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using IguanaBot.Services.Helpers;
using IguanaBot.Services.Pokedollar;
using IguanaBot.Services.Pokedollar.Interfaces;
using System.Threading.Tasks;

namespace IguanaBot.Controller.Commands
{
    public class PokedollarCommands : BaseCommandModule
    {
        private IPokedollarProvider _pokeDollarProvider = new PokedollarProvider();

        [Command("dolar-hoje")]
        [Description("Retorna a cotação do dólar pro real de hoje.")]
        public async Task DolarHoje(CommandContext ctx)
        {
            await SendPokedollarMessageForToday(ctx);
        }

        [Command("dolar-dia")]
        [Description("Retorna a cotação do dólar pro real no dia escolhido.")]
        public async Task DolarDia(CommandContext ctx, string date)
        {
            bool dateIsValid = DateValidator.CheckIfDataIsValid(date);
            if (dateIsValid)
                await SendPokedollarMessageForGivenDate(ctx, date);
            else
                await DateValidator.AlertUserThereWasAnErrorWithTheDate(ctx);
        }

        private async Task SendPokedollarMessageForGivenDate(CommandContext ctx, string date)
        {
            var exchangeRateMessage = await _pokeDollarProvider.GetExchangeRateForThisDate(date);
            await ctx.Message.RespondAsync(embed: exchangeRateMessage);
        }

        private async Task SendPokedollarMessageForToday(CommandContext ctx)
        {
            var exchangeRateMessage = _pokeDollarProvider.GetTodaysExchangeRate();
            await ctx.Message.RespondAsync(embed: exchangeRateMessage);
        }
    }
}
