using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using IguanaBot.Helpers.Messages;
using IguanaBot.Helpers.Validators;
using IguanaBot.Services;
using IguanaBot.Services.Interfaces;
using System.Threading.Tasks;

namespace IguanaBot.Controller.Commands
{
    public class PokedollarCommands : BaseCommandModule
    {
        private readonly IPokedollarServiceProvider _serviceProvider = ServiceFactory.GetPokedollarServiceProvider();

        [Command("dolar-hoje")]
        [Description("Retorna a cotação do dólar pro real de hoje.")]
        public async Task DolarHoje(CommandContext ctx)
        {
            var exchangeRateMessage = _serviceProvider.GetTodaysExchangeRate();
            await ctx.Message.RespondAsync(embed: exchangeRateMessage);
        }

        [Command("dolar-dia")]
        [Description("Retorna a cotação do dólar pro real no dia escolhido.")]
        public async Task DolarDia(CommandContext ctx, string date)
        {
            bool dateIsValid = DateValidator.CheckIfDataIsValid(date);
            if (dateIsValid)
                await SendPokedollarMessageForGivenDate(ctx, date);
            else
                await ErrorMessageCreator.CreateErrorMessageBecauseOfInvalidDate(ctx);
        }

        private async Task SendPokedollarMessageForGivenDate(CommandContext ctx, string date)
        {
            var exchangeRateMessage = await _serviceProvider.GetExchangeRateForThisDate(date);
            await ctx.Message.RespondAsync(embed: exchangeRateMessage);
        }
    }
}
