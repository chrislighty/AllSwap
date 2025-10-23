using CryptoTracker.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CryptoTracker.Controllers
{
    public class PortfolioController : Controller
    {
        private readonly IPortfolioService _portfolioService;
        private const string DemoUserId = "demo_user"; // In a real app, you would get this from authentication.

        public PortfolioController(IPortfolioService portfolioService)
        {
            _portfolioService = portfolioService;
        }

        public async Task<IActionResult> Index()
        {
            var portfolio = await _portfolioService.GetPortfolioAsync(DemoUserId);
            return View(portfolio);
        }
    }
}
