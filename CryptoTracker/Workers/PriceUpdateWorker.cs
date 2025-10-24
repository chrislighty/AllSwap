using CryptoTracker.Hubs;
using CryptoTracker.Services;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CryptoTracker.Workers
{
    public class PriceUpdateWorker : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;

        public PriceUpdateWorker(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    var coinService = scope.ServiceProvider.GetRequiredService<ICoinGeckoService>();
                    var hubContext = scope.ServiceProvider.GetRequiredService<IHubContext<PriceHub>>();

                    var prices = await coinService.GetTopCoinsAsync();
                    await hubContext.Clients.All.SendAsync("ReceivePriceUpdate", prices, stoppingToken);
                }

                await Task.Delay(TimeSpan.FromSeconds(30), stoppingToken); // Update every 30 seconds
            }
        }
    }
}
