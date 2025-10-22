using CryptoTracker.Models;

namespace CryptoTracker.Services
{
    public interface ICoinGeckoService
    {
        Task<List<Coin>> GetTopCoinsAsync(int limit = 10);
    }
}