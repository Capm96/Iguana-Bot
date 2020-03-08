
using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using IguanaBot.Services.Nasa;
using System;
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
            bool dateIsValid = CheckIfDataIsValid(date);
            if (dateIsValid)
            {
                var nasa = new NasaImagesProvider();
                nasa.GetImageWithGivenDate(date);
                await ctx.Channel.SendFileAsync(nasa.LocalImagePath).ConfigureAwait(false);
            }
            else
            {
                await ctx.Channel.SendMessageAsync("Houve um erro com a data selecionada.");
                await ctx.Channel.SendMessageAsync("Por favor escolha alguma data no formato: ano-mes-dia (2020-01-01)");
            }
        }

        private bool CheckIfDataIsValid(string date)
        {
            var dateTime = new DateTime();
            bool dateCanBeParsed = DateTime.TryParse(date, out dateTime);

            if (dateCanBeParsed)
            {
                if (dateTime > DateTime.Today)
                    return false;
            }
            else
            {
                return false;
            }

            return true;
        }
    }
}