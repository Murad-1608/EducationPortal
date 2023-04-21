using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddVacancyTable1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AppUserId",
                table: "Vacancies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AppUserId",
                table: "Announcements",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Vacancies_AppUserId",
                table: "Vacancies",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Announcements_AppUserId",
                table: "Announcements",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Announcements_AspNetUsers_AppUserId",
                table: "Announcements",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vacancies_AspNetUsers_AppUserId",
                table: "Vacancies",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Announcements_AspNetUsers_AppUserId",
                table: "Announcements");

            migrationBuilder.DropForeignKey(
                name: "FK_Vacancies_AspNetUsers_AppUserId",
                table: "Vacancies");

            migrationBuilder.DropIndex(
                name: "IX_Vacancies_AppUserId",
                table: "Vacancies");

            migrationBuilder.DropIndex(
                name: "IX_Announcements_AppUserId",
                table: "Announcements");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Vacancies");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Announcements");
        }
    }
}
