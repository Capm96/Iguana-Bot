using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using IguanaBot.Services.Helpers;
using IguanaBot.Services.Nasa;
using System;
using System.Threading.Tasks;

namespace IguanaBot.Controller.Commands
{
    public class NasaCommands : BaseCommandModule
    {
        private NasaImagesProvider _nasaImageProvider = new NasaImagesProvider();

        [Command("nasa_hoje")]
        [Description("Retorna a imagem do dia de hoje.")]
        public async Task Nasa(CommandContext ctx)
        {
            await SendNasaPictureForToday(ctx);
        }

        [Command("nasa_dia")]
        [Description("Retorna a imagem do dia selecionado. Formato: ano-dia-mês . Exemplo, 2015-01-15 = Dia 15 de Janeiro de 2015.")]
        public async Task NasaWithGivenDate(CommandContext ctx, [Description("Data desejada")] string date)
        {
            bool dateIsValid = DateValidator.CheckIfDataIsValid(date);
            if (dateIsValid)
                await SendNasaPictureForGivenDate(ctx, date);
            else
                await DateValidator.AlertUserThereWasAnErrorWithTheDate(ctx);
        }

        private async Task SendNasaPictureForToday(CommandContext ctx)
        {
            var nasaEmbed = await _nasaImageProvider.GetImageFromToday();
            await SendMessage(ctx, nasaEmbed);
        }

        private async Task SendNasaPictureForGivenDate(CommandContext ctx, string date)
        {
            var nasaEmbed = await _nasaImageProvider.GetImageWithGivenDate(date);
            await SendMessage(ctx, nasaEmbed);
        }

        private static async Task SendMessage(CommandContext ctx, DiscordEmbedBuilder nasaEmbed)
        {
            if (nasaEmbed.Title.Length > 0)
                await ctx.Message.RespondAsync(embed: nasaEmbed);
            else
                await ctx.Message.RespondAsync("Houve algum erro... entre em contato com o caco macaco.");
        }
    }
}