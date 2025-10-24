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

        [HttpPost]
        public async Task<IActionResult> RecordSwap([FromBody] SwapResult result)
        {
            if (result == null || result.AmountIn <= 0 || result.AmountOut <= 0)
            {
                return BadRequest("Invalid swap data.");
            }

            const string demoUserId = "demo_user"; // In a real app, you would get this from authentication.

            // Decrease the balance of the token sold
            await _portfolioService.UpdatePortfolioAsync(demoUserId, result.TokenIn, -result.AmountIn);

            // Increase the balance of the token bought
            await _portfolioService.UpdatePortfolioAsync(demoUserId, result.TokenOut, result.AmountOut);

            return Ok(new { message = "Portfolio updated successfully." });
        }
    }
}