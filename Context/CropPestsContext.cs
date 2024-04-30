using Game_Unity.Models;
using Microsoft.EntityFrameworkCore;

namespace Game_Unity.Context
{
    public class CropPestsContext:DbContext
    {
        public CropPestsContext(DbContextOptions<CropPestsContext> options) : base(options)
        {


        }

        public DbSet<CropPestsModel> Crop_Pests { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CropPestsModel>().HasNoKey();
        }

    }
}
