using Game_Unity.Models;
using Microsoft.EntityFrameworkCore;

namespace Game_Unity.Context
{
    public class FertilizersContext:DbContext
    {
        public FertilizersContext(DbContextOptions<FertilizersContext> options) : base(options)
        {


        }

        public DbSet<FertilizersModel> Fertilizers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FertilizersModel>().HasKey(e => e.FertilizerId);

        }
    }
}
