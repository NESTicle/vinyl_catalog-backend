using Microsoft.EntityFrameworkCore.Migrations;

namespace VinylCollection.Data.Migrations
{
    public partial class add_tablecountry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Parameters");

            migrationBuilder.CreateTable(
                name: "Countries",
                schema: "Parameters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Countries_Id_Name",
                schema: "Parameters",
                table: "Countries",
                columns: new[] { "Id", "Name" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Countries",
                schema: "Parameters");
        }
    }
}
