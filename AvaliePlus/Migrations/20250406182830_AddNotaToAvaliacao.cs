using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AvaliePlus.Migrations
{
    /// <inheritdoc />
    public partial class AddNotaToAvaliacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Nota",
                table: "Avaliacoes",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nota",
                table: "Avaliacoes");
        }
    }
}
