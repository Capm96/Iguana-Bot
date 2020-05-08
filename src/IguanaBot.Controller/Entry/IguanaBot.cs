using DSharpPlus;
using DSharpPlus.CommandsNext;
using IguanaBot.Controller.Commands;
using IguanaBot.Entities.Config;
using IguanaBot.Helpers.Config;
using System.Threading.Tasks;

namespace IguanaBot.Controller.Entry
{
    public class IguanaBot
    {
        public DiscordClient DiscordClient { get; private set; }
        public CommandsNextModule Commands { get; set; }

        public async Task InitializeBot()
        {
            var configJson = JsonConfigurationReader.GetJsonConfigurationWithMyTokens();

            RegisterDiscordClient(configJson);
            RegisterCommands(configJson);
            await Run();
        }

        private void RegisterDiscordClient(JsonConfiguration configJson)
        {
            var discordConfiguration = new DiscordConfiguration
            {
                Token = configJson.DiscordToken,
                TokenType = TokenType.Bot,
                AutoReconnect = true,
                LogLevel = LogLevel.Debug,
                UseInternalLogHandler = true,
            };

            DiscordClient = new DiscordClient(discordConfiguration);
        }

        private void RegisterCommands(JsonConfiguration jsonConfig)
        {
            var commandsConfig = new CommandsNextConfiguration
            {
                StringPrefix = jsonConfig.Prefix,
                EnableMentionPrefix = true,
                CaseSensitive = false
            };

            Commands = DiscordClient.UseCommandsNext(commandsConfig);
            Commands.RegisterCommands<LeagueCommands>();
            Commands.RegisterCommands<PokedollarCommands>();
            Commands.RegisterCommands<NasaCommands>();
            Commands.RegisterCommands<CoronaCommands>();
        }

        private async Task Run()
        {
            await DiscordClient.ConnectAsync();
            await Task.Delay(-1);
        }
    }
}
