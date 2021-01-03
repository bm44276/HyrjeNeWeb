using Microsoft.EntityFrameworkCore.Migrations;

namespace Library_Managment.Data.Migrations
{
    public partial class booktableupdates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Amount",
                table: "Books",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Available",
                table: "Books",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Genre",
                table: "Books",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "Available",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "Genre",
                table: "Books");
        }
    }
}
