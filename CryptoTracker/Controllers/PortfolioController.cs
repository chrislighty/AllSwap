using CryptoTracker.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CryptoTracker.Controllers
{
    public class PortfolioController : Controller
    {
        // In a real application, you would inject a service to handle portfolio data.
        // For this example, we'll use a mock service.
        public PortfolioController()
        {
        }

        public async Task<IActionResult> Index()
        {
            // Mock data for demonstration purposes.
            var mockPortfolio = new List<Portfolio>
            {
                new Portfolio { UserId = "demo_user", TokenSymbol = "BTC", Amount = 0.5m },
                new Portfolio { UserId = "demo_user", TokenSymbol = "ETH", Amount = 12.25m },
                new Portfolio { UserId = "demo_user", TokenSymbol = "USDT", Amount = 5000m }
            };

            await Task.Delay(10); // Simulate async operation

            return View(mockPortfolio);
        }
    }
}
