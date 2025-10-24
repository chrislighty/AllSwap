using CryptoTracker.Models;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System;

namespace CryptoTracker.Services
{
    public class CoinGeckoService : ICoinGeckoService
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _config;
        private readonly IMemoryCache _cache;
        private const string TopCoinsCacheKey = "TopCoins";

        public CoinGeckoService(HttpClient httpClient, IConfiguration config, IMemoryCache cache)
        {
            _httpClient = httpClient;
            _config = config;
            _cache = cache;
        }

        public async Task<List<Coin>> GetTopCoinsAsync(int limit = 10)
        {
            if (_cache.TryGetValue(TopCoinsCacheKey, out List<Coin> cachedCoins))
            {
                return cachedCoins;
            }

            string url = $"{_config["CoinGecko:BaseUrl"]}coins/markets?vs_currency=usd&order=market_cap_desc&per_page={limit}&page=1";
            var response = await _httpClient.GetStringAsync(url);
            var coins = JsonConvert.DeserializeObject<List<Coin>>(response);

            var cacheEntryOptions = new MemoryCacheEntryOptions()
                .SetAbsoluteExpiration(TimeSpan.FromSeconds(60)); // Cache for 60 seconds

            _cache.Set(TopCoinsCacheKey, coins, cacheEntryOptions);

            return coins;
        }
    }
}
