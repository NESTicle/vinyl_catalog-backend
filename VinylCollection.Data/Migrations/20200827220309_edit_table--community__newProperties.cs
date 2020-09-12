using Microsoft.EntityFrameworkCore.Migrations;

namespace VinylCollection.Data.Migrations
{
    public partial class edit_tablecommunity__newProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Background",
                schema: "Community",
                table: "Communities",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CommentRule",
                schema: "Community",
                table: "Communities",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "NSFW",
                schema: "Community",
                table: "Communities",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "PublishRule",
                schema: "Community",
                table: "Communities",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "URL",
                schema: "Community",
                table: "Communities",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Background",
                schema: "Community",
                table: "Communities");

            migrationBuilder.DropColumn(
                name: "CommentRule",
                schema: "Community",
                table: "Communities");

            migrationBuilder.DropColumn(
                name: "NSFW",
                schema: "Community",
                table: "Communities");

            migrationBuilder.DropColumn(
                name: "PublishRule",
                schema: "Community",
                table: "Communities");

            migrationBuilder.DropColumn(
                name: "URL",
                schema: "Community",
                table: "Communities");
        }
    }
}
