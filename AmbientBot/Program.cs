using System;
using System.Threading.Tasks;
using DSharpPlus.CommandsNext;
using DSharpPlus.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace DSharpPlus.ExampleBots.CommandsNext.HelloWorld
{
    public sealed class Program
    {
        public static async Task Main()
        {
            string? token = "MTEwMTk3MTYzOTQ4ODQ5OTc3Mg.GWj8US.AtqQzFIjQNyGi_VbuJbmp4SorDfG3TF6QUgyN0";
            if (string.IsNullOrWhiteSpace(token))
            {
                Console.WriteLine("Please specify a token in the DISCORD_TOKEN environment variable.");
                Environment.Exit(1);

                return;
            }

            DiscordConfiguration config = new()
            {
                Token = token,
                Intents = DiscordIntents.AllUnprivileged | DiscordIntents.MessageContents
            };
            DiscordClient client = new(config);

            DiscordActivity status = new("with fire", ActivityType.Playing);

            ServiceCollection serviceCollection = new();
            serviceCollection.AddSingleton(Random.Shared);

            CommandsNextConfiguration commandsConfig = new()
            {
                Services = serviceCollection.BuildServiceProvider(),
                StringPrefixes = new[] { "!" }
            };
            CommandsNextExtension commandsNext = client.UseCommandsNext(commandsConfig);

            commandsNext.RegisterCommands(typeof(Program).Assembly);

            await client.ConnectAsync(status, UserStatus.Online);

            await Task.Delay(-1);
        }
    }
}