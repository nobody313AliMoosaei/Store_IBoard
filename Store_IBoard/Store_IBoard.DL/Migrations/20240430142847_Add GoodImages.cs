using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store_IBoard.DL.Migrations
{
    /// <inheritdoc />
    public partial class AddGoodImages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OrderKey",
                table: "Orders",
                type: "nvarchar(450)",
                nullable: true,
                defaultValue: "5abd538d-c822-4626-90c8-5c76244d8b02");

            migrationBuilder.AddColumn<long>(
                name: "OrderSerial",
                table: "Orders",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "GoodImage",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    GoodRef = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoodImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK__GoodImag__Good__GoodRef",
                        column: x => x.GoodRef,
                        principalTable: "Goods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderHistories",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StatusOrderRef = table.Column<long>(type: "bigint", nullable: true),
                    OrderRef = table.Column<long>(type: "bigint", nullable: true),
                    UserRef = table.Column<long>(type: "bigint", nullable: true),
                    Ip = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Baslookup__OrderHistory__StatusOrderRef",
                        column: x => x.StatusOrderRef,
                        principalTable: "BasLookup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__Orders__OrderHistory__OrderRef",
                        column: x => x.OrderRef,
                        principalTable: "Orders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__Users__OrderHistory__UserRef",
                        column: x => x.UserRef,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                column: "ConcurrencyStamp",
                value: "33d67cc6-0fd8-4718-811f-b545b0630da6");

            migrationBuilder.CreateIndex(
                name: "IX__Orders__OrderKey",
                table: "Orders",
                column: "OrderKey",
                unique: true,
                filter: "[OrderKey] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX__Orders__OrderSerial",
                table: "Orders",
                column: "OrderSerial",
                unique: true,
                filter: "[OrderSerial] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_GoodImage_GoodRef",
                table: "GoodImage",
                column: "GoodRef");

            migrationBuilder.CreateIndex(
                name: "IX_OrderHistories_OrderRef",
                table: "OrderHistories",
                column: "OrderRef");

            migrationBuilder.CreateIndex(
                name: "IX_OrderHistories_StatusOrderRef",
                table: "OrderHistories",
                column: "StatusOrderRef");

            migrationBuilder.CreateIndex(
                name: "IX_OrderHistories_UserRef",
                table: "OrderHistories",
                column: "UserRef");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GoodImage");

            migrationBuilder.DropTable(
                name: "OrderHistories");

            migrationBuilder.DropIndex(
                name: "IX__Orders__OrderKey",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX__Orders__OrderSerial",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderKey",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderSerial",
                table: "Orders");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                column: "ConcurrencyStamp",
                value: "3fc94b05-f532-431e-9b87-d07ec5c991cc");
        }
    }
}
