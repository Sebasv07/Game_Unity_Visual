using Game_Unity.Models;
using Microsoft.EntityFrameworkCore;

namespace Game_Unity.Context
{
    public class BatchContext:DbContext
    {
        public BatchContext(DbContextOptions<BatchContext> options) : base(options)
        {


        }

        public DbSet<BatchModel> Batches { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BatchModel>().HasKey(e => e.BachnetId);

        }
    }
}
