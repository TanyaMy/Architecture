using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Architecture.Data;
using Architecture.Data.Entities;

namespace Architecture.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20161113171103_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-preview1-22509");

            modelBuilder.Entity("Architecture.Data.Entities.Architect", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("BirthDate");

                    b.Property<DateTime>("DeathDate");

                    b.Property<string>("Name");

                    b.Property<string>("Nationality");

                    b.Property<string>("Surname");

                    b.HasKey("Id");

                    b.ToTable("Architects");
                });

            modelBuilder.Entity("Architecture.Data.Entities.Architecture", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<int>("ArchitectId");

                    b.Property<string>("City");

                    b.Property<string>("Country");

                    b.Property<int>("CreationYear");

                    b.Property<double>("Height");

                    b.Property<double>("Square");

                    b.Property<int>("State");

                    b.Property<int>("StyleId");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("ArchitectId");

                    b.HasIndex("StyleId");

                    b.ToTable("Architectures");
                });

            modelBuilder.Entity("Architecture.Data.Entities.ArchitectureSource", b =>
                {
                    b.Property<int>("ArchitectureId");

                    b.Property<int>("SourceId");

                    b.HasKey("ArchitectureId", "SourceId");

                    b.HasIndex("SourceId");

                    b.ToTable("ArchitectureSource");
                });

            modelBuilder.Entity("Architecture.Data.Entities.Repair", b =>
                {
                    b.Property<int>("ArchitectureId");

                    b.Property<int>("RestorationKind");

                    b.Property<double>("RestorationCost");

                    b.Property<DateTime>("RestorationDate");

                    b.HasKey("ArchitectureId", "RestorationKind");

                    b.HasIndex("RestorationKind");

                    b.ToTable("Repairs");
                });

            modelBuilder.Entity("Architecture.Data.Entities.Restoration", b =>
                {
                    b.Property<int>("RestorationKind");

                    b.Property<double>("Outlays");

                    b.Property<string>("Periodicity");

                    b.HasKey("RestorationKind");

                    b.ToTable("Restorations");
                });

            modelBuilder.Entity("Architecture.Data.Entities.Source", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Author");

                    b.Property<int>("CreationYear");

                    b.Property<int>("SourceKind");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Sources");
                });

            modelBuilder.Entity("Architecture.Data.Entities.Style", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Era");

                    b.Property<string>("MotherCountry");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.ToTable("Styles");
                });

            modelBuilder.Entity("Architecture.Data.Entities.Architecture", b =>
                {
                    b.HasOne("Architecture.Data.Entities.Architect", "Architect")
                        .WithMany()
                        .HasForeignKey("ArchitectId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Architecture.Data.Entities.Style", "Style")
                        .WithMany()
                        .HasForeignKey("StyleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Architecture.Data.Entities.ArchitectureSource", b =>
                {
                    b.HasOne("Architecture.Data.Entities.Architecture", "Architecture")
                        .WithMany("ArchitecturesSources")
                        .HasForeignKey("ArchitectureId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Architecture.Data.Entities.Source", "Source")
                        .WithMany("ArchitecturesSources")
                        .HasForeignKey("SourceId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Architecture.Data.Entities.Repair", b =>
                {
                    b.HasOne("Architecture.Data.Entities.Architecture", "Architecture")
                        .WithMany("Repairs")
                        .HasForeignKey("ArchitectureId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Architecture.Data.Entities.Restoration")
                        .WithMany("Repairs")
                        .HasForeignKey("RestorationKind")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
