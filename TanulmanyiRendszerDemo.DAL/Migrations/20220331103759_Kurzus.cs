using Microsoft.EntityFrameworkCore.Migrations;

namespace TanulmanyiRendszerDemo.DAL.Migrations
{
    public partial class Kurzus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kurzusok",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Megnevezes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OktatoNev = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SzemeszterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kurzusok", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Kurzusok_Szemeszterek_SzemeszterId",
                        column: x => x.SzemeszterId,
                        principalTable: "Szemeszterek",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Kurzusok_SzemeszterId",
                table: "Kurzusok",
                column: "SzemeszterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Kurzusok");
        }
    }
}
