using Game_Unity.Models;
using Microsoft.EntityFrameworkCore;

namespace Game_Unity.Context
{
    public class MaturationMonitoringContext:DbContext
    {
        public MaturationMonitoringContext(DbContextOptions<MaturationMonitoringContext> options) : base(options)
        {


        }

        public DbSet<MaturationMonitoringModel> MaturationMonitorings { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MaturationMonitoringModel>().HasKey(e => e.MaturationMonitoringId);

        }

    }
}
