using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VinylCollection.Data.Migrations
{
    public partial class add_tablecommunity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Community");

            migrationBuilder.CreateTable(
                name: "Communities",
                schema: "Community",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Deleted = table.Column<bool>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    Id_User = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(maxLength: 2000, nullable: true),
                    Image = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Communities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Communities_Users_Id_User",
                        column: x => x.Id_User,
                        principalSchema: "Security",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Communities_Id",
                schema: "Community",
                table: "Communities",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Communities_Id_User",
                schema: "Community",
                table: "Communities",
                column: "Id_User");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Communities",
                schema: "Community");
        }
    }
}
