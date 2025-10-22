namespace CryptoTracker.Models
{
    public class TokenSwap
    {
        public string TokenIn { get; set; }
        public string TokenOut { get; set; }
        public decimal AmountIn { get; set; }
        public decimal EstimatedAmountOut { get; set; }
    }
}