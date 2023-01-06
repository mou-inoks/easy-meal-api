using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace easymealapi.Migrations
{
    /// <inheritdoc />
    public partial class removeduserrepasid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Repas_Users_UserDaoId",
                table: "Repas");

            migrationBuilder.DropIndex(
                name: "IX_Repas_UserDaoId",
                table: "Repas");

            migrationBuilder.DropColumn(
                name: "UserDaoId",
                table: "Repas");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Repas");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserDaoId",
                table: "Repas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Repas",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
    }
}
