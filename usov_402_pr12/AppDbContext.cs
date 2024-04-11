using Microsoft.EntityFrameworkCore;

namespace usov_402_pr12
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer(@"Server=localhost;Database=master;Trusted_Connection=True;TrustServerCertificate=True;");
    }
}
