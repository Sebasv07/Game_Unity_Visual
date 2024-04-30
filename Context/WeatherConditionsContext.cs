using Game_Unity.Models;
using Microsoft.EntityFrameworkCore;

namespace Game_Unity.Context
{
    public class WeatherConditionsContext:DbContext
    {
        public WeatherConditionsContext(DbContextOptions<WeatherConditionsContext> options) : base(options)
        {


        }

        public DbSet<WeathercontitionsModel> weatherconditions { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WeathercontitionsModel>().HasKey(e => e.WeatherContitionId);

        }
    }

}

