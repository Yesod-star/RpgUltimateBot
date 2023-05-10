using Microsoft.Extensions.Hosting;

namespace RpgUltimateBot.Services.Interface;

public interface ICommandHandler : IHostedService
{
    Task InitializeAsync(CancellationToken cancellationToken);

    Task StartAsync(CancellationToken cancellationToken);

    Task StopAsync(CancellationToken cancellationToken);
}

