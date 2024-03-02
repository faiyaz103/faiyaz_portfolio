using faiyaz_portfolio.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace faiyaz_portfolio.Data
{
    public class ApplicationDbContext:IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Experience> Experiences { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Experience>().HasData(
                new Experience { Id = 1, Name = "HTML", Description = "Professional" },
                new Experience { Id = 2, Name = "CSS", Description = "Basic" }
                );
        }
    }
}
