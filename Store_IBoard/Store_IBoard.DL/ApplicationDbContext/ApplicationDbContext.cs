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
    public class ApplicationDbContext : IdentityDbContext<Users, Roles, long>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> option)
            : base(option)
        { }

        public virtual DbSet<BasColor> BasColors { get; set; }

        public virtual DbSet<Category> Categories { get; set; }

        public virtual DbSet<Good> Goods { get; set; }

        public virtual DbSet<GoodsColor> GoodsColors { get; set; }

        public virtual DbSet<GroupGood> GroupGoods { get; set; }
        
        public virtual DbSet<SendEmailSMSModel> SendEmailSMSModels { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<IdentityUserLogin<long>>(entity =>
            {
                entity.HasNoKey();
            });

            builder.Entity<IdentityUserRole<long>>(entity =>
            {
                entity.HasNoKey();
            });
            
            builder.Entity<IdentityUserToken<long>>(entity =>
            {
                entity.HasNoKey();
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

                entity.Property(e => e.GoodName).HasMaxLength(650);

                entity.HasOne(d => d.GroupGoodRefNavigation).WithMany(p => p.Goods)
                    .HasForeignKey(d => d.GroupGoodRef)
                    .HasConstraintName("FK__Goods__GroupGood__3C69FB99");
            });

            builder.Entity<GoodsColor>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__GoodsCol__3214EC077CEA16CD");

                entity.HasOne(d => d.ColorRefNavigation).WithMany(p => p.GoodsColors)
                    .HasForeignKey(d => d.ColorRef)
                    .HasConstraintName("FK__GoodsColo__Color__412EB0B6");

                entity.HasOne(d => d.GoodRefNavigation).WithMany(p => p.GoodsColors)
                    .HasForeignKey(d => d.GoodRef)
                    .HasConstraintName("FK__GoodsColo__GoodR__4222D4EF");
            });

            builder.Entity<GroupGood>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__GroupGoo__3214EC07D8E94B7D");

                entity.Property(e => e.GroupName).HasMaxLength(500);

                entity.HasOne(d => d.CategoryRefNavigation).WithMany(p => p.GroupGoods)
                    .HasForeignKey(d => d.CategoryRef)
                    .HasConstraintName("FK__GroupGood__Categ__38996AB5");
            });

            builder.Entity<SendEmailSMSModel>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e=>e.Id).HasMaxLength(40).HasColumnType("VARCHAR");
                entity.Property(e => e.Email).HasMaxLength(450);
                entity.Property(e => e.PhoneNumber).HasMaxLength(13);
                entity.HasIndex(e => e.Email, "IX_SendEmailSMSModel_Email");
                entity.HasIndex(e => e.PhoneNumber, "IX_SendEmailSMSModel_PhoneNumber");
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
