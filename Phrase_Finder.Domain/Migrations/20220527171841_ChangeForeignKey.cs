using Microsoft.EntityFrameworkCore.Migrations;

namespace Phrase_Finder.Domain.Migrations
{
    public partial class ChangeForeignKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TranslationalWords_Translations_TranslationId",
                table: "TranslationalWords");

            migrationBuilder.DropForeignKey(
                name: "FK_Translations_Dictionaries_DictionaryId",
                table: "Translations");

            migrationBuilder.DropForeignKey(
                name: "FK_Translations_EnglishWords_EnglishWordId",
                table: "Translations");

            migrationBuilder.DropIndex(
                name: "IX_Translations_EnglishWordId",
                table: "Translations");

            migrationBuilder.DropColumn(
                name: "EnglishWordId",
                table: "Translations");

            migrationBuilder.DropColumn(
                name: "DictionaryId",
                table: "TranslationalWords");

            migrationBuilder.RenameColumn(
                name: "DictionaryId",
                table: "EnglishWords",
                newName: "TranslationId");

            migrationBuilder.AlterColumn<int>(
                name: "DictionaryId",
                table: "Translations",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TranslationId",
                table: "TranslationalWords",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EnglishWords_TranslationId",
                table: "EnglishWords",
                column: "TranslationId");

            migrationBuilder.AddForeignKey(
                name: "FK_EnglishWords_Translations_TranslationId",
                table: "EnglishWords",
                column: "TranslationId",
                principalTable: "Translations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TranslationalWords_Translations_TranslationId",
                table: "TranslationalWords",
                column: "TranslationId",
                principalTable: "Translations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Translations_Dictionaries_DictionaryId",
                table: "Translations",
                column: "DictionaryId",
                principalTable: "Dictionaries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EnglishWords_Translations_TranslationId",
                table: "EnglishWords");

            migrationBuilder.DropForeignKey(
                name: "FK_TranslationalWords_Translations_TranslationId",
                table: "TranslationalWords");

            migrationBuilder.DropForeignKey(
                name: "FK_Translations_Dictionaries_DictionaryId",
                table: "Translations");

            migrationBuilder.DropIndex(
                name: "IX_EnglishWords_TranslationId",
                table: "EnglishWords");

            migrationBuilder.RenameColumn(
                name: "TranslationId",
                table: "EnglishWords",
                newName: "DictionaryId");

            migrationBuilder.AlterColumn<int>(
                name: "DictionaryId",
                table: "Translations",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "EnglishWordId",
                table: "Translations",
                type: "integer",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TranslationId",
                table: "TranslationalWords",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "DictionaryId",
                table: "TranslationalWords",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Translations_EnglishWordId",
                table: "Translations",
                column: "EnglishWordId");

            migrationBuilder.AddForeignKey(
                name: "FK_TranslationalWords_Translations_TranslationId",
                table: "TranslationalWords",
                column: "TranslationId",
                principalTable: "Translations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Translations_Dictionaries_DictionaryId",
                table: "Translations",
                column: "DictionaryId",
                principalTable: "Dictionaries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Translations_EnglishWords_EnglishWordId",
                table: "Translations",
                column: "EnglishWordId",
                principalTable: "EnglishWords",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
