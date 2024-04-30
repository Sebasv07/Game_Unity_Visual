using Game_Unity.Models;
using Microsoft.EntityFrameworkCore;

namespace Game_Unity.Context
{
    public class AvatarLocationContext: DbContext
    {
        public AvatarLocationContext(DbContextOptions<AvatarLocationContext> options) : base(options)
        {


        }

        public DbSet<AvatarLocationModel> AvatarLocations { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AvatarLocationModel>().HasKey(e => e.AvatarLocationId);

        }

    }
}
