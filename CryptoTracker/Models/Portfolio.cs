using System;

namespace CryptoTracker.Models
{
    public class Portfolio
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string TokenSymbol { get; set; }
        public decimal Amount { get; set; }
        public DateTime LastUpdated { get; set; } = DateTime.UtcNow;
    }
}
