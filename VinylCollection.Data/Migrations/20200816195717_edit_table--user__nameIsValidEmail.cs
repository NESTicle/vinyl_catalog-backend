using Microsoft.EntityFrameworkCore.Migrations;

namespace VinylCollection.Data.Migrations
{
    public partial class edit_tableuser__nameIsValidEmail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsEmailValid",
                schema: "Security",
                table: "Users",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                schema: "Security",
                table: "Users",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsEmailValid",
                schema: "Security",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Name",
                schema: "Security",
                table: "Users");
        }
    }
}
