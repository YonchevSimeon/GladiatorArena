using Microsoft.EntityFrameworkCore.Migrations;

namespace GladiatorArena.Data.Migrations
{
    public partial class BasicHeroAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HeroId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Heroes",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Strength = table.Column<int>(nullable: false),
                    Armour = table.Column<int>(nullable: false),
                    MinDamage = table.Column<int>(nullable: false),
                    MaxDamage = table.Column<int>(nullable: false),
                    OwnerId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Heroes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_HeroId",
                table: "AspNetUsers",
                column: "HeroId",
                unique: true,
                filter: "[HeroId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Heroes_HeroId",
                table: "AspNetUsers",
                column: "HeroId",
                principalTable: "Heroes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Heroes_HeroId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Heroes");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_HeroId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "HeroId",
                table: "AspNetUsers");
        }
    }
}
