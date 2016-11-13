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
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<int>("WorksInId");

                    b.HasKey("Id");

                    b.HasIndex("WorksInId");

                    b.ToTable("Architects");
                });

            modelBuilder.Entity("Architecture.Data.Entities.Architecture", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<int>("ArchitectId");

                    b.Property<int?>("ArchitectId1");

                    b.Property<int>("BuiltBy");

                    b.Property<string>("City");

                    b.Property<string>("Country");

                    b.Property<int>("CreationYear");

                    b.Property<double>("Height");

                    b.Property<int>("RepairNeeds");

                    b.Property<double>("Square");

                    b.Property<int>("State");

                    b.Property<int>("StyleId");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("ArchitectId");

                    b.HasIndex("ArchitectId1");

                    b.HasIndex("StyleId");

                    b.ToTable("Architectures");
                });

            modelBuilder.Entity("Architecture.Data.Entities.Repair", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ArchitectureId");

                    b.Property<int>("CorrespondsWithRestorationKindId");

                    b.Property<double>("RestorationCost");

                    b.Property<DateTime>("RestorationDate");

                    b.Property<int>("RestorationKind");

                    b.HasKey("Id");

                    b.HasIndex("ArchitectureId")
                        .IsUnique();

                    b.HasIndex("CorrespondsWithRestorationKindId");

                    b.ToTable("Repairs");
                });

            modelBuilder.Entity("Architecture.Data.Entities.Restoration", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("Outlays");

                    b.Property<string>("Periodicity");

                    b.Property<int>("RestorationKind");

                    b.HasKey("Id");

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

            modelBuilder.Entity("Architecture.Data.Entities.Architect", b =>
                {
                    b.HasOne("Architecture.Data.Entities.Style", "WorksIn")
                        .WithMany()
                        .HasForeignKey("WorksInId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Architecture.Data.Entities.Architecture", b =>
                {
                    b.HasOne("Architecture.Data.Entities.Architect", "Architect")
                        .WithMany()
                        .HasForeignKey("ArchitectId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Architecture.Data.Entities.Architect", "BuiltById")
                        .WithMany()
                        .HasForeignKey("ArchitectId1");

                    b.HasOne("Architecture.Data.Entities.Style", "Style")
                        .WithMany()
                        .HasForeignKey("StyleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Architecture.Data.Entities.Repair", b =>
                {
                    b.HasOne("Architecture.Data.Entities.Architecture", "Architecture")
                        .WithOne("RepairNeedsId")
                        .HasForeignKey("Architecture.Data.Entities.Repair", "ArchitectureId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Architecture.Data.Entities.Restoration", "CorrespondsWithRestorationKind")
                        .WithMany()
                        .HasForeignKey("CorrespondsWithRestorationKindId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
