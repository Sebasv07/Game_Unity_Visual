using Game_Unity.Models;
using Microsoft.EntityFrameworkCore;

namespace Game_Unity.Context
{
    public class SoilQualityContext:DbContext
    {
        public SoilQualityContext(DbContextOptions<SoilQualityContext> options) : base(options)
        {


        }

        public DbSet<SoilQualityModel> SoilQualitys { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SoilQualityModel>().HasKey(e => e.SoilQualityId);

        }
    }
}
