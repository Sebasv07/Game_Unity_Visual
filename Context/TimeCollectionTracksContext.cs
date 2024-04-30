using Game_Unity.Models;
using Microsoft.EntityFrameworkCore;

namespace Game_Unity.Context
{
    public class TimeCollectionTracksContext: DbContext
    {
        public TimeCollectionTracksContext(DbContextOptions<TimeCollectionTracksContext> options) : base(options)
        {


        }

        public DbSet<TimeCollectionTracksModel> TimeCollectionTracks { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TimeCollectionTracksModel>().HasKey(e => e.TimeCollectionTracksId);

        }
    }
}
