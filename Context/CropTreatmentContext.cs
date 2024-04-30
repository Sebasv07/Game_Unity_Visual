using Game_Unity.Models;
using Microsoft.EntityFrameworkCore;

namespace Game_Unity.Context
{
    public class CropTreatmentContext:DbContext
    {
        public CropTreatmentContext(DbContextOptions<CropTreatmentContext> options) : base(options)
        {


        }

        public DbSet<CropTreatmentModel> CropTreatments { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CropTreatmentModel>().HasKey(e => e.CropTreatmentId);

        }

    }
}
