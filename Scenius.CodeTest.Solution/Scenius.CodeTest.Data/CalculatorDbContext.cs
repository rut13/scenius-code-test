using Microsoft.EntityFrameworkCore;
using Scenius.CodeTest.Shared;

namespace Scenius.CodeTest.Data
{
    public class CalculatorDbContext : DbContext
    {
        public DbSet<CalculationResult> CalculationResults { get; set; }

        public CalculatorDbContext(DbContextOptions<CalculatorDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}