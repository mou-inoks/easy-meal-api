using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace easymealapi.Migrations
{
    /// <inheritdoc />
    public partial class @new : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserDaoId",
                table: "Repas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Repas_UserDaoId",
                table: "Repas",
                column: "UserDaoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Repas_Users_UserDaoId",
                table: "Repas",
                column: "UserDaoId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Repas_Users_UserDaoId",
                table: "Repas");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Repas_UserDaoId",
                table: "Repas");

            migrationBuilder.DropColumn(
                name: "UserDaoId",
                table: "Repas");
        }
    }
}
