using Microsoft.EntityFrameworkCore.Migrations;

namespace VinylCollection.Data.Migrations
{
    public partial class update_tablerelationshipVinylCountry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Country",
                schema: "Vinyl",
                table: "Vinyl");

            migrationBuilder.AddColumn<int>(
                name: "Id_Country",
                schema: "Vinyl",
                table: "Vinyl",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Vinyl_Id_Country",
                schema: "Vinyl",
                table: "Vinyl",
                column: "Id_Country");

            migrationBuilder.AddForeignKey(
                name: "FK_Vinyl_Countries_Id_Country",
                schema: "Vinyl",
                table: "Vinyl",
                column: "Id_Country",
                principalSchema: "Parameters",
                principalTable: "Countries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vinyl_Countries_Id_Country",
                schema: "Vinyl",
                table: "Vinyl");

            migrationBuilder.DropIndex(
                name: "IX_Vinyl_Id_Country",
                schema: "Vinyl",
                table: "Vinyl");

            migrationBuilder.DropColumn(
                name: "Id_Country",
                schema: "Vinyl",
                table: "Vinyl");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                schema: "Vinyl",
                table: "Vinyl",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
