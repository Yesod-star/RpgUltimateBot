using System;
using System.Threading.Tasks;
using DSharpPlus.CommandsNext;
using DSharpPlus.Entities;
using DSharpPlus.Lavalink;
using DSharpPlus.Net;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DSharpPlus.ExampleBots.CommandsNext.HelloWorld
{
    public sealed class Program
    {
        public static async Task Main()
        {
            var configBuilder = new ConfigurationBuilder();

            configBuilder.AddJsonFile("appsettings.json");

            var configuration = configBuilder.Build();

            if (string.IsNullOrWhiteSpace(configuration["Token"]))
            {
                Console.WriteLine("Please specify a token in the DISCORD_TOKEN environment variable.");
                Environment.Exit(1);

                return;
            }

            DiscordConfiguration config = new()
            {
                Token = configuration["Token"],
                Intents = DiscordIntents.AllUnprivileged | DiscordIntents.MessageContents
            };
            DiscordClient client = new(config);

            DiscordActivity status = new("Now it's your turn to roll");

            var endpoint = new ConnectionEndpoint
            {
                Hostname = configuration["Hostname"],
                Port = 2333 
            };

            var lavalinkConfig = new LavalinkConfiguration
            {
                Password = configuration["Password"],
                RestEndpoint = endpoint,
                SocketEndpoint = endpoint
            };

            ServiceCollection serviceCollection = new();
            serviceCollection.AddSingleton(Random.Shared);

            CommandsNextConfiguration commandsConfig = new()
            {
                Services = serviceCollection.BuildServiceProvider(),
                StringPrefixes = new[] { configuration["Prefix"] }
            };
            CommandsNextExtension commandsNext = client.UseCommandsNext(commandsConfig);

            commandsNext.RegisterCommands(typeof(Program).Assembly);


            var lavalink = client.UseLavalink();

            await client.ConnectAsync(status, UserStatus.Online);
            await lavalink.ConnectAsync(lavalinkConfig);

            await Task.Delay(-1);
        }
    }
}