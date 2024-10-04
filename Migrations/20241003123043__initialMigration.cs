using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyDictionary.Migrations
{
    /// <inheritdoc />
    public partial class _initialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sentences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RusValue = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    EngValue = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Tense = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sentences", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Words",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RusValue = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    EngValue = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Transcription = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    PartOfSpeech = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Words", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sentences");

            migrationBuilder.DropTable(
                name: "Words");
        }
    }
}
