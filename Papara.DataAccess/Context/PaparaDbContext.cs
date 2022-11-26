using Microsoft.EntityFrameworkCore;
using Papara.Core.Configurations;
using Papara.Core.Entites;

namespace Papara.Infrastructure.Data
{
    public class PaparaDbContext : DbContext
    {
        public PaparaDbContext(DbContextOptions<PaparaDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }

        public DbSet<User> Users { get; set; }
    }
}
