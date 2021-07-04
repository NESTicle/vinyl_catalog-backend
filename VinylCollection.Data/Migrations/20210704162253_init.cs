using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace VinylCollection.Data.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Community");

            migrationBuilder.EnsureSchema(
                name: "Parameters");

            migrationBuilder.EnsureSchema(
                name: "Security");

            migrationBuilder.EnsureSchema(
                name: "Vinyl");

            migrationBuilder.CreateTable(
                name: "Countries",
                schema: "Parameters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                schema: "Parameters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "Security",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    UserName = table.Column<string>(type: "text", nullable: true),
                    Password = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true),
                    IsEmailValid = table.Column<bool>(type: "boolean", nullable: false),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VinylFormats",
                schema: "Vinyl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(80)", maxLength: 80, nullable: false),
                    Description = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: false),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VinylFormats", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SubGenres",
                schema: "Parameters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Id_Genre = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "Communities",
                schema: "Community",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Id_User = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    URL = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: true),
                    Image = table.Column<string>(type: "text", nullable: true),
                    Background = table.Column<string>(type: "text", nullable: true),
                    PublishRule = table.Column<int>(type: "integer", nullable: false),
                    CommentRule = table.Column<int>(type: "integer", nullable: false),
                    NSFW = table.Column<bool>(type: "boolean", nullable: false),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "Vinyl",
                schema: "Vinyl",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Id_User = table.Column<int>(type: "integer", nullable: false),
                    Id_Country = table.Column<int>(type: "integer", nullable: false),
                    Id_SubGenre = table.Column<int>(type: "integer", nullable: false),
                    Id_VinylFormat = table.Column<int>(type: "integer", nullable: false),
                    Band = table.Column<string>(type: "text", nullable: true),
                    Album = table.Column<string>(type: "text", nullable: true),
                    CoverURL = table.Column<string>(type: "text", nullable: true),
                    DateReleased = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Info = table.Column<string>(type: "text", nullable: true),
                    Color = table.Column<string>(type: "text", nullable: true),
                    Disc = table.Column<int>(type: "integer", nullable: false),
                    Price = table.Column<decimal>(type: "Money", nullable: false),
                    Link = table.Column<string>(type: "text", nullable: true),
                    Type = table.Column<string>(type: "text", nullable: true),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    Currency = table.Column<string>(type: "text", nullable: true),
                    Deleted = table.Column<bool>(type: "boolean", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vinyl", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vinyl_Countries_Id_Country",
                        column: x => x.Id_Country,
                        principalSchema: "Parameters",
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vinyl_SubGenres_Id_SubGenre",
                        column: x => x.Id_SubGenre,
                        principalSchema: "Parameters",
                        principalTable: "SubGenres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vinyl_Users_Id_User",
                        column: x => x.Id_User,
                        principalSchema: "Security",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Vinyl_VinylFormats_Id_VinylFormat",
                        column: x => x.Id_VinylFormat,
                        principalSchema: "Vinyl",
                        principalTable: "VinylFormats",
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

            migrationBuilder.CreateIndex(
                name: "IX_Countries_Id_Name",
                schema: "Parameters",
                table: "Countries",
                columns: new[] { "Id", "Name" },
                unique: true);

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
                name: "IX_Vinyl_Id_Country",
                schema: "Vinyl",
                table: "Vinyl",
                column: "Id_Country");

            migrationBuilder.CreateIndex(
                name: "IX_Vinyl_Id_SubGenre",
                schema: "Vinyl",
                table: "Vinyl",
                column: "Id_SubGenre");

            migrationBuilder.CreateIndex(
                name: "IX_Vinyl_Id_User",
                schema: "Vinyl",
                table: "Vinyl",
                column: "Id_User");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Communities",
                schema: "Community");

            migrationBuilder.DropTable(
                name: "Vinyl",
                schema: "Vinyl");

            migrationBuilder.DropTable(
                name: "Countries",
                schema: "Parameters");

            migrationBuilder.DropTable(
                name: "SubGenres",
                schema: "Parameters");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "Security");

            migrationBuilder.DropTable(
                name: "VinylFormats",
                schema: "Vinyl");

            migrationBuilder.DropTable(
                name: "Genres",
                schema: "Parameters");
        }
    }
}
