using Game_Unity.Models;
using Microsoft.EntityFrameworkCore;

namespace Game_Unity.Context
{
    public class CropContext: DbContext
    {
        public CropContext(DbContextOptions<CropContext> options) : base(options)
        {


        }

        public DbSet<CropModel> Crops { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CropModel>().HasKey(e => e.CropId);

        }
    }
}

