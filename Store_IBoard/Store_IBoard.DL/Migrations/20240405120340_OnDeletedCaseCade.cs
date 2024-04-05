using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Store_IBoard.DL.Migrations
{
    /// <inheritdoc />
    public partial class OnDeletedCaseCade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__Goods__GroupGood__3C69FB99",
                table: "Goods");

            migrationBuilder.DropForeignKey(
                name: "FK__GoodsColo__Color__412EB0B6",
                table: "GoodsColors");

            migrationBuilder.DropForeignKey(
                name: "FK__GoodsColo__GoodR__4222D4EF",
                table: "GoodsColors");

            migrationBuilder.DropForeignKey(
                name: "FK__GroupGood__Categ__38996AB5",
                table: "GroupGoods");

            migrationBuilder.DropForeignKey(
                name: "FK__HistorySms__Users__UserRef",
                table: "HistorySMS");

            migrationBuilder.AddColumn<string>(
                name: "GoodCode",
                table: "Goods",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                column: "ConcurrencyStamp",
                value: "bcfca4fa-b953-4173-979f-5f094751a3a1");

            migrationBuilder.CreateIndex(
                name: "IX__Goods__GoodCode",
                table: "Goods",
                column: "GoodCode",
                unique: true,
                filter: "[GoodCode] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK__Goods__GroupGood__3C69FB99",
                table: "Goods",
                column: "GroupGoodRef",
                principalTable: "GroupGoods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK__GoodsColo__Color__412EB0B6",
                table: "GoodsColors",
                column: "ColorRef",
                principalTable: "BasColor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK__GoodsColo__GoodR__4222D4EF",
                table: "GoodsColors",
                column: "GoodRef",
                principalTable: "Goods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK__GroupGood__Categ__38996AB5",
                table: "GroupGoods",
                column: "CategoryRef",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK__HistorySms__Users__UserRef",
                table: "HistorySMS",
                column: "UserRef",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__Goods__GroupGood__3C69FB99",
                table: "Goods");

            migrationBuilder.DropForeignKey(
                name: "FK__GoodsColo__Color__412EB0B6",
                table: "GoodsColors");

            migrationBuilder.DropForeignKey(
                name: "FK__GoodsColo__GoodR__4222D4EF",
                table: "GoodsColors");

            migrationBuilder.DropForeignKey(
                name: "FK__GroupGood__Categ__38996AB5",
                table: "GroupGoods");

            migrationBuilder.DropForeignKey(
                name: "FK__HistorySms__Users__UserRef",
                table: "HistorySMS");

            migrationBuilder.DropIndex(
                name: "IX__Goods__GoodCode",
                table: "Goods");

            migrationBuilder.DropColumn(
                name: "GoodCode",
                table: "Goods");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1L,
                column: "ConcurrencyStamp",
                value: "1f0df6e0-0cae-4c90-a1b3-3adf9431a795");

            migrationBuilder.AddForeignKey(
                name: "FK__Goods__GroupGood__3C69FB99",
                table: "Goods",
                column: "GroupGoodRef",
                principalTable: "GroupGoods",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__GoodsColo__Color__412EB0B6",
                table: "GoodsColors",
                column: "ColorRef",
                principalTable: "BasColor",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__GoodsColo__GoodR__4222D4EF",
                table: "GoodsColors",
                column: "GoodRef",
                principalTable: "Goods",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__GroupGood__Categ__38996AB5",
                table: "GroupGoods",
                column: "CategoryRef",
                principalTable: "Category",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK__HistorySms__Users__UserRef",
                table: "HistorySMS",
                column: "UserRef",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
