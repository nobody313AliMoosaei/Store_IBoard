﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Store_IBoard.DL.Migrations
{
    /// <inheritdoc />
    public partial class initi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BasColor",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersianColorName = table.Column<string>(type: "nvarchar(220)", maxLength: 220, nullable: true),
                    EnglishColorName = table.Column<string>(type: "nvarchar(220)", maxLength: 220, nullable: true),
                    HexCode = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    ColorCode = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__BasColor__3214EC07A064CB55", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Category__3214EC07CAB36CD4", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<long>(type: "bigint", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersianName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roots",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProvinceName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProvinceID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roots", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SendEmailSMSModels",
                columns: table => new
                {
                    Id = table.Column<string>(type: "VARCHAR(40)", maxLength: 40, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: true),
                    Code = table.Column<int>(type: "int", nullable: false),
                    InsertDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SendEmailSMSModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogins", x => new { x.LoginProvider, x.ProviderKey });
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    RoleId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.RoleId, x.UserId });
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    NationalCode = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    UserStatus = table.Column<int>(type: "int", nullable: false),
                    NormalizePhoneNumber = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserTokens",
                columns: table => new
                {
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                });

            migrationBuilder.CreateTable(
                name: "GroupGoods",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupName = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    CategoryRef = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__GroupGoo__3214EC07D8E94B7D", x => x.Id);
                    table.ForeignKey(
                        name: "FK__GroupGood__Categ__38996AB5",
                        column: x => x.CategoryRef,
                        principalTable: "Category",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Key = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDomestic = table.Column<bool>(type: "bit", nullable: false),
                    IsForeign = table.Column<bool>(type: "bit", nullable: false),
                    Terminals = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersianTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnglishTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RootRef = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Key);
                    table.ForeignKey(
                        name: "FK__RootRef__City__38996AB6",
                        column: x => x.RootRef,
                        principalTable: "Roots",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Goods",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GoodName = table.Column<string>(type: "nvarchar(650)", maxLength: 650, nullable: true),
                    GoodDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GoodPrice = table.Column<long>(type: "bigint", nullable: true),
                    GroupGoodRef = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Goods__3214EC07B9ED6410", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Goods__GroupGood__3C69FB99",
                        column: x => x.GroupGoodRef,
                        principalTable: "GroupGoods",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GoodsColors",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ColorRef = table.Column<long>(type: "bigint", nullable: true),
                    GoodRef = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__GoodsCol__3214EC077CEA16CD", x => x.Id);
                    table.ForeignKey(
                        name: "FK__GoodsColo__Color__412EB0B6",
                        column: x => x.ColorRef,
                        principalTable: "BasColor",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__GoodsColo__GoodR__4222D4EF",
                        column: x => x.GoodRef,
                        principalTable: "Goods",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName", "PersianName" },
                values: new object[,]
                {
                    { 1L, null, "Administrator", "ADMINISTRATOR", "ادمین" },
                    { 2L, null, "DefulatUser", "DEFULATUSER", "کاربر عادی" },
                    { 3L, null, "MiddLevelUser", "MIDDLEVELUSER", "کاربر سطح دو" },
                    { 4L, null, "TopLevelUser", "TOPLEVELUSER", "کاربر سطح سه" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BasColor_PersianName",
                table: "BasColor",
                column: "PersianColorName");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_RootRef",
                table: "Cities",
                column: "RootRef");

            migrationBuilder.CreateIndex(
                name: "IX_Goods_GroupGoodRef",
                table: "Goods",
                column: "GroupGoodRef");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsColors_ColorRef",
                table: "GoodsColors",
                column: "ColorRef");

            migrationBuilder.CreateIndex(
                name: "IX_GoodsColors_GoodRef",
                table: "GoodsColors",
                column: "GoodRef");

            migrationBuilder.CreateIndex(
                name: "IX_GroupGoods_CategoryRef",
                table: "GroupGoods",
                column: "CategoryRef");

            migrationBuilder.CreateIndex(
                name: "IX_SendEmailSMSModel_Email",
                table: "SendEmailSMSModels",
                column: "Email");

            migrationBuilder.CreateIndex(
                name: "IX_SendEmailSMSModel_PhoneNumber",
                table: "SendEmailSMSModels",
                column: "PhoneNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Users_NationalCode",
                table: "Users",
                column: "NationalCode",
                unique: true,
                filter: "[NationalCode] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Users_PhoneNumber",
                table: "Users",
                column: "PhoneNumber",
                unique: true,
                filter: "[PhoneNumber] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserName",
                table: "Users",
                column: "UserName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "GoodsColors");

            migrationBuilder.DropTable(
                name: "RoleClaims");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "SendEmailSMSModels");

            migrationBuilder.DropTable(
                name: "UserClaims");

            migrationBuilder.DropTable(
                name: "UserLogins");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "UserTokens");

            migrationBuilder.DropTable(
                name: "Roots");

            migrationBuilder.DropTable(
                name: "BasColor");

            migrationBuilder.DropTable(
                name: "Goods");

            migrationBuilder.DropTable(
                name: "GroupGoods");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
