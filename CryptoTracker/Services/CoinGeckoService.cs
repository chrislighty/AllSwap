using CryptoTracker.Models;
using Newtonsoft.Json;

namespace CryptoTracker.Services
{
    public class CoinGeckoService : ICoinGeckoService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _config;

        public CoinGeckoService(HttpClient httpClient, IConfiguration config)
        {
            _httpClient = httpClient;
            _config = config;
        }

        public async Task<List<Coin>> GetTopCoinsAsync(int limit = 10)
        {
            string url = $"{_config["CoinGecko:BaseUrl"]}coins/markets?vs_currency=usd&order=market_cap_desc&per_page={limit}&page=1";
            var response = await _httpClient.GetStringAsync(url);
            return JsonConvert.DeserializeObject<List<Coin>>(response);
        }
    }
}