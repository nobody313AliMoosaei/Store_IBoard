using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store_IBoard.DL.Migrations
{
    /// <inheritdoc />
    public partial class AddAccessLevelToUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AccessLevel",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "AccessLevel", "ConcurrencyStamp" },
                values: new object[] { 0, "1f0df6e0-0cae-4c90-a1b3-3adf9431a795" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccessLevel",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                column: "ConcurrencyStamp",
                value: "73295fe7-794c-4e59-999f-2a9622d447ae");
        }
    }
}
