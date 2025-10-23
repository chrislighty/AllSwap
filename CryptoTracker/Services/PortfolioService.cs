using CryptoTracker.Data;
using CryptoTracker.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CryptoTracker.Services
{
    public class PortfolioService : IPortfolioService
    {
        private readonly ApplicationDbContext _context;

        public PortfolioService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Portfolio>> GetPortfolioAsync(string userId)
        {
            return await _context.Portfolios
                .Where(p => p.UserId == userId)
                .ToListAsync();
        }

        public async Task UpdatePortfolioAsync(string userId, string tokenSymbol, decimal amount)
        {
            var existingHolding = await _context.Portfolios
                .FirstOrDefaultAsync(p => p.UserId == userId && p.TokenSymbol == tokenSymbol);

            if (existingHolding != null)
            {
                existingHolding.Amount += amount;
                if (existingHolding.Amount <= 0)
                {
                    _context.Portfolios.Remove(existingHolding);
                }
            }
            else
            {
                if (amount > 0)
                {
                    _context.Portfolios.Add(new Portfolio
                    {
                        UserId = userId,
                        TokenSymbol = tokenSymbol,
                        Amount = amount
                    });
                }
            }

            await _context.SaveChangesAsync();
        }
    }
}
