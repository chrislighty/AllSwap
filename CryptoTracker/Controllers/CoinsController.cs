using CryptoTracker.Services;
using Microsoft.AspNetCore.Mvc;

namespace CryptoTracker.Controllers
{
    public class CoinsController : Controller
    {
        private readonly ICoinGeckoService _coinService;
        public CoinsController(ICoinGeckoService coinService)
        {
            _coinService = coinService;
        }

        public async Task<IActionResult> Index()
        {
            var coins = await _coinService.GetTopCoinsAsync();
            return View(coins);
        }
    }
}