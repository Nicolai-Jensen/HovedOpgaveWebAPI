using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace HovedOpgaveWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddCompositeKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_GameData",
                table: "GameData");

            migrationBuilder.Sql("ALTER TABLE \"GameData\" ALTER COLUMN \"UserId\" DROP IDENTITY IF EXISTS;");

            migrationBuilder.AlterColumn<string>(
                name: "GameId",
                table: "GameData",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "GameData",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");


            migrationBuilder.AddPrimaryKey(
                name: "PK_GameData",
                table: "GameData",
                columns: new[] { "UserId", "GameId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_GameData",
                table: "GameData");

            migrationBuilder.AlterColumn<int>(
                name: "GameId",
                table: "GameData",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "GameData",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_GameData",
                table: "GameData",
                column: "UserId");
        }
    }
}
