using Game_Unity.Models;
using Microsoft.EntityFrameworkCore;

namespace Game_Unity.Context
{
    public class DetectiveCluesContext: DbContext
    {
        public DetectiveCluesContext(DbContextOptions<DetectiveCluesContext> options) : base(options)
        {


        }

        public DbSet<DetectiveCluesModel> DetectiveClues { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DetectiveCluesModel>().HasKey(e => e.DetectiveCluesId);

        }

    }
}
