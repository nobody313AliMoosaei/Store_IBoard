using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store_IBoard.DL.Migrations
{
    /// <inheritdoc />
    public partial class AddNewTableHistorSMS : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HistorySMS",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: true),
                    Mobile = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: true),
                    Message = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    InsertDateTime = table.Column<DateTime>(type: "datetime2(7)", nullable: true),
                    Ip = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: true),
                    Client = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistorySMS", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                column: "ConcurrencyStamp",
                value: "9a3abeba-83f5-44b1-9e51-f4edf7a991e2");

            migrationBuilder.CreateIndex(
                name: "IX_HistorySendSMS_Mobile",
                table: "HistorySMS",
                column: "Mobile");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HistorySMS");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                column: "ConcurrencyStamp",
                value: "33b871af-aa3b-4bbc-b385-bad05a8b906c");
        }
    }
}
