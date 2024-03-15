using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.Entities;

namespace simplerbot;

public class Program
{
    static async Task Main()
    {
        var json = Config.LoadConfig();

        var config = new DiscordConfiguration
        {
            Token = json.Token,
            TokenType = TokenType.Bot,
            Intents = DiscordIntents.All,
            AutoReconnect = true
        };

        var client = new DiscordClient(config);

        var commands = new CommandsNextConfiguration
        {
            StringPrefixes = [json.Prefix]
        };
        
        var commandsConfig = client.UseCommandsNext(commands);
        var activity = new DiscordActivity($"{json.Prefix}help to get started", ActivityType.Watching);
        
        await client.ConnectAsync(activity);
        await Task.Delay(-1);
    }
}