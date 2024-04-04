using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store_IBoard.DL.Migrations
{
    /// <inheritdoc />
    public partial class AddNavigationToHistorySMS : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "HistorySMS",
                newName: "UserRef");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                column: "ConcurrencyStamp",
                value: "73295fe7-794c-4e59-999f-2a9622d447ae");

            migrationBuilder.CreateIndex(
                name: "IX_HistorySMS_UserRef",
                table: "HistorySMS",
                column: "UserRef");

            migrationBuilder.AddForeignKey(
                name: "FK__HistorySms__Users__UserRef",
                table: "HistorySMS",
                column: "UserRef",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__HistorySms__Users__UserRef",
                table: "HistorySMS");

            migrationBuilder.DropIndex(
                name: "IX_HistorySMS_UserRef",
                table: "HistorySMS");

            migrationBuilder.RenameColumn(
                name: "UserRef",
                table: "HistorySMS",
                newName: "UserId");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                column: "ConcurrencyStamp",
                value: "9a3abeba-83f5-44b1-9e51-f4edf7a991e2");
        }
    }
}
