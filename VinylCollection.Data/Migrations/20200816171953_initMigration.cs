using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VinylCollection.Data.Migrations
{
    public partial class initMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Security");

            migrationBuilder.EnsureSchema(
                name: "Vinyl");

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "Security",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Deleted = table.Column<bool>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vinyl",
                schema: "Vinyl",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Deleted = table.Column<bool>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    Id_User = table.Column<int>(nullable: false),
                    Band = table.Column<string>(nullable: true),
                    Album = table.Column<string>(nullable: true),
                    Genre = table.Column<string>(nullable: true),
                    CoverURL = table.Column<string>(nullable: true),
                    DateReleased = table.Column<DateTime>(nullable: false),
                    Country = table.Column<string>(nullable: true),
                    Info = table.Column<string>(nullable: true),
                    Color = table.Column<string>(nullable: true),
                    Disc = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    Link = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    DatePublished = table.Column<DateTime>(nullable: true),
                    Notes = table.Column<string>(nullable: true),
                    Currency = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vinyl", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vinyl_Users_Id_User",
                        column: x => x.Id_User,
                        principalSchema: "Security",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_Id",
                schema: "Security",
                table: "Users",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vinyl_Id",
                schema: "Vinyl",
                table: "Vinyl",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Vinyl_Id_User",
                schema: "Vinyl",
                table: "Vinyl",
                column: "Id_User");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vinyl",
                schema: "Vinyl");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "Security");
        }
    }
}
