using CryptoTracker.Models;

namespace CryptoTracker.Services
{
    public interface IDexService
    {
        Task<TokenSwap> GetEstimatedSwapAsync(string tokenIn, string tokenOut, decimal amountIn);
    }
}