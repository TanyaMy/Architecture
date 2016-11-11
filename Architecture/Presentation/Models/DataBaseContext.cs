using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Architecture.Presentation.Models
{
    public class DataBaseContext : DbContext
    {
        public DbSet<Architecture> Architectures { get; set; }
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
            // Make Id required
            modelBuilder.Entity<Architecture>()
                .Property(a => a.ArchitectureId)
                .IsRequired();

            modelBuilder.Entity<Architect>()
                .Property(a => a.ArchitectId)
                .IsRequired();

            modelBuilder.Entity<Style>()
                .Property(s => s.StyleId)
                .IsRequired();

            modelBuilder.Entity<Repair>()
                .Property(r => r.RestorationKind)
                .IsRequired();

            modelBuilder.Entity<Repair>()
                .Property(r => r.ArchitectureId)
                .IsRequired();

            modelBuilder.Entity<Restoration>()
                .Property(r => r.RestorationKind)
                .IsRequired();

            modelBuilder.Entity<Source>()
                .Property(s => s.SourceId)
                .IsRequired();
        }
    }
}
