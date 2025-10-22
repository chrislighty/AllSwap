using CryptoTracker.Models;
using CryptoTracker.Services;
using Microsoft.AspNetCore.Mvc;

namespace CryptoTracker.Controllers
{
    public class DexController : Controller
    {
        private readonly IDexService _dexService;
        public DexController(IDexService dexService)
        {
            _dexService = dexService;
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