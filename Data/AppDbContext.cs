using Microsoft.EntityFrameworkCore;
using resep_langkah.Models;

namespace resep_langkah.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Resep> Resep { get; set; }
        public DbSet<Langkah> Langkah { get; set; }
        public DbSet<Parameter> Parameter { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Langkah>()
                .HasOne(l => l.ParentLangkah)
                .WithMany(l => l.SubLangkahs)
                .HasForeignKey(l => l.ParentLangkahId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
