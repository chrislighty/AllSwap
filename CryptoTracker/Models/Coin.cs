namespace CryptoTracker.Models
{
    public class Coin
    {
        public string Id { get; set; }
        public string Symbol { get; set; }
        public string Name { get; set; }
        public decimal Current_price { get; set; }
        public decimal Market_cap { get; set; }
        public decimal Total_volume { get; set; }
        public decimal Price_change_percentage_24h { get; set; }
    }
}