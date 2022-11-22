using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SampleBid2.Models;

namespace SampleBid2.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Trophy> Trophies { get; set; }
        public DbSet<Player> players { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Biding> Bidings { get; set; }
        
        
    }
}