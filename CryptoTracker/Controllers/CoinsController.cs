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

        public IActionResult Chart(string coinId)
        {
            if (string.IsNullOrEmpty(coinId))
            {
                return RedirectToAction("Index");
            }
            ViewBag.CoinId = coinId;
            return View();
        }
    }
}