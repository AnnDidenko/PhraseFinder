using Microsoft.EntityFrameworkCore.Migrations;

namespace Phrase_Finder.Domain.Migrations
{
    public partial class AddDictionaryIdField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DictionaryId",
                table: "TranslationalWords",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DictionaryId",
                table: "EnglishWords",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DictionaryId",
                table: "TranslationalWords");

            migrationBuilder.DropColumn(
                name: "DictionaryId",
                table: "EnglishWords");
        }
    }
}
