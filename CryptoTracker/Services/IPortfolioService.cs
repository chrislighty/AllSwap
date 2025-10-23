using CryptoTracker.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CryptoTracker.Services
{
    public interface IPortfolioService
    {
        Task<List<Portfolio>> GetPortfolioAsync(string userId);
        Task UpdatePortfolioAsync(string userId, string tokenSymbol, decimal amount);
    }
}
