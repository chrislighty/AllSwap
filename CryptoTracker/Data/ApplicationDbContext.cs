using CryptoTracker.Models;
using Microsoft.EntityFrameworkCore;

namespace CryptoTracker.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Portfolio> Portfolios { get; set; }
    }
}
