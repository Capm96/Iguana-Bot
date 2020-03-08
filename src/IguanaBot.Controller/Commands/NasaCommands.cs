
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using IguanaBot.Services.Nasa;
using System.Threading.Tasks;

namespace IguanaBot.Controller.Commands
{
    public class NasaCommands : BaseCommandModule
    {
        [Command("nasa")]
        [Description("Retorna a imagem do dia de hoje")]
        public async Task Nasa(CommandContext ctx)
        {
            var nasa = new NasaAPIHandler();
            nasa.GetImageOfTheDayFromToday();
            await ctx.Channel.SendFileAsync($@"C:\Users\carlo\Desktop\Applications\nasa2.jpeg").ConfigureAwait(false);
        }

        [Command("nasa2")]
        [Description("Retorna a imagem do dia selecionado. Formato: ano-dia-mes. Exemplo, 2015-01-15 = Dia 15" +
            "de Janeiro de 2015.")]
        public async Task NasaWithGivenDate(CommandContext ctx, string date)
        {
            var nasa = new NasaAPIHandler();
            nasa.GetImageWithGivenDate(date);
            await ctx.Channel.SendFileAsync($@"C:\Users\carlo\Desktop\Applications\nasa5.jpeg").ConfigureAwait(false);
        }
    }
}