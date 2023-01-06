using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace easymealapi.Migrations
{
    /// <inheritdoc />
    public partial class addeduseridinrepas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Repas",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Repas");
        }
    }
}
