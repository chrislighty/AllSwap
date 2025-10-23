using CryptoTracker.Models;
using CryptoTracker.Services;
using Microsoft.AspNetCore.Mvc;

namespace CryptoTracker.Controllers
{
    public class DexController : Controller
    {
        private readonly IDexService _dexService;
        private readonly IPortfolioService _portfolioService;

        public DexController(IDexService dexService, IPortfolioService portfolioService)
        {
            _dexService = dexService;
            _portfolioService = portfolioService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(new TokenSwap());
        }

        [HttpPost]
        public async Task<IActionResult> Index(TokenSwap model)
        {
            if (ModelState.IsValid)
            {
                var result = await _dexService.GetEstimatedSwapAsync(model.TokenIn, model.TokenOut, model.AmountIn);
                return View(result);
            }
            return View(model);
        }
    }
}