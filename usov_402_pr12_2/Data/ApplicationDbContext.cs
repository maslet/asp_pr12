using Microsoft.EntityFrameworkCore;
using usov_402_pr12_2.Models;

namespace usov_402_pr12_2.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Company> Companies { get; set; }
    }
}
