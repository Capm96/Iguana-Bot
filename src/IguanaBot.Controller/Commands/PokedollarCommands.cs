using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
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
            var exchangeRate = await _pokeDollarProvider.GetExchangeRateForThisDate(date);
            var finalMessage = CreateMessage(exchangeRate);
            await ctx.Message.RespondAsync(embed: finalMessage);
        }

        private async Task SendPokedollarMessageForToday(CommandContext ctx)
        {
            var exchangeRate = _pokeDollarProvider.GetTodaysExchangeRate();
            var finalMessage = CreateMessage(exchangeRate);
            await ctx.Message.RespondAsync(embed: finalMessage);
        }

        private DiscordEmbedBuilder CreateMessage(string exchangeRate)
        {
            var pokedexNumber = _pokeDollarProvider.GetPokedexNumberFromRate(exchangeRate);
            var pokemonName = _pokeDollarProvider.GetPokemonName(pokedexNumber);
            var pokemonImageLink = _pokeDollarProvider.GetPokemonImageLink(pokemonName);

            var message = new DiscordEmbedBuilder
            {
                Title = $"1 dolar = {exchangeRate} reais",
                Description = $"Pokedex numero {pokedexNumber} = {pokemonName}!",
                ImageUrl = pokemonImageLink
            };

            return message;
        }
    }
}
