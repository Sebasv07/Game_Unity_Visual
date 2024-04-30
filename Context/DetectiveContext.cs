using Game_Unity.Models;
using Microsoft.EntityFrameworkCore;

namespace Game_Unity.Context
{
    public class DetectiveContext: DbContext
    {
        public DetectiveContext(DbContextOptions<DetectiveContext> options) : base(options)
        {


        }

        public DbSet<DetectiveModel> Detectives { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DetectiveModel>().HasKey(e => e.DetectiveId);

        }
    }
}
