using Game_Unity.Models;
using Microsoft.EntityFrameworkCore;

namespace Game_Unity.Context
{
    public class PlagueContext:DbContext
    {
        public PlagueContext(DbContextOptions<PlagueContext> options) : base(options)
        {


        }

        public DbSet<PlagueModel> Plagues { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PlagueModel>().HasKey(e => e.PlagueId);

        }
    }

}

