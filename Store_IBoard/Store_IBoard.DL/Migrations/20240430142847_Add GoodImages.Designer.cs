﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Store_IBoard.DL.ApplicationDbContext;

#nullable disable

namespace Store_IBoard.DL.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    [Migration("20240430142847_Add GoodImages")]
    partial class AddGoodImages
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<long>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("RoleId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("RoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<long>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("UserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<long>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.ToTable("UserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<long>", b =>
                {
                    b.Property<long>("RoleId")
                        .HasColumnType("bigint");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("RoleId", "UserId");

                    b.ToTable("UserRoles");

                    b.HasData(
                        new
                        {
                            RoleId = 1L,
                            UserId = 1L
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<long>", b =>
                {
                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("UserTokens");
                });

            modelBuilder.Entity("Store_IBoard.DL.Entities.Address", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long?>("CityRef")
                        .HasColumnType("bigint");

                    b.Property<string>("District")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName_Receiver")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName_Receiver")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber_Receiver")
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<short?>("Plaque")
                        .HasColumnType("smallint");

                    b.Property<string>("PostalAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<byte?>("Unit")
                        .HasColumnType("tinyint");

                    b.Property<long?>("UserRef")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("CityRef");

                    b.HasIndex("UserRef");

                    b.HasIndex(new[] { "PhoneNumber_Receiver" }, "IX__Address__PhoneNumberReceiver");

                    b.HasIndex(new[] { "PostalCode" }, "IX__Address__PostalCode");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("Store_IBoard.DL.Entities.BasColor", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<int?>("ColorCode")
                        .HasColumnType("int");

                    b.Property<string>("EnglishColorName")
                        .HasMaxLength(220)
                        .HasColumnType("nvarchar(220)");

                    b.Property<string>("HexCode")
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<string>("PersianColorName")
                        .HasMaxLength(220)
                        .HasColumnType("nvarchar(220)");

                    b.HasKey("Id")
                        .HasName("PK__BasColor__3214EC07A064CB55");

                    b.HasIndex(new[] { "PersianColorName" }, "IX_BasColor_PersianName");

                    b.ToTable("BasColor", (string)null);
                });

            modelBuilder.Entity("Store_IBoard.DL.Entities.BasLookup", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Aux")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Key")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Type" }, "IX__BasLookup__Type");

                    b.ToTable("BasLookup");
                });

            modelBuilder.Entity("Store_IBoard.DL.Entities.Category", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("CategoryName")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("Id")
                        .HasName("PK__Category__3214EC07CAB36CD4");

                    b.ToTable("Category", (string)null);
                });

            modelBuilder.Entity("Store_IBoard.DL.Entities.City", b =>
                {
                    b.Property<long>("Key")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Key"));

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EnglishTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Id")
                        .HasColumnType("bigint");

                    b.Property<bool>("IsDomestic")
                        .HasColumnType("bit");

                    b.Property<bool>("IsForeign")
                        .HasColumnType("bit");

                    b.Property<string>("PersianTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("ProvinceRef")
                        .HasColumnType("bigint");

                    b.Property<string>("Terminals")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Key");

                    b.HasIndex("ProvinceRef");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("Store_IBoard.DL.Entities.Good", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<int?>("Capacity")
                        .HasColumnType("int");

                    b.Property<string>("GoodCode")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("GoodDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GoodName")
                        .HasMaxLength(650)
                        .HasColumnType("nvarchar(650)");

                    b.Property<long?>("GoodPrice")
                        .HasColumnType("bigint");

                    b.Property<long?>("GroupGoodRef")
                        .HasColumnType("bigint");

                    b.HasKey("Id")
                        .HasName("PK__Goods__3214EC07B9ED6410");

                    b.HasIndex("GroupGoodRef");

                    b.HasIndex(new[] { "GoodCode" }, "IX__Goods__GoodCode")
                        .IsUnique()
                        .HasFilter("[GoodCode] IS NOT NULL");

                    b.ToTable("Goods");
                });

            modelBuilder.Entity("Store_IBoard.DL.Entities.GoodImage", b =>
                {
                    b.Property<long?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long?>("Id"));

                    b.Property<DateTime?>("CreateDateTime")
                        .HasColumnType("datetime2");

                    b.Property<long?>("GoodRef")
                        .HasColumnType("bigint");

                    b.Property<string>("ImageAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GoodRef");

                    b.ToTable("GoodImage");
                });

            modelBuilder.Entity("Store_IBoard.DL.Entities.GoodOfOrder", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime?>("CreateDateTime")
                        .HasColumnType("datetime");

                    b.Property<int?>("GoodCount")
                        .HasColumnType("int");

                    b.Property<double?>("GoodPrice")
                        .HasColumnType("float");

                    b.Property<long?>("GoodRef")
                        .HasColumnType("bigint");

                    b.Property<long?>("OrderRef")
                        .HasColumnType("bigint");

                    b.HasKey("Id")
                        .HasName("PK__GoodOfOr__3214EC07C7CB92A6");

                    b.HasIndex("GoodRef");

                    b.HasIndex("OrderRef");

                    b.ToTable("GoodOfOrder", (string)null);
                });

            modelBuilder.Entity("Store_IBoard.DL.Entities.GoodsColor", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long?>("ColorRef")
                        .HasColumnType("bigint");

                    b.Property<long?>("GoodRef")
                        .HasColumnType("bigint");

                    b.HasKey("Id")
                        .HasName("PK__GoodsCol__3214EC077CEA16CD");

                    b.HasIndex("ColorRef");

                    b.HasIndex("GoodRef");

                    b.ToTable("GoodsColors");
                });

            modelBuilder.Entity("Store_IBoard.DL.Entities.GroupGood", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long?>("CategoryRef")
                        .HasColumnType("bigint");

                    b.Property<string>("GroupName")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("Id")
                        .HasName("PK__GroupGoo__3214EC07D8E94B7D");

                    b.HasIndex("CategoryRef");

                    b.ToTable("GroupGoods");
                });

            modelBuilder.Entity("Store_IBoard.DL.Entities.HistorySendSMS", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Client")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime?>("InsertDateTime")
                        .HasColumnType("datetime2(7)");

                    b.Property<string>("Ip")
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.Property<string>("Message")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Mobile")
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<long?>("UserRef")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UserRef");

                    b.HasIndex(new[] { "Mobile" }, "IX_HistorySendSMS_Mobile");

                    b.ToTable("HistorySMS");
                });

            modelBuilder.Entity("Store_IBoard.DL.Entities.Order", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<int>("CountUpdate")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreateDateTime")
                        .HasColumnType("datetime");

                    b.Property<string>("OrderKey")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)")
                        .HasDefaultValue("5abd538d-c822-4626-90c8-5c76244d8b02");

                    b.Property<long?>("OrderSerial")
                        .HasColumnType("bigint");

                    b.Property<long>("StatusOrderRef")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("UpdateDateTime")
                        .HasColumnType("datetime");

                    b.Property<long?>("UserRef")
                        .HasColumnType("bigint");

                    b.HasKey("Id")
                        .HasName("PK__Orders__3214EC0794D2559C");

                    b.HasIndex("StatusOrderRef");

                    b.HasIndex("UserRef");

                    b.HasIndex(new[] { "OrderKey" }, "IX__Orders__OrderKey")
                        .IsUnique()
                        .HasFilter("[OrderKey] IS NOT NULL");

                    b.HasIndex(new[] { "OrderSerial" }, "IX__Orders__OrderSerial")
                        .IsUnique()
                        .HasFilter("[OrderSerial] IS NOT NULL");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Store_IBoard.DL.Entities.OrderHistory", b =>
                {
                    b.Property<long?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long?>("Id"));

                    b.Property<DateTime?>("CreateDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Ip")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("OrderRef")
                        .HasColumnType("bigint");

                    b.Property<long?>("StatusOrderRef")
                        .HasColumnType("bigint");

                    b.Property<long?>("UserRef")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("OrderRef");

                    b.HasIndex("StatusOrderRef");

                    b.HasIndex("UserRef");

                    b.ToTable("OrderHistories");
                });

            modelBuilder.Entity("Store_IBoard.DL.Entities.Province", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<int>("ProvinceID")
                        .HasColumnType("int");

                    b.Property<string>("ProvinceName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roots");
                });

            modelBuilder.Entity("Store_IBoard.DL.Entities.Roles", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PersianName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Name = "Administrator",
                            NormalizedName = "ADMINISTRATOR",
                            PersianName = "ادمین"
                        },
                        new
                        {
                            Id = 2L,
                            Name = "DefulatUser",
                            NormalizedName = "DEFULATUSER",
                            PersianName = "کاربر عادی"
                        },
                        new
                        {
                            Id = 3L,
                            Name = "MiddLevelUser",
                            NormalizedName = "MIDDLEVELUSER",
                            PersianName = "کاربر سطح دو"
                        },
                        new
                        {
                            Id = 4L,
                            Name = "TopLevelUser",
                            NormalizedName = "TOPLEVELUSER",
                            PersianName = "کاربر سطح سه"
                        });
                });

            modelBuilder.Entity("Store_IBoard.DL.Entities.SendEmailSMSModel", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(40)
                        .HasColumnType("VARCHAR");

                    b.Property<int>("Code")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasMaxLength(450)
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("InsertDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Email" }, "IX_SendEmailSMSModel_Email");

                    b.HasIndex(new[] { "PhoneNumber" }, "IX_SendEmailSMSModel_PhoneNumber");

                    b.ToTable("SendEmailSMSModels");
                });

            modelBuilder.Entity("Store_IBoard.DL.Entities.Users", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<int>("AccessLevel")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NationalCode")
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<string>("NormalizePhoneNumber")
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<int>("UserStatus")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "NationalCode" }, "IX_Users_NationalCode")
                        .IsUnique()
                        .HasFilter("[NationalCode] IS NOT NULL");

                    b.HasIndex(new[] { "PhoneNumber" }, "IX_Users_PhoneNumber")
                        .IsUnique()
                        .HasFilter("[PhoneNumber] IS NOT NULL");

                    b.HasIndex(new[] { "UserName" }, "IX_Users_UserName");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            AccessFailedCount = 0,
                            AccessLevel = 0,
                            ConcurrencyStamp = "33d67cc6-0fd8-4718-811f-b545b0630da6",
                            Email = "ali.moosaei.big@gmail.com",
                            EmailConfirmed = false,
                            FirstName = "Ali",
                            IsActive = true,
                            LastName = "Moosaei",
                            LockoutEnabled = false,
                            PasswordHash = "AQAAAAIAAYagAAAAECj4NT8lrikZFClrFPC8twPx+S1/oWchdVTHyKWMeCWBxYBGM6RQguQbnafnYrn+Lg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "K7JCQNNN4ULGGODXGAHOHXHF2MHWMYZU",
                            TwoFactorEnabled = false,
                            UserName = "Admin",
                            UserStatus = 1
                        });
                });

            modelBuilder.Entity("Store_IBoard.DL.Entities.Address", b =>
                {
                    b.HasOne("Store_IBoard.DL.Entities.City", "CityRefNavigation")
                        .WithMany("Addresses")
                        .HasForeignKey("CityRef")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK__Addresses__City__CityRef");

                    b.HasOne("Store_IBoard.DL.Entities.Users", "UserRefNavigation")
                        .WithMany("Addresses")
                        .HasForeignKey("UserRef")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK__Addresses__User__UserRef");

                    b.Navigation("CityRefNavigation");

                    b.Navigation("UserRefNavigation");
                });

            modelBuilder.Entity("Store_IBoard.DL.Entities.City", b =>
                {
                    b.HasOne("Store_IBoard.DL.Entities.Province", "ProvinceRefNavigation")
                        .WithMany("Cities")
                        .HasForeignKey("ProvinceRef")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK__RootRef__City__38996AB6");

                    b.Navigation("ProvinceRefNavigation");
                });

            modelBuilder.Entity("Store_IBoard.DL.Entities.Good", b =>
                {
                    b.HasOne("Store_IBoard.DL.Entities.GroupGood", "GroupGoodRefNavigation")
                        .WithMany("Goods")
                        .HasForeignKey("GroupGoodRef")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK__Goods__GroupGood__3C69FB99");

                    b.Navigation("GroupGoodRefNavigation");
                });

            modelBuilder.Entity("Store_IBoard.DL.Entities.GoodImage", b =>
                {
                    b.HasOne("Store_IBoard.DL.Entities.Good", "GoodRefNavigation")
                        .WithMany("GoodImages")
                        .HasForeignKey("GoodRef")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK__GoodImag__Good__GoodRef");

                    b.Navigation("GoodRefNavigation");
                });

            modelBuilder.Entity("Store_IBoard.DL.Entities.GoodOfOrder", b =>
                {
                    b.HasOne("Store_IBoard.DL.Entities.Good", "GoodRefNavigation")
                        .WithMany("GoodOfOrders")
                        .HasForeignKey("GoodRef")
                        .HasConstraintName("FK__GoodOfOrd__GoodR__05D8E0BE");

                    b.HasOne("Store_IBoard.DL.Entities.Order", "OrderRefNavigation")
                        .WithMany("GoodOfOrders")
                        .HasForeignKey("OrderRef")
                        .HasConstraintName("FK__GoodOfOrd__Order__06CD04F7");

                    b.Navigation("GoodRefNavigation");

                    b.Navigation("OrderRefNavigation");
                });

            modelBuilder.Entity("Store_IBoard.DL.Entities.GoodsColor", b =>
                {
                    b.HasOne("Store_IBoard.DL.Entities.BasColor", "ColorRefNavigation")
                        .WithMany("GoodsColors")
                        .HasForeignKey("ColorRef")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK__GoodsColo__Color__412EB0B6");

                    b.HasOne("Store_IBoard.DL.Entities.Good", "GoodRefNavigation")
                        .WithMany("GoodsColors")
                        .HasForeignKey("GoodRef")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK__GoodsColo__GoodR__4222D4EF");

                    b.Navigation("ColorRefNavigation");

                    b.Navigation("GoodRefNavigation");
                });

            modelBuilder.Entity("Store_IBoard.DL.Entities.GroupGood", b =>
                {
                    b.HasOne("Store_IBoard.DL.Entities.Category", "CategoryRefNavigation")
                        .WithMany("GroupGoods")
                        .HasForeignKey("CategoryRef")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK__GroupGood__Categ__38996AB5");

                    b.Navigation("CategoryRefNavigation");
                });

            modelBuilder.Entity("Store_IBoard.DL.Entities.HistorySendSMS", b =>
                {
                    b.HasOne("Store_IBoard.DL.Entities.Users", "UserRefNavigation")
                        .WithMany("HistorySms")
                        .HasForeignKey("UserRef")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK__HistorySms__Users__UserRef");

                    b.Navigation("UserRefNavigation");
                });

            modelBuilder.Entity("Store_IBoard.DL.Entities.Order", b =>
                {
                    b.HasOne("Store_IBoard.DL.Entities.BasLookup", "StatusOrderRefNavigation")
                        .WithMany("Orders")
                        .HasForeignKey("StatusOrderRef")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK__Orders__basLookup__StatusOrderRef");

                    b.HasOne("Store_IBoard.DL.Entities.Users", "UserRefNavigation")
                        .WithMany("Orders")
                        .HasForeignKey("UserRef")
                        .HasConstraintName("FK__Orders__UserRef__02FC7413");

                    b.Navigation("StatusOrderRefNavigation");

                    b.Navigation("UserRefNavigation");
                });

            modelBuilder.Entity("Store_IBoard.DL.Entities.OrderHistory", b =>
                {
                    b.HasOne("Store_IBoard.DL.Entities.Order", "OrderRefNavigation")
                        .WithMany("OrderHistories")
                        .HasForeignKey("OrderRef")
                        .OnDelete(DeleteBehavior.NoAction)
                        .HasConstraintName("FK__Orders__OrderHistory__OrderRef");

                    b.HasOne("Store_IBoard.DL.Entities.BasLookup", "StatusOrderRefNavigation")
                        .WithMany("OrderHistories")
                        .HasForeignKey("StatusOrderRef")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK__Baslookup__OrderHistory__StatusOrderRef");

                    b.HasOne("Store_IBoard.DL.Entities.Users", "UserRefNavigation")
                        .WithMany("OrderHistories")
                        .HasForeignKey("UserRef")
                        .OnDelete(DeleteBehavior.Cascade)
                        .HasConstraintName("FK__Users__OrderHistory__UserRef");

                    b.Navigation("OrderRefNavigation");

                    b.Navigation("StatusOrderRefNavigation");

                    b.Navigation("UserRefNavigation");
                });

            modelBuilder.Entity("Store_IBoard.DL.Entities.BasColor", b =>
                {
                    b.Navigation("GoodsColors");
                });

            modelBuilder.Entity("Store_IBoard.DL.Entities.BasLookup", b =>
                {
                    b.Navigation("OrderHistories");

                    b.Navigation("Orders");
                });

            modelBuilder.Entity("Store_IBoard.DL.Entities.Category", b =>
                {
                    b.Navigation("GroupGoods");
                });

            modelBuilder.Entity("Store_IBoard.DL.Entities.City", b =>
                {
                    b.Navigation("Addresses");
                });

            modelBuilder.Entity("Store_IBoard.DL.Entities.Good", b =>
                {
                    b.Navigation("GoodImages");

                    b.Navigation("GoodOfOrders");

                    b.Navigation("GoodsColors");
                });

            modelBuilder.Entity("Store_IBoard.DL.Entities.GroupGood", b =>
                {
                    b.Navigation("Goods");
                });

            modelBuilder.Entity("Store_IBoard.DL.Entities.Order", b =>
                {
                    b.Navigation("GoodOfOrders");

                    b.Navigation("OrderHistories");
                });

            modelBuilder.Entity("Store_IBoard.DL.Entities.Province", b =>
                {
                    b.Navigation("Cities");
                });

            modelBuilder.Entity("Store_IBoard.DL.Entities.Users", b =>
                {
                    b.Navigation("Addresses");

                    b.Navigation("HistorySms");

                    b.Navigation("OrderHistories");

                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}