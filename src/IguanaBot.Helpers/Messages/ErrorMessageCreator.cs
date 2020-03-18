using DSharpPlus.CommandsNext;
using DSharpPlus.Entities;
using System.Threading.Tasks;

namespace IguanaBot.Helpers.Messages
{
    public static class ErrorMessageCreator
    {
        public static DiscordEmbedBuilder CreateErrorMessageDiscordEmbed()
        {
            var message = new DiscordEmbedBuilder
            {
                Title = $"Houve algum erro...",
                Description = $"Por favor entre em contato com o caco macaco.",
            };

            return message;
        }

        public static async Task CreateErrorMessageBecauseOfInvalidDate(CommandContext ctx)
        {
            await ctx.Channel.SendMessageAsync("Houve um erro com a data selecionada.");
            await ctx.Channel.SendMessageAsync("Por favor escolha alguma data no formato: ano-mês-dia (2020-01-01)");
        }
    }
}
