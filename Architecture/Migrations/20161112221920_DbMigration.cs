using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Architecture.Migrations
{
    public partial class DbMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Restorations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Outlays = table.Column<double>(nullable: false),
                    Periodicity = table.Column<string>(nullable: true),
                    RestorationKind = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restorations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sources",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Author = table.Column<string>(nullable: true),
                    CreationYear = table.Column<int>(nullable: false),
                    SourceKind = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sources", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Styles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Era = table.Column<string>(nullable: true),
                    MotherCountry = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Styles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Architects",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BirthDate = table.Column<DateTime>(nullable: false),
                    DeathDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Nationality = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    WorksInId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Architects", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Architects_Styles_WorksInId",
                        column: x => x.WorksInId,
                        principalTable: "Styles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Architectures",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Address = table.Column<string>(nullable: true),
                    ArchitectId = table.Column<int>(nullable: false),
                    ArchitectId1 = table.Column<int>(nullable: true),
                    BuiltBy = table.Column<int>(nullable: false),
                    City = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    CreationYear = table.Column<int>(nullable: false),
                    Height = table.Column<double>(nullable: false),
                    RepairNeeds = table.Column<int>(nullable: false),
                    Square = table.Column<double>(nullable: false),
                    State = table.Column<int>(nullable: false),
                    StyleId = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Architectures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Architectures_Architects_ArchitectId",
                        column: x => x.ArchitectId,
                        principalTable: "Architects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Architectures_Architects_ArchitectId1",
                        column: x => x.ArchitectId1,
                        principalTable: "Architects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Architectures_Styles_StyleId",
                        column: x => x.StyleId,
                        principalTable: "Styles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Repairs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ArchitectureId = table.Column<int>(nullable: false),
                    CorrespondsWithRestorationKindId = table.Column<int>(nullable: false),
                    RestorationCost = table.Column<double>(nullable: false),
                    RestorationDate = table.Column<DateTime>(nullable: false),
                    RestorationKind = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Repairs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Repairs_Architectures_ArchitectureId",
                        column: x => x.ArchitectureId,
                        principalTable: "Architectures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Repairs_Restorations_CorrespondsWithRestorationKindId",
                        column: x => x.CorrespondsWithRestorationKindId,
                        principalTable: "Restorations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Architects_WorksInId",
                table: "Architects",
                column: "WorksInId");

            migrationBuilder.CreateIndex(
                name: "IX_Architectures_ArchitectId",
                table: "Architectures",
                column: "ArchitectId");

            migrationBuilder.CreateIndex(
                name: "IX_Architectures_ArchitectId1",
                table: "Architectures",
                column: "ArchitectId1");

            migrationBuilder.CreateIndex(
                name: "IX_Architectures_StyleId",
                table: "Architectures",
                column: "StyleId");

            migrationBuilder.CreateIndex(
                name: "IX_Repairs_ArchitectureId",
                table: "Repairs",
                column: "ArchitectureId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Repairs_CorrespondsWithRestorationKindId",
                table: "Repairs",
                column: "CorrespondsWithRestorationKindId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Repairs");

            migrationBuilder.DropTable(
                name: "Sources");

            migrationBuilder.DropTable(
                name: "Architectures");

            migrationBuilder.DropTable(
                name: "Restorations");

            migrationBuilder.DropTable(
                name: "Architects");

            migrationBuilder.DropTable(
                name: "Styles");
        }
    }
}
