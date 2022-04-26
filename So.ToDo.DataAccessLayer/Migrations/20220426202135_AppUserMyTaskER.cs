using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace So.ToDo.DataAccessLayer.Migrations
{
    public partial class AppUserMyTaskER : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AppUserId",
                table: "MyTasks",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Surname",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_MyTasks_AppUserId",
                table: "MyTasks",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_MyTasks_AspNetUsers_AppUserId",
                table: "MyTasks",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MyTasks_AspNetUsers_AppUserId",
                table: "MyTasks");

            migrationBuilder.DropIndex(
                name: "IX_MyTasks_AppUserId",
                table: "MyTasks");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "MyTasks");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Surname",
                table: "AspNetUsers");
        }
    }
}
