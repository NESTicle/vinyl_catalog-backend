using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VinylCollection.Data.Migrations
{
    public partial class addtables__genre_subGenre : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DatePublished",
                schema: "Vinyl",
                table: "Vinyl");

            migrationBuilder.DropColumn(
                name: "Genre",
                schema: "Vinyl",
                table: "Vinyl");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                schema: "Vinyl",
                table: "Vinyl",
                type: "Money",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AddColumn<int>(
                name: "Id_SubGenre",
                schema: "Vinyl",
                table: "Vinyl",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Genres",
                schema: "Parameters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Deleted = table.Column<bool>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubGenres",
                schema: "Parameters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Deleted = table.Column<bool>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    Id_Genre = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubGenres", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubGenres_Genres_Id_Genre",
                        column: x => x.Id_Genre,
                        principalSchema: "Parameters",
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vinyl_Id_SubGenre",
                schema: "Vinyl",
                table: "Vinyl",
                column: "Id_SubGenre");

            migrationBuilder.CreateIndex(
                name: "IX_Genres_Id_Name",
                schema: "Parameters",
                table: "Genres",
                columns: new[] { "Id", "Name" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SubGenres_Id_Genre",
                schema: "Parameters",
                table: "SubGenres",
                column: "Id_Genre");

            migrationBuilder.CreateIndex(
                name: "IX_SubGenres_Id_Name",
                schema: "Parameters",
                table: "SubGenres",
                columns: new[] { "Id", "Name" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Vinyl_SubGenres_Id_SubGenre",
                schema: "Vinyl",
                table: "Vinyl",
                column: "Id_SubGenre",
                principalSchema: "Parameters",
                principalTable: "SubGenres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vinyl_SubGenres_Id_SubGenre",
                schema: "Vinyl",
                table: "Vinyl");

            migrationBuilder.DropTable(
                name: "SubGenres",
                schema: "Parameters");

            migrationBuilder.DropTable(
                name: "Genres",
                schema: "Parameters");

            migrationBuilder.DropIndex(
                name: "IX_Vinyl_Id_SubGenre",
                schema: "Vinyl",
                table: "Vinyl");

            migrationBuilder.DropColumn(
                name: "Id_SubGenre",
                schema: "Vinyl",
                table: "Vinyl");

            migrationBuilder.AlterColumn<decimal>(
                name: "Price",
                schema: "Vinyl",
                table: "Vinyl",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "Money");

            migrationBuilder.AddColumn<DateTime>(
                name: "DatePublished",
                schema: "Vinyl",
                table: "Vinyl",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Genre",
                schema: "Vinyl",
                table: "Vinyl",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
