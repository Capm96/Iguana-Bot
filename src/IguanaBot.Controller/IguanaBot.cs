using DSharpPlus;
using DSharpPlus.CommandsNext;
using IguanaBot.Controller.Commands;
using IguanaBot.JsonHandler;
using IguanaBot.Services.JsonHandler;
using System.Threading.Tasks;

namespace IguanaBot.Controller
{
    public class IguanaBot
    {
        public DiscordClient DiscordClient { get; private set; }
        public CommandsNextExtension Commands { get; set; }

        public async Task InitializeBot()
        {
            var configJson = MyJsonReader.GetJsonConfigurationWithTokensInformation();

            RegisterDiscordClient(configJson);
            RegisterCommands(configJson);

            await DiscordClient.ConnectAsync();
            await Task.Delay(-1);
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
                StringPrefixes = new string[] { jsonConfig.Prefix },
                EnableMentionPrefix = true,
                DmHelp = false,
                CaseSensitive = false
            };

            Commands = DiscordClient.UseCommandsNext(commandsConfig);
            Commands.RegisterCommands<FunCommands>();
            Commands.RegisterCommands<LeagueCommands>();
            Commands.RegisterCommands<PokedollarCommands>();
            Commands.RegisterCommands<NasaCommands>();
        }
    }
}
