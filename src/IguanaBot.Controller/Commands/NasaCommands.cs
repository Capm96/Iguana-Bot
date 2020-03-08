
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using IguanaBot.Services.Nasa;
using System.Threading.Tasks;

namespace IguanaBot.Controller.Commands
{
    public class NasaCommands : BaseCommandModule
    {
        [Command("nasa_hoje")]
        [Description("Retorna a imagem do dia de hoje.")]
        public async Task Nasa(CommandContext ctx)
        {
            var nasa = new NasaImagesProvider();
            nasa.GetImageOfTheDayFromToday();
            await ctx.Channel.SendFileAsync(nasa.LocalImagePath).ConfigureAwait(false);
        }

        [Command("nasa_dia")]
        [Description("Retorna a imagem do dia selecionado. Formato: ano-dia-mes. Exemplo, 2015-01-15 = Dia 15" +
            "de Janeiro de 2015.")]
        public async Task NasaWithGivenDate(CommandContext ctx, 
            [Description("Data desejada")] string date)
        {
            var nasa = new NasaImagesProvider();
            nasa.GetImageWithGivenDate(date);
            await ctx.Channel.SendFileAsync(nasa.LocalImagePath).ConfigureAwait(false);
        }
    }
}