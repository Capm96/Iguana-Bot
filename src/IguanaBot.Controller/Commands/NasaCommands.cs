using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using IguanaBot.Helpers.Validators;
using IguanaBot.Services;
using IguanaBot.Services.Interfaces;
using System.Threading.Tasks;

namespace IguanaBot.Controller.Commands
{
    public class NasaCommands : BaseCommandModule
    {
        private INasaServiceProvider _serviceProvider = ServiceFactory.GetNasaServiceProvider();

        [Command("nasa-hoje")]
        [Description("Retorna a imagem do dia de hoje.")]
        public async Task Nasa(CommandContext ctx)
        {
            var nasaEmbed = await _serviceProvider.GetImageFromToday();
            await ctx.Message.RespondAsync(embed: nasaEmbed);
        }

        [Command("nasa-dia")]
        [Description("Retorna a imagem do dia selecionado. Formato: ano-dia-mês . Exemplo, 2015-01-15 = Dia 15 de Janeiro de 2015.")]
        public async Task NasaWithGivenDate(CommandContext ctx, [Description("Data desejada")] string date)
        {
            bool dateIsValid = DateValidator.CheckIfDataIsValid(date);
            if (dateIsValid)
                await SendNasaPictureForGivenDate(ctx, date);
            else
                await AlertUserThereWasAnErrorWithTheDate(ctx);
        }

        private async Task SendNasaPictureForGivenDate(CommandContext ctx, string date)
        {
            var nasaEmbed = await _serviceProvider.GetImageWithGivenDate(date);
            await ctx.Message.RespondAsync(embed: nasaEmbed);
        }

        private static async Task AlertUserThereWasAnErrorWithTheDate(CommandContext ctx)
        {
            await ctx.Channel.SendMessageAsync("Houve um erro com a data selecionada.");
            await ctx.Channel.SendMessageAsync("Por favor escolha alguma data no formato: ano-mês-dia (2020-01-01)");
        }
    }
}