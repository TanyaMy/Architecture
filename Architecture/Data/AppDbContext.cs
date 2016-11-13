using Architecture.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Architecture.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Entities.Architecture> Architectures { get; set; }

        public DbSet<ArchitectureSource> ArchitecturesSources { get; set; }

        public DbSet<Architect> Architects { get; set; }

        public DbSet<Style> Styles { get; set; }

        public DbSet<Repair> Repairs { get; set; }

        public DbSet<Restoration> Restorations { get; set; }

        public DbSet<Source> Sources { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=Architecture.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ArchitectureSource>()
                .HasKey(x => new { x.ArchitectureId, x.SourceId });

            modelBuilder.Entity<Repair>()
                .HasKey(x => new { x.ArchitectureId, x.RestorationKind });
        }
    }
}
