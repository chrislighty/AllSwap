using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace CryptoTracker.Hubs
{
    public class PriceHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}
