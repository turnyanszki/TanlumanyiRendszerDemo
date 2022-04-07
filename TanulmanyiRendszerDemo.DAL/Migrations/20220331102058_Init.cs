using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TanulmanyiRendszerDemo.DAL.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Szemeszterek",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Megnevezes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Kezdet = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Veg = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TargyjelentkezesKezdet = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TargyJelentkezesVeg = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VizsgajelentkezesKezdet = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VizsgajelentkezesVeg = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Szemeszterek", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Szemeszterek");
        }
    }
}
