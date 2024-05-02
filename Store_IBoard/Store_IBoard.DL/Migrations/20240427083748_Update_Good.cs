using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store_IBoard.DL.Migrations
{
    /// <inheritdoc />
    public partial class Update_Good : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CountUpdate",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "StatusOrderRef",
                table: "Orders",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<int>(
                name: "Capacity",
                table: "Goods",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BasLookup",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Key = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    Type = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Aux = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasLookup", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                column: "ConcurrencyStamp",
                value: "3fc94b05-f532-431e-9b87-d07ec5c991cc");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_StatusOrderRef",
                table: "Orders",
                column: "StatusOrderRef");

            migrationBuilder.CreateIndex(
                name: "IX__BasLookup__Type",
                table: "BasLookup",
                column: "Type");

            migrationBuilder.AddForeignKey(
                name: "FK__Orders__basLookup__StatusOrderRef",
                table: "Orders",
                column: "StatusOrderRef",
                principalTable: "BasLookup",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__Orders__basLookup__StatusOrderRef",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "BasLookup");

            migrationBuilder.DropIndex(
                name: "IX_Orders_StatusOrderRef",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CountUpdate",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "StatusOrderRef",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Capacity",
                table: "Goods");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                column: "ConcurrencyStamp",
                value: "b47588f7-df55-4d15-b555-d29e7fece564");
        }
    }
}
