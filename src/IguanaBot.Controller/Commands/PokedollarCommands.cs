using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using IguanaBot.Services.JsonHandler;
using IguanaBot.Services.Pokedollar;
using System.Threading.Tasks;

namespace IguanaBot.Controller.Commands
{
    public class PokedollarCommands : BaseCommandModule
    {
        [Command("dolar")]
        [Description("Retorna a cotacao do real-dolar de hoje.")]
        public async Task Dolar(CommandContext ctx)
        {
            var configJson = MyJsonReader.GetJsonConfigurationWithTokensInformation();
            var pokeDollarProvider = new PokedollarProvider(configJson.PokedollarToken);
            var rate = await pokeDollarProvider.GetRate();
            await ctx.Channel.SendMessageAsync(rate);
            var pokemon = await pokeDollarProvider.GetPokemon(rate);
            await ctx.Channel.SendMessageAsync(pokemon);
        }
    }
}
