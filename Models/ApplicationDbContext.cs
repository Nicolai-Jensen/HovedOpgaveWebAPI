using Microsoft.EntityFrameworkCore;
using HovedOpgaveWebAPI.Models;

namespace HovedOpgaveWebAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<GameData> GameData { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GameData>().HasKey(g => g.UserId); 
            modelBuilder.Entity<GameData>().Property(g => g.Body).HasColumnType("jsonb");
        }
    }
}