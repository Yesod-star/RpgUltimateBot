using RpgUltimateBot.Services.Implementation;
using Discord;
using Discord.Addons.Hosting;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Victoria.Node;
using Victoria.Player;
using Victoria;

namespace RpgUltimateBot;



class RpgUltimateBot : ModuleBase<SocketCommandContext>
{

    public readonly LavaNode _lavaNode;

    static async Task Main()
    {

        var builder = new Microsoft.Extensions.Hosting.HostBuilder()
        .ConfigureAppConfiguration(x =>
            {
                var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, true)
                .Build();
                        
                x.AddConfiguration(configuration);
            })
        .ConfigureLogging(x =>
        {
            x.AddConsole();
            x.SetMinimumLevel(LogLevel.Debug);
                        
        })
        .ConfigureDiscordHost((context, config) =>
        {
            config.SocketConfig = new DiscordSocketConfig
            {
                LogLevel = Discord.LogSeverity.Debug,
                AlwaysDownloadUsers = false,
                MessageCacheSize = 200,
                GatewayIntents = GatewayIntents.AllUnprivileged | GatewayIntents.MessageContent
            };

            config.Token = context.Configuration["Token"];
        })
        .UseCommandService((context, config) =>
        {
            config.CaseSensitiveCommands = false;
            config.LogLevel = LogSeverity.Debug;
            config.DefaultRunMode = Discord.Commands.RunMode.Sync;
        })
        .ConfigureServices((context, services) =>
        {
            services.AddHostedService<CommandHandler>();
            services.AddLavaNode(x =>
            {
                x.Authorization = BotConfig.LavalinkPassword;
                x.Hostname = BotConfig.LavalinkHost;
                x.Port = (ushort)BotConfig.LavalinkPort;
            });
        })
        .UseConsoleLifetime();

        var host = builder.Build();
        using (host)
        {
            await host.RunAsync();
        }
    }

    }
