using Game_Unity.Models;
using Microsoft.EntityFrameworkCore;

namespace Game_Unity.Context
{
    public class ScoreContext: DbContext
    {
        public ScoreContext(DbContextOptions<ScoreContext> options) : base(options)
        {


        }

        public DbSet<ScoreModel> Scores { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ScoreModel>().HasKey(e => e.ScoreId);

        }

    }
}
