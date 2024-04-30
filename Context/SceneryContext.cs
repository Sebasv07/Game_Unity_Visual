using Game_Unity.Models;
using Microsoft.EntityFrameworkCore;

namespace Game_Unity.Context
{
    public class SceneryContext: DbContext
    {
        public SceneryContext(DbContextOptions<SceneryContext> options) : base(options)
        {


        }

        public DbSet<SceneryModel> Sceneries { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SceneryModel>().HasKey(e => e.SceneryId);

        }
    }
}
