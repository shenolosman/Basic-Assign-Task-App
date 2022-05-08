using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace So.ToDo.DataAccessLayer.Migrations
{
    public partial class RapportTitlePropChange2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Defination",
                table: "Rapports",
                newName: "Title");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Rapports",
                newName: "Defination");
        }
    }
}
