using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
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
                await AlertUserThereWasAnErrorWithTheDate(ctx);
        }

        private async Task SendPokedollarMessageForGivenDate(CommandContext ctx, string date)
        {
            var exchangeRateMessage = await _serviceProvider.GetExchangeRateForThisDate(date);
            await ctx.Message.RespondAsync(embed: exchangeRateMessage);
        }

        private async Task SendPokedollarMessageForToday(CommandContext ctx)
        {
            var exchangeRateMessage = _serviceProvider.GetTodaysExchangeRate();
            await ctx.Message.RespondAsync(embed: exchangeRateMessage);
        }

        private static async Task AlertUserThereWasAnErrorWithTheDate(CommandContext ctx)
        {
            await ctx.Channel.SendMessageAsync("Houve um erro com a data selecionada.");
            await ctx.Channel.SendMessageAsync("Por favor escolha alguma data no formato: ano-mês-dia (2020-01-01)");
        }
    }
}
