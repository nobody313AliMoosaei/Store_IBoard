using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store_IBoard.DL.Migrations
{
    /// <inheritdoc />
    public partial class InitOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RootRef",
                table: "Cities",
                newName: "ProvinceRef");

            migrationBuilder.RenameIndex(
                name: "IX_Cities_RootRef",
                table: "Cities",
                newName: "IX_Cities_ProvinceRef");

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostalAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    District = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Plaque = table.Column<short>(type: "smallint", nullable: true),
                    Unit = table.Column<byte>(type: "tinyint", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    FirstName_Receiver = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName_Receiver = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber_Receiver = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: true),
                    CityRef = table.Column<long>(type: "bigint", nullable: true),
                    UserRef = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Addresses__City__CityRef",
                        column: x => x.CityRef,
                        principalTable: "Cities",
                        principalColumn: "Key",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__Addresses__User__UserRef",
                        column: x => x.UserRef,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    UpdateDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    UserRef = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Orders__3214EC0794D2559C", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Orders__UserRef__02FC7413",
                        column: x => x.UserRef,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GoodOfOrder",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GoodCount = table.Column<int>(type: "int", nullable: true),
                    GoodPrice = table.Column<double>(type: "float", nullable: true),
                    CreateDateTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    GoodRef = table.Column<long>(type: "bigint", nullable: true),
                    OrderRef = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__GoodOfOr__3214EC07C7CB92A6", x => x.Id);
                    table.ForeignKey(
                        name: "FK__GoodOfOrd__GoodR__05D8E0BE",
                        column: x => x.GoodRef,
                        principalTable: "Goods",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__GoodOfOrd__Order__06CD04F7",
                        column: x => x.OrderRef,
                        principalTable: "Orders",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                column: "ConcurrencyStamp",
                value: "b47588f7-df55-4d15-b555-d29e7fece564");

            migrationBuilder.CreateIndex(
                name: "IX__Address__PhoneNumberReceiver",
                table: "Addresses",
                column: "PhoneNumber_Receiver");

            migrationBuilder.CreateIndex(
                name: "IX__Address__PostalCode",
                table: "Addresses",
                column: "PostalCode");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_CityRef",
                table: "Addresses",
                column: "CityRef");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_UserRef",
                table: "Addresses",
                column: "UserRef");

            migrationBuilder.CreateIndex(
                name: "IX_GoodOfOrder_GoodRef",
                table: "GoodOfOrder",
                column: "GoodRef");

            migrationBuilder.CreateIndex(
                name: "IX_GoodOfOrder_OrderRef",
                table: "GoodOfOrder",
                column: "OrderRef");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserRef",
                table: "Orders",
                column: "UserRef");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "GoodOfOrder");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.RenameColumn(
                name: "ProvinceRef",
                table: "Cities",
                newName: "RootRef");

            migrationBuilder.RenameIndex(
                name: "IX_Cities_ProvinceRef",
                table: "Cities",
                newName: "IX_Cities_RootRef");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                column: "ConcurrencyStamp",
                value: "bcfca4fa-b953-4173-979f-5f094751a3a1");
        }
    }
}
