using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inventory_System_Template_Web_App.Migrations
{
    /// <inheritdoc />
    public partial class appuser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "ProgramUsers",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "Items",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "Milage",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Pace",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "Accounts",
                type: "varchar(255)",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ProgramUsers_AppUserId",
                table: "ProgramUsers",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_AppUserId",
                table: "Items",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_AppUserId",
                table: "Accounts",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_AspNetUsers_AppUserId",
                table: "Accounts",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_AspNetUsers_AppUserId",
                table: "Items",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProgramUsers_AspNetUsers_AppUserId",
                table: "ProgramUsers",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_AspNetUsers_AppUserId",
                table: "Accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_AspNetUsers_AppUserId",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_ProgramUsers_AspNetUsers_AppUserId",
                table: "ProgramUsers");

            migrationBuilder.DropIndex(
                name: "IX_ProgramUsers_AppUserId",
                table: "ProgramUsers");

            migrationBuilder.DropIndex(
                name: "IX_Items_AppUserId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_AppUserId",
                table: "Accounts");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "ProgramUsers");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Milage",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Pace",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Accounts");
        }
    }
}
