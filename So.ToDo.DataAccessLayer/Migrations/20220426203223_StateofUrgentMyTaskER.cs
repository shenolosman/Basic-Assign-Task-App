using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace So.ToDo.DataAccessLayer.Migrations
{
    public partial class StateofUrgentMyTaskER : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StateOfUrgentId",
                table: "MyTasks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "StateOfUrgents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StateOfUrgents", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MyTasks_StateOfUrgentId",
                table: "MyTasks",
                column: "StateOfUrgentId");

            migrationBuilder.AddForeignKey(
                name: "FK_MyTasks_StateOfUrgents_StateOfUrgentId",
                table: "MyTasks",
                column: "StateOfUrgentId",
                principalTable: "StateOfUrgents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MyTasks_StateOfUrgents_StateOfUrgentId",
                table: "MyTasks");

            migrationBuilder.DropTable(
                name: "StateOfUrgents");

            migrationBuilder.DropIndex(
                name: "IX_MyTasks_StateOfUrgentId",
                table: "MyTasks");

            migrationBuilder.DropColumn(
                name: "StateOfUrgentId",
                table: "MyTasks");
        }
    }
}
