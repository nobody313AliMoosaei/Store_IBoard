using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Store_IBoard.DL.Entities;
using Store_IBoard.DL.ToolsBLU;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Store_IBoard.DL.ApplicationDbContext
{
    public class ApplicationDBContext : IdentityDbContext<Users, Roles, long>
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> option)
            : base(option)
        { }

        public virtual DbSet<BasColor> BasColors { get; set; }

        public virtual DbSet<Category> Categories { get; set; }

        public virtual DbSet<Good> Goods { get; set; }

        public virtual DbSet<GoodsColor> GoodsColors { get; set; }

        public virtual DbSet<GroupGood> GroupGoods { get; set; }

        public virtual DbSet<SendEmailSMSModel> SendEmailSMSModels { get; set; }

        public virtual DbSet<City> Cities { get; set; }

        public virtual DbSet<Province> Roots { set; get; }

        public virtual DbSet<HistorySendSMS> HistorySMS { set; get; }

        public virtual DbSet<Address> Addresses { set; get; }

        public virtual DbSet<Order> Orders { set; get; }

        public virtual DbSet<GoodOfOrder> GoodOfOrders { set; get; }

        public virtual DbSet<BasLookup> BasLookup { set; get; }

        public virtual DbSet<OrderHistory> OrderHistories { set; get; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<IdentityUserLogin<long>>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });
            });

            builder.Entity<IdentityUserRole<long>>(entity =>
            {
                entity.HasKey(e => new { e.RoleId, e.UserId });
                #region Set Role Admin
                entity.HasData(new IdentityUserRole<long>
                {
                    RoleId = 1,
                    UserId = 1
                });
                #endregion
            });

            builder.Entity<IdentityUserToken<long>>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });
            });

            builder.Entity<Users>(entity =>
            {
                entity.HasIndex(e => e.PhoneNumber, "IX_Users_PhoneNumber").IsUnique(true);
                entity.HasIndex(e => e.UserName, "IX_Users_UserName");
                entity.HasIndex(e => e.NationalCode, "IX_Users_NationalCode").IsUnique(true);

                entity.Property(e => e.PhoneNumber).HasMaxLength(13);
                entity.Property(e => e.NormalizePhoneNumber).HasMaxLength(13);
                entity.Property(e => e.FirstName).HasMaxLength(150);
                entity.Property(e => e.LastName).HasMaxLength(250);
                entity.Property(e => e.NationalCode).HasMaxLength(13);
                entity.Property(e => e.UserName).HasMaxLength(300);
                entity.Property(e => e.NormalizedUserName).HasMaxLength(300);

                #region Set Admin
                entity.HasData(new Users
                {
                    UserName = "Admin",
                    Email = "ali.moosaei.big@gmail.com",
                    Id = 1,
                    IsActive = true,
                    UserStatus = UserStatus.Accept,
                    FirstName = "Ali",
                    LastName = "Moosaei",
                    SecurityStamp = "K7JCQNNN4ULGGODXGAHOHXHF2MHWMYZU",
                    PasswordHash = "AQAAAAIAAYagAAAAECj4NT8lrikZFClrFPC8twPx+S1/oWchdVTHyKWMeCWBxYBGM6RQguQbnafnYrn+Lg=="
                });
                #endregion

            });

            builder.Entity<BasColor>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__BasColor__3214EC07A064CB55");

                entity.ToTable("BasColor");
                entity.HasIndex(e => e.PersianColorName, "IX_BasColor_PersianName");
                entity.Property(e => e.EnglishColorName).HasMaxLength(220);
                entity.Property(e => e.PersianColorName).HasMaxLength(220);
                entity.Property(e => e.HexCode).HasMaxLength(8);
            });

            builder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Category__3214EC07CAB36CD4");

                entity.ToTable("Category");

                entity.Property(e => e.CategoryName).HasMaxLength(500);
            });

            builder.Entity<Good>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Goods__3214EC07B9ED6410");
                entity.HasIndex(e => e.GoodCode, "IX__Goods__GoodCode").IsUnique(true);

                entity.Property(e => e.GoodName).HasMaxLength(650);
                entity.Property(e => e.GoodCode).HasMaxLength(150);

                entity.HasOne(d => d.GroupGoodRefNavigation).WithMany(p => p.Goods)
                    .HasForeignKey(d => d.GroupGoodRef)
                    .HasConstraintName("FK__Goods__GroupGood__3C69FB99")
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany(e => e.GoodImages).WithOne(e => e.GoodRefNavigation)
                .HasForeignKey(e => e.GoodRef)
                .HasConstraintName("FK__GoodImag__Good__GoodRef")
                .OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<GoodsColor>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__GoodsCol__3214EC077CEA16CD");

                entity.HasOne(d => d.ColorRefNavigation).WithMany(p => p.GoodsColors)
                    .HasForeignKey(d => d.ColorRef)
                    .HasConstraintName("FK__GoodsColo__Color__412EB0B6")
                    .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(d => d.GoodRefNavigation).WithMany(p => p.GoodsColors)
                    .HasForeignKey(d => d.GoodRef)
                    .HasConstraintName("FK__GoodsColo__GoodR__4222D4EF")
                    .OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<GroupGood>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__GroupGoo__3214EC07D8E94B7D");

                entity.Property(e => e.GroupName).HasMaxLength(500);

                entity.HasOne(d => d.CategoryRefNavigation).WithMany(p => p.GroupGoods)
                    .HasForeignKey(d => d.CategoryRef)
                    .HasConstraintName("FK__GroupGood__Categ__38996AB5")
                    .OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<SendEmailSMSModel>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasMaxLength(40).HasColumnType("VARCHAR");
                entity.Property(e => e.Email).HasMaxLength(450);
                entity.Property(e => e.PhoneNumber).HasMaxLength(13);
                entity.HasIndex(e => e.Email, "IX_SendEmailSMSModel_Email");
                entity.HasIndex(e => e.PhoneNumber, "IX_SendEmailSMSModel_PhoneNumber");
            });

            builder.Entity<City>(entity =>
            {
                entity.HasKey(e => e.Key);
                entity.HasOne(e => e.ProvinceRefNavigation).WithMany(e => e.Cities)
                .HasForeignKey(e => e.ProvinceRef)
                .HasConstraintName("FK__RootRef__City__38996AB6")
                .OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<HistorySendSMS>(entity =>
            {
                entity.HasIndex(e => e.Mobile, "IX_HistorySendSMS_Mobile");

                entity.HasKey(e => e.Id);
                entity.Property(e => e.InsertDateTime).HasColumnType("datetime2(7)");
                entity.Property(e => e.Ip).HasMaxLength(16);
                entity.Property(e => e.Mobile).HasMaxLength(13);
                entity.Property(e => e.Message).HasMaxLength(500);
                entity.Property(e => e.Client).HasMaxLength(500);

                entity.HasOne(e => e.UserRefNavigation)
                .WithMany(e => e.HistorySms)
                .HasForeignKey(e => e.UserRef)
                .HasConstraintName("FK__HistorySms__Users__UserRef")
                .OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Orders__3214EC0794D2559C");

                entity.HasIndex(e => e.OrderSerial, "IX__Orders__OrderSerial").IsUnique(true);
                entity.HasIndex(e => e.OrderKey, "IX__Orders__OrderKey").IsUnique(true);

                entity.Property(e => e.OrderKey).HasDefaultValue<string>(Guid.NewGuid().ToString());
                entity.Property(e => e.CreateDateTime).HasColumnType("datetime");
                entity.Property(e => e.UpdateDateTime).HasColumnType("datetime");

                entity.HasOne(d => d.UserRefNavigation).WithMany(p => p.Orders)
                    .HasForeignKey(d => d.UserRef)
                    .HasConstraintName("FK__Orders__UserRef__02FC7413");

                entity.HasOne(e => e.StatusOrderRefNavigation).WithMany(e => e.Orders)
                .HasForeignKey(e => e.StatusOrderRef)
                .HasConstraintName("FK__Orders__basLookup__StatusOrderRef")
                .OnDelete(DeleteBehavior.Cascade);
            });

            builder.Entity<GoodOfOrder>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__GoodOfOr__3214EC07C7CB92A6");

                entity.ToTable("GoodOfOrder");

                entity.Property(e => e.CreateDateTime).HasColumnType("datetime");

                entity.HasOne(d => d.GoodRefNavigation).WithMany(p => p.GoodOfOrders)
                    .HasForeignKey(d => d.GoodRef)
                    .HasConstraintName("FK__GoodOfOrd__GoodR__05D8E0BE");

                entity.HasOne(d => d.OrderRefNavigation).WithMany(p => p.GoodOfOrders)
                    .HasForeignKey(d => d.OrderRef)
                    .HasConstraintName("FK__GoodOfOrd__Order__06CD04F7");
            });

            builder.Entity<Address>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.HasIndex(e => e.PhoneNumber_Receiver, "IX__Address__PhoneNumberReceiver");
                entity.HasIndex(e => e.PostalCode, "IX__Address__PostalCode");

                entity.Property(e => e.PhoneNumber_Receiver).HasMaxLength(13);
                entity.Property(e => e.PostalCode).HasMaxLength(10);

                entity.HasOne(e => e.CityRefNavigation).WithMany(e => e.Addresses)
                .HasForeignKey(e=>e.CityRef)
                .HasConstraintName("FK__Addresses__City__CityRef")
                .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(e=>e.UserRefNavigation).WithMany(e=>e.Addresses)
                .HasForeignKey(e=>e.UserRef)
                .HasConstraintName("FK__Addresses__User__UserRef")
                .OnDelete(DeleteBehavior.Cascade);

            });

            builder.Entity<BasLookup>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.HasIndex(e => e.Type, "IX__BasLookup__Type");

                entity.Property(e=>e.Type).HasMaxLength(100);
                entity.Property(e=>e.Key).HasMaxLength(40);

            });

            builder.Entity<OrderHistory>(entity =>
            {
                entity.HasKey(e => e.Id);
                
                entity.HasOne(e => e.UserRefNavigation)
                .WithMany(e => e.OrderHistories)
                .HasForeignKey(e => e.UserRef)
                .HasConstraintName("FK__Users__OrderHistory__UserRef")
                .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(e => e.StatusOrderRefNavigation)
                .WithMany(e => e.OrderHistories)
                .HasForeignKey(e => e.StatusOrderRef)
                .HasConstraintName("FK__Baslookup__OrderHistory__StatusOrderRef")
                .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(e => e.OrderRefNavigation)
                .WithMany(e => e.OrderHistories)
                .HasForeignKey(e => e.OrderRef)
                .HasConstraintName("FK__Orders__OrderHistory__OrderRef")
                .OnDelete(DeleteBehavior.NoAction);

            });

            #region Set Data For Roles
            builder.Entity<Roles>().HasData(new List<Roles>
            {
                new Roles
                {
                    Id = 1,
                    Name = DL.ToolsBLU.UserRoles.Administrator.ToString(),
                    NormalizedName = DL.ToolsBLU.UserRoles.Administrator.ToString().ToUpper(),
                    PersianName = "ادمین"
                },
                new Roles
                {
                    Id = 2,
                    Name = DL.ToolsBLU.UserRoles.DefulatUser.ToString(),
                    NormalizedName = DL.ToolsBLU.UserRoles.DefulatUser.ToString().ToUpper(),
                    PersianName = "کاربر عادی"
                },
                new Roles
                {
                    Id = 3,
                    Name = DL.ToolsBLU.UserRoles.MiddLevelUser.ToString(),
                    NormalizedName = DL.ToolsBLU.UserRoles.MiddLevelUser.ToString().ToUpper(),
                    PersianName = "کاربر سطح دو"
                },
                new Roles
                {
                    Id = 4,
                    Name = DL.ToolsBLU.UserRoles.TopLevelUser.ToString(),
                    NormalizedName = DL.ToolsBLU.UserRoles.TopLevelUser.ToString().ToUpper(),
                    PersianName = "کاربر سطح سه"
                },
            });
            #endregion

        }
    }
}
