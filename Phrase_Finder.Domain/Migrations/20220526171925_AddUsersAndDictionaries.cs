using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Phrase_Finder.Domain.Migrations
{
    public partial class AddUsersAndDictionaries : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EnglishWords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Word = table.Column<string>(type: "text", nullable: false),
                    PartOfLanguage = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnglishWords", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Surname = table.Column<string>(type: "text", nullable: false),
                    Role = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    Login = table.Column<string>(type: "text", nullable: false),
                    Password = table.Column<string>(type: "text", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: false),
                    Age = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dictionaries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<int>(type: "integer", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Topic = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dictionaries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dictionaries_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Translations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EnglishWordId = table.Column<int>(type: "integer", nullable: true),
                    DictionaryId = table.Column<int>(type: "integer", nullable: true),
                    DateOfRecall = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Translations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Translations_Dictionaries_DictionaryId",
                        column: x => x.DictionaryId,
                        principalTable: "Dictionaries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Translations_EnglishWords_EnglishWordId",
                        column: x => x.EnglishWordId,
                        principalTable: "EnglishWords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TranslationalWords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Word = table.Column<string>(type: "text", nullable: false),
                    PartOfLanguage = table.Column<string>(type: "text", nullable: false),
                    TranslationId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TranslationalWords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TranslationalWords_Translations_TranslationId",
                        column: x => x.TranslationId,
                        principalTable: "Translations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dictionaries_UserId",
                table: "Dictionaries",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TranslationalWords_TranslationId",
                table: "TranslationalWords",
                column: "TranslationId");

            migrationBuilder.CreateIndex(
                name: "IX_Translations_DictionaryId",
                table: "Translations",
                column: "DictionaryId");

            migrationBuilder.CreateIndex(
                name: "IX_Translations_EnglishWordId",
                table: "Translations",
                column: "EnglishWordId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TranslationalWords");

            migrationBuilder.DropTable(
                name: "Translations");

            migrationBuilder.DropTable(
                name: "Dictionaries");

            migrationBuilder.DropTable(
                name: "EnglishWords");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
