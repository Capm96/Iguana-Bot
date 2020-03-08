using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.EventArgs;
using IguanaBot.Controller.Commands;
using IguanaBot.Services;
using IguanaBot.Services.JsonHandler;
using IguanaBot.Services.League;
using Newtonsoft.Json;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace IguanaBot.Controller
{
    public class IguanaBot
    {
        public DiscordClient Client { get; private set; }
        public CommandsNextExtension Commands { get; set; }

        public async Task RunBotAsync()
        {
            var configJson = await MyJsonReader.ReadJsonConfig();

            var config = new DiscordConfiguration
            {
                Token = configJson.DiscordToken,
                TokenType = TokenType.Bot,
                AutoReconnect = true,
                LogLevel = LogLevel.Debug,
                UseInternalLogHandler = true,
            };

            Client = new DiscordClient(config);

            Client.Ready += OnClientReady;

            var commandsConfig = new CommandsNextConfiguration
            {
                StringPrefixes = new string[] { configJson.Prefix },
                EnableMentionPrefix = true,
                DmHelp = false,
            };

            Commands = Client.UseCommandsNext(commandsConfig);

            Commands.RegisterCommands<FunCommands>();

            var test = LeagueFiveVersusFiveMatchMaker.GetTwoTeamsWithOneChampionFromEachRole();

            await Client.ConnectAsync();

            await Task.Delay(-1);
        }

        private Task OnClientReady(ReadyEventArgs e)
        {
            return Task.CompletedTask;
        }
    }
}
