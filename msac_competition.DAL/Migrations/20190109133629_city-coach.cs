using Microsoft.EntityFrameworkCore.Migrations;

namespace msac_competition.DAL.Migrations
{
    public partial class citycoach : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CityId",
                table: "Coaches",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Coaches_CityId",
                table: "Coaches",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Coaches_Cities_CityId",
                table: "Coaches",
                column: "CityId",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Coaches_Cities_CityId",
                table: "Coaches");

            migrationBuilder.DropIndex(
                name: "IX_Coaches_CityId",
                table: "Coaches");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "Coaches");
        }
    }
}
