using CryptoTracker.Models;

namespace CryptoTracker.Services
{
    public class DexService : IDexService
    {
        public async Task<TokenSwap> GetEstimatedSwapAsync(string tokenIn, string tokenOut, decimal amountIn)
        {
            // Stub: simulate a 1:1 swap for demo
            await Task.Delay(100);
            return new TokenSwap
            {
                TokenIn = tokenIn,
                TokenOut = tokenOut,
                AmountIn = amountIn,
                EstimatedAmountOut = amountIn // Simulated
            };
        }
    }
}