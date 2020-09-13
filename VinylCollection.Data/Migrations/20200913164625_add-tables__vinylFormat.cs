using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VinylCollection.Data.Migrations
{
    public partial class addtables__vinylFormat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Id_VinylFormat",
                schema: "Vinyl",
                table: "Vinyl",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "VinylFormats",
                schema: "Vinyl",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Deleted = table.Column<bool>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(maxLength: 80, nullable: false),
                    Description = table.Column<string>(maxLength: 300, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VinylFormats", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vinyl_Id_VinylFormat",
                schema: "Vinyl",
                table: "Vinyl",
                column: "Id_VinylFormat");

            migrationBuilder.CreateIndex(
                name: "IX_VinylFormats_Id",
                schema: "Vinyl",
                table: "VinylFormats",
                column: "Id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Vinyl_VinylFormats_Id_VinylFormat",
                schema: "Vinyl",
                table: "Vinyl",
                column: "Id_VinylFormat",
                principalSchema: "Vinyl",
                principalTable: "VinylFormats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vinyl_VinylFormats_Id_VinylFormat",
                schema: "Vinyl",
                table: "Vinyl");

            migrationBuilder.DropTable(
                name: "VinylFormats",
                schema: "Vinyl");

            migrationBuilder.DropIndex(
                name: "IX_Vinyl_Id_VinylFormat",
                schema: "Vinyl",
                table: "Vinyl");

            migrationBuilder.DropColumn(
                name: "Id_VinylFormat",
                schema: "Vinyl",
                table: "Vinyl");
        }
    }
}
