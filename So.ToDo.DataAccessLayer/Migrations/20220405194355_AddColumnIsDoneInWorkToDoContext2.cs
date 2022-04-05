using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace So.ToDo.DataAccessLayer.Migrations
{
    public partial class AddColumnIsDoneInWorkToDoContext2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ntext",
                table: "Works",
                newName: "Description");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Works",
                type: "ntext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Works",
                newName: "ntext");

            migrationBuilder.AlterColumn<string>(
                name: "ntext",
                table: "Works",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "ntext");
        }
    }
}
