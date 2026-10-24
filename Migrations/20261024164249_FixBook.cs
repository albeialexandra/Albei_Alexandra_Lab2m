using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Albei_Alexandra_Lab2m.Migrations
{
    /// <inheritdoc />
    public partial class FixBook : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Adress",
                table: "Publisher",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Adress",
                table: "Publisher");
        }
    }
}
