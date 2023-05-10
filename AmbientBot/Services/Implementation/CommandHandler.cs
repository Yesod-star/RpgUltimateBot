using RpgUltimateBot.Services.Interface;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace RpgUltimateBot.Services.Implementation;

public class CommandHandler : ICommandHandler
{
    private readonly IServiceProvider provider;
    private readonly DiscordSocketClient client;
    private readonly CommandService service;
    private readonly IConfiguration configuration;

    public CommandHandler(IServiceProvider provider, DiscordSocketClient client, CommandService service, IConfiguration configuration)
    {
        this.provider = provider;
        this.client = client;
        this.service = service;
        this.configuration = configuration;
    }

    public async Task InitializeAsync(CancellationToken cancellationToken)
    {
        client.MessageReceived += OnMessageReceived;
        await service.AddModulesAsync(Assembly.GetEntryAssembly(), provider);
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        client.MessageReceived += OnMessageReceived;
        await service.AddModulesAsync(Assembly.GetEntryAssembly(), provider);
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    private async Task OnMessageReceived(SocketMessage socketMessage)
    {
        var message = socketMessage as SocketUserMessage;

        if (message.Source != Discord.MessageSource.User) return;

        var argPos = 0;

        if (!message.HasStringPrefix("!", ref argPos)) return;

        var context = new SocketCommandContext(client, message);
        await service.ExecuteAsync(context, argPos, provider);
    }
}

