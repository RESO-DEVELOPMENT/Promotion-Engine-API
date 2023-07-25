using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Infrastructure.Models
{
    public partial class PointifyContext : DbContext
    {
        public PointifyContext()
        {
        }

        public PointifyContext(DbContextOptions<PointifyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<Action> Action { get; set; }
        public virtual DbSet<ActionProductMapping> ActionProductMapping { get; set; }
        public virtual DbSet<Brand> Brand { get; set; }
        public virtual DbSet<Channel> Channel { get; set; }
        public virtual DbSet<ConditionGroup> ConditionGroup { get; set; }
        public virtual DbSet<ConditionRule> ConditionRule { get; set; }
        public virtual DbSet<Device> Device { get; set; }
        public virtual DbSet<GameCampaign> GameCampaign { get; set; }
        public virtual DbSet<GameItems> GameItems { get; set; }
        public virtual DbSet<GameMaster> GameMaster { get; set; }
        public virtual DbSet<Gift> Gift { get; set; }
        public virtual DbSet<GiftProductMapping> GiftProductMapping { get; set; }
        public virtual DbSet<Holiday> Holiday { get; set; }
        public virtual DbSet<MemberLevel> MemberLevel { get; set; }
        public virtual DbSet<MemberLevelMapping> MemberLevelMapping { get; set; }
        public virtual DbSet<Membership> Membership { get; set; }
        public virtual DbSet<OrderCondition> OrderCondition { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductCategory> ProductCategory { get; set; }
        public virtual DbSet<ProductCondition> ProductCondition { get; set; }
        public virtual DbSet<ProductConditionMapping> ProductConditionMapping { get; set; }
        public virtual DbSet<Promotion> Promotion { get; set; }
        public virtual DbSet<PromotionChannelMapping> PromotionChannelMapping { get; set; }
        public virtual DbSet<PromotionStoreMapping> PromotionStoreMapping { get; set; }
        public virtual DbSet<PromotionTier> PromotionTier { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Store> Store { get; set; }
        public virtual DbSet<StoreGameCampaignMapping> StoreGameCampaignMapping { get; set; }
        public virtual DbSet<Transaction> Transaction { get; set; }
        public virtual DbSet<Voucher> Voucher { get; set; }
        public virtual DbSet<VoucherGroup> VoucherGroup { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=120.72.85.82,9033;Database=Pointify;User Id=sa;Password=f0^wyhMfl*25;Encrypt=True;TrustServerCertificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(e => e.Username);

                entity.Property(e => e.Username).HasMaxLength(255);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.ImgUrl)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.InsDate).HasColumnType("datetime");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.UpdDate).HasColumnType("datetime");

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.Account)
                    .HasForeignKey(d => d.BrandId)
                    .HasConstraintName("FK_Account_Brand");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Account)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Account_Role");
            });

            modelBuilder.Entity<Action>(entity =>
            {
                entity.Property(e => e.ActionId).ValueGeneratedNever();

                entity.Property(e => e.BundlePrice).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.DiscountAmount).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.DiscountPercentage).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.FixedPrice).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.InsDate).HasColumnType("datetime");

                entity.Property(e => e.LadderPrice).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.MaxAmount).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.MinPriceAfter).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.Property(e => e.UpdDate).HasColumnType("datetime");

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.Action)
                    .HasForeignKey(d => d.BrandId)
                    .HasConstraintName("FK_Action_Brand");
            });

            modelBuilder.Entity<ActionProductMapping>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.InsDate).HasColumnType("datetime");

                entity.Property(e => e.UpdDate).HasColumnType("datetime");

                entity.HasOne(d => d.Action)
                    .WithMany(p => p.ActionProductMapping)
                    .HasForeignKey(d => d.ActionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ActionProductMapping_Action");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ActionProductMapping)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ActionProductMapping_Product");
            });

            modelBuilder.Entity<Brand>(entity =>
            {
                entity.Property(e => e.BrandId).ValueGeneratedNever();

                entity.Property(e => e.BrandCode).HasMaxLength(255);

                entity.Property(e => e.BrandEmail).HasMaxLength(255);

                entity.Property(e => e.BrandName).HasMaxLength(255);

                entity.Property(e => e.CompanyName).HasMaxLength(255);

                entity.Property(e => e.ImgUrl).HasMaxLength(255);

                entity.Property(e => e.InsDate).HasColumnType("datetime");

                entity.Property(e => e.PhoneNumber).HasMaxLength(255);

                entity.Property(e => e.UpdDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Channel>(entity =>
            {
                entity.Property(e => e.ChannelId).ValueGeneratedNever();

                entity.Property(e => e.ChannelCode).HasMaxLength(255);

                entity.Property(e => e.ChannelName).HasMaxLength(255);

                entity.Property(e => e.InsDate).HasColumnType("datetime");

                entity.Property(e => e.UpdDate).HasColumnType("datetime");

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.Channel)
                    .HasForeignKey(d => d.BrandId)
                    .HasConstraintName("FK_Channel_Brand");
            });

            modelBuilder.Entity<ConditionGroup>(entity =>
            {
                entity.Property(e => e.ConditionGroupId).ValueGeneratedNever();

                entity.Property(e => e.InsDate).HasColumnType("datetime");

                entity.Property(e => e.UpdDate).HasColumnType("datetime");

                entity.HasOne(d => d.ConditionRule)
                    .WithMany(p => p.ConditionGroup)
                    .HasForeignKey(d => d.ConditionRuleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ConditionGroup_ConditionRule");
            });

            modelBuilder.Entity<ConditionRule>(entity =>
            {
                entity.Property(e => e.ConditionRuleId).ValueGeneratedNever();

                entity.Property(e => e.InsDate).HasColumnType("datetime");

                entity.Property(e => e.RuleName).HasMaxLength(255);

                entity.Property(e => e.UpdDate).HasColumnType("datetime");

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.ConditionRule)
                    .HasForeignKey(d => d.BrandId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ConditionRule_Brand");
            });

            modelBuilder.Entity<Device>(entity =>
            {
                entity.Property(e => e.DeviceId).ValueGeneratedNever();

                entity.Property(e => e.Code).HasMaxLength(255);

                entity.Property(e => e.InsDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.Property(e => e.UpdDate).HasColumnType("datetime");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.Device)
                    .HasForeignKey(d => d.StoreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Device_Store");
            });

            modelBuilder.Entity<GameCampaign>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.EndGame).HasColumnType("datetime");

                entity.Property(e => e.InsDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.Property(e => e.SecretCode).HasMaxLength(255);

                entity.Property(e => e.StartGame).HasColumnType("datetime");

                entity.Property(e => e.UpdDate).HasColumnType("datetime");

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.GameCampaign)
                    .HasForeignKey(d => d.BrandId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GameCampaign_Brand");

                entity.HasOne(d => d.GameMaster)
                    .WithMany(p => p.GameCampaign)
                    .HasForeignKey(d => d.GameMasterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GameCampaign_GameMaster");

                entity.HasOne(d => d.Promotion)
                    .WithMany(p => p.GameCampaign)
                    .HasForeignKey(d => d.PromotionId)
                    .HasConstraintName("FK_GameCampaign_Promotion");
            });

            modelBuilder.Entity<GameItems>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.DisplayText).HasMaxLength(255);

                entity.Property(e => e.ImgUrl).HasMaxLength(255);

                entity.Property(e => e.InsDate).HasColumnType("datetime");

                entity.Property(e => e.ItemColor).HasMaxLength(255);

                entity.Property(e => e.TextColor).HasMaxLength(255);

                entity.Property(e => e.UpdDate).HasColumnType("datetime");

                entity.HasOne(d => d.Game)
                    .WithMany(p => p.GameItems)
                    .HasForeignKey(d => d.GameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GameItems_Game");
            });

            modelBuilder.Entity<GameMaster>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.InsDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.Property(e => e.UpdDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Gift>(entity =>
            {
                entity.Property(e => e.GiftId).ValueGeneratedNever();

                entity.Property(e => e.BonusPoint).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.InsDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(255);

                entity.Property(e => e.UpdDate).HasColumnType("datetime");

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.Gift)
                    .HasForeignKey(d => d.BrandId)
                    .HasConstraintName("Gift_Brand_BrandId_fk");

                entity.HasOne(d => d.GameCampaign)
                    .WithMany(p => p.Gift)
                    .HasForeignKey(d => d.GameCampaignId)
                    .HasConstraintName("Gift_GameCampaign_Id_fk");

                entity.HasOne(d => d.GiftVoucherGroup)
                    .WithMany(p => p.Gift)
                    .HasForeignKey(d => d.GiftVoucherGroupId)
                    .HasConstraintName("Gift_VoucherGroup_VoucherGroupId_fk");
            });

            modelBuilder.Entity<GiftProductMapping>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.InsDate).HasColumnType("datetime");

                entity.Property(e => e.UpdDate).HasColumnType("datetime");

                entity.HasOne(d => d.Gift)
                    .WithMany(p => p.GiftProductMapping)
                    .HasForeignKey(d => d.GiftId)
                    .HasConstraintName("FK__GiftProdu__GiftI__02084FDA");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.GiftProductMapping)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__GiftProdu__Produ__10566F31");
            });

            modelBuilder.Entity<Holiday>(entity =>
            {
                entity.Property(e => e.HolidayId).ValueGeneratedNever();

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.HolidayName)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.InsDate).HasColumnType("datetime");

                entity.Property(e => e.UpdDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<MemberLevel>(entity =>
            {
                entity.Property(e => e.MemberLevelId).ValueGeneratedNever();

                entity.Property(e => e.InsDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UpdDate).HasColumnType("datetime");

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.MemberLevel)
                    .HasForeignKey(d => d.BrandId)
                    .HasConstraintName("FK__MemberLev__Brand__03F0984C");
            });

            modelBuilder.Entity<MemberLevelMapping>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.InsDate).HasColumnType("datetime");

                entity.Property(e => e.UpdDate).HasColumnType("datetime");

                entity.HasOne(d => d.MemberLevel)
                    .WithMany(p => p.MemberLevelMapping)
                    .HasForeignKey(d => d.MemberLevelId)
                    .HasConstraintName("FK__MemberLev__Membe__04E4BC85");

                entity.HasOne(d => d.Promotion)
                    .WithMany(p => p.MemberLevelMapping)
                    .HasForeignKey(d => d.PromotionId)
                    .HasConstraintName("FK__MemberLev__Promo__18EBB532");
            });

            modelBuilder.Entity<Membership>(entity =>
            {
                entity.Property(e => e.MembershipId).ValueGeneratedNever();

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Fullname)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.InsDate).HasColumnType("datetime");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UpdDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<OrderCondition>(entity =>
            {
                entity.Property(e => e.OrderConditionId).ValueGeneratedNever();

                entity.Property(e => e.Amount).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.AmountOperator)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.InsDate).HasColumnType("datetime");

                entity.Property(e => e.QuantityOperator)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UpdDate).HasColumnType("datetime");

                entity.HasOne(d => d.ConditionGroup)
                    .WithMany(p => p.OrderCondition)
                    .HasForeignKey(d => d.ConditionGroupId)
                    .HasConstraintName("FK__OrderCond__Condi__07C12930");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.ProductId).ValueGeneratedNever();

                entity.Property(e => e.ImgUrl).HasMaxLength(255);

                entity.Property(e => e.InsDate).HasColumnType("datetime");

                entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.ProductCode).HasMaxLength(255);

                entity.Property(e => e.ProductName).HasMaxLength(255);

                entity.Property(e => e.UpdDate).HasColumnType("datetime");

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.BrandId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_Brand");

                entity.HasOne(d => d.ProductCate)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.ProductCateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Product_ProductCategory");
            });

            modelBuilder.Entity<ProductCategory>(entity =>
            {
                entity.HasKey(e => e.ProductCateId);

                entity.Property(e => e.ProductCateId).ValueGeneratedNever();

                entity.Property(e => e.CateId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.InsDate).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.UpdDate).HasColumnType("datetime");

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.ProductCategory)
                    .HasForeignKey(d => d.BrandId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProductCategory_Brand");
            });

            modelBuilder.Entity<ProductCondition>(entity =>
            {
                entity.Property(e => e.ProductConditionId).ValueGeneratedNever();

                entity.Property(e => e.InsDate).HasColumnType("datetime");

                entity.Property(e => e.QuantityOperator)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.UpdDate).HasColumnType("datetime");

                entity.HasOne(d => d.ConditionGroup)
                    .WithMany(p => p.ProductCondition)
                    .HasForeignKey(d => d.ConditionGroupId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ProductCondition_ConditionGroup_ConditionGroupId_fk");
            });

            modelBuilder.Entity<ProductConditionMapping>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.InsDate).HasColumnType("datetime");

                entity.Property(e => e.UpdDate).HasColumnType("datetime");

                entity.HasOne(d => d.ProductCondition)
                    .WithMany(p => p.ProductConditionMapping)
                    .HasForeignKey(d => d.ProductConditionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ProductConditionMapping_ProductCondition_ProductConditionId_fk");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductConditionMapping)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ProductConditionMapping_Product_ProductId_fk");
            });

            modelBuilder.Entity<Promotion>(entity =>
            {
                entity.Property(e => e.PromotionId).ValueGeneratedNever();

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.ImgUrl).IsRequired();

                entity.Property(e => e.InsDate).HasColumnType("datetime");

                entity.Property(e => e.PromotionCode)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.PromotionName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.UpdDate).HasColumnType("datetime");

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.Promotion)
                    .HasForeignKey(d => d.BrandId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Promotion_Brand");
            });

            modelBuilder.Entity<PromotionChannelMapping>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.InsDate).HasColumnType("datetime");

                entity.Property(e => e.UpdDate).HasColumnType("datetime");

                entity.HasOne(d => d.Channel)
                    .WithMany(p => p.PromotionChannelMapping)
                    .HasForeignKey(d => d.ChannelId)
                    .HasConstraintName("PromotionChannelMapping___fk");

                entity.HasOne(d => d.Promotion)
                    .WithMany(p => p.PromotionChannelMapping)
                    .HasForeignKey(d => d.PromotionId)
                    .HasConstraintName("PromotionChannelMapping_Promotion__fk");
            });

            modelBuilder.Entity<PromotionStoreMapping>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.InsDate).HasColumnType("datetime");

                entity.Property(e => e.UpdDate).HasColumnType("datetime");

                entity.HasOne(d => d.Promotion)
                    .WithMany(p => p.PromotionStoreMapping)
                    .HasForeignKey(d => d.PromotionId)
                    .HasConstraintName("PromotionStoreMapping___fk");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.PromotionStoreMapping)
                    .HasForeignKey(d => d.StoreId)
                    .HasConstraintName("PromotionStoreMapping_Store__fk");
            });

            modelBuilder.Entity<PromotionTier>(entity =>
            {
                entity.Property(e => e.PromotionTierId).ValueGeneratedNever();

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.InsDate).HasColumnType("datetime");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.TierName).HasMaxLength(255);

                entity.Property(e => e.UpdDate).HasColumnType("datetime");

                entity.HasOne(d => d.Action)
                    .WithMany(p => p.PromotionTier)
                    .HasForeignKey(d => d.ActionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PromotionTier_Action_ActionId_fk");

                entity.HasOne(d => d.ConditionRule)
                    .WithMany(p => p.PromotionTier)
                    .HasForeignKey(d => d.ConditionRuleId)
                    .HasConstraintName("PromotionTier_ConditionRule_ConditionRuleId_fk");

                entity.HasOne(d => d.Gift)
                    .WithMany(p => p.PromotionTier)
                    .HasForeignKey(d => d.GiftId)
                    .HasConstraintName("PromotionTier_Gift_GiftId_fk");

                entity.HasOne(d => d.Promotion)
                    .WithMany(p => p.PromotionTier)
                    .HasForeignKey(d => d.PromotionId)
                    .HasConstraintName("FK_PromotionTier_Promotion");

                entity.HasOne(d => d.VoucherGroup)
                    .WithMany(p => p.PromotionTier)
                    .HasForeignKey(d => d.VoucherGroupId)
                    .HasConstraintName("PromotionTier_VoucherGroup_VoucherGroupId_fk");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.RoleId).ValueGeneratedNever();

                entity.Property(e => e.InsDate).HasColumnType("datetime");

                entity.Property(e => e.RoleName).HasMaxLength(255);

                entity.Property(e => e.UpdDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.Property(e => e.StoreId).ValueGeneratedNever();

                entity.Property(e => e.ImgUrl).HasMaxLength(255);

                entity.Property(e => e.InsDate).HasColumnType("datetime");

                entity.Property(e => e.PhoneNumber).HasMaxLength(255);

                entity.Property(e => e.StoreCode).HasMaxLength(255);

                entity.Property(e => e.StoreName).HasMaxLength(255);

                entity.Property(e => e.UpdDate).HasColumnType("datetime");

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.Store)
                    .HasForeignKey(d => d.BrandId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Store_Brand");
            });

            modelBuilder.Entity<StoreGameCampaignMapping>(entity =>
            {
                entity.HasKey(e => e.StoreGameCampaignId)
                    .HasName("PK__StoreGam__08A65D651DE6FD06");

                entity.Property(e => e.StoreGameCampaignId).ValueGeneratedNever();

                entity.Property(e => e.InsDate).HasColumnType("datetime");

                entity.Property(e => e.UpdDate).HasColumnType("datetime");

                entity.HasOne(d => d.GameCampaign)
                    .WithMany(p => p.StoreGameCampaignMapping)
                    .HasForeignKey(d => d.GameCampaignId)
                    .HasConstraintName("FK__StoreGame__GameC__1332DBDC");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.StoreGameCampaignMapping)
                    .HasForeignKey(d => d.StoreId)
                    .HasConstraintName("FK__StoreGame__Store__14270015");
            });

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.InsDate).HasColumnType("datetime");

                entity.Property(e => e.UpdDate).HasColumnType("datetime");

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.Transaction)
                    .HasForeignKey(d => d.BrandId)
                    .HasConstraintName("FK__Transacti__Brand__151B244E");

                entity.HasOne(d => d.Promotion)
                    .WithMany(p => p.Transaction)
                    .HasForeignKey(d => d.PromotionId)
                    .HasConstraintName("FK__Transacti__Promo__4D5F7D71");

                entity.HasOne(d => d.Voucher)
                    .WithMany(p => p.Transaction)
                    .HasForeignKey(d => d.VoucherId)
                    .HasConstraintName("FK_Transaction_Voucher");
            });

            modelBuilder.Entity<Voucher>(entity =>
            {
                entity.Property(e => e.VoucherId).ValueGeneratedNever();

                entity.Property(e => e.InsDate).HasColumnType("datetime");

                entity.Property(e => e.OrderId).HasMaxLength(255);

                entity.Property(e => e.RedempedDate).HasColumnType("datetime");

                entity.Property(e => e.UpdDate).HasColumnType("datetime");

                entity.Property(e => e.UsedDate).HasColumnType("datetime");

                entity.Property(e => e.VoucherCode).HasMaxLength(255);

                entity.HasOne(d => d.Channel)
                    .WithMany(p => p.Voucher)
                    .HasForeignKey(d => d.ChannelId)
                    .HasConstraintName("FK__Voucher__Channel__17F790F9");

                entity.HasOne(d => d.GameCampaign)
                    .WithMany(p => p.Voucher)
                    .HasForeignKey(d => d.GameCampaignId)
                    .HasConstraintName("FK__Voucher__GameCam__18EBB532");

                entity.HasOne(d => d.Membership)
                    .WithMany(p => p.Voucher)
                    .HasForeignKey(d => d.MembershipId)
                    .HasConstraintName("FK__Voucher__Members__19DFD96B");

                entity.HasOne(d => d.Promotion)
                    .WithMany(p => p.Voucher)
                    .HasForeignKey(d => d.PromotionId)
                    .HasConstraintName("FK__Voucher__Promoti__540C7B00");

                entity.HasOne(d => d.PromotionTier)
                    .WithMany(p => p.Voucher)
                    .HasForeignKey(d => d.PromotionTierId)
                    .HasConstraintName("FK__Voucher__Promoti__1BC821DD");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.Voucher)
                    .HasForeignKey(d => d.StoreId)
                    .HasConstraintName("FK__Voucher__StoreId__1CBC4616");

                entity.HasOne(d => d.TransactionNavigation)
                    .WithMany(p => p.VoucherNavigation)
                    .HasForeignKey(d => d.TransactionId)
                    .HasConstraintName("FK__Voucher__Transac__1DB06A4F");

                entity.HasOne(d => d.VoucherGroup)
                    .WithMany(p => p.Voucher)
                    .HasForeignKey(d => d.VoucherGroupId)
                    .HasConstraintName("FK__Voucher__Voucher__1EA48E88");
            });

            modelBuilder.Entity<VoucherGroup>(entity =>
            {
                entity.Property(e => e.VoucherGroupId).ValueGeneratedNever();

                entity.Property(e => e.Charset).HasMaxLength(255);

                entity.Property(e => e.CustomCharset).HasMaxLength(255);

                entity.Property(e => e.ImgUrl).HasMaxLength(255);

                entity.Property(e => e.InsDate).HasColumnType("datetime");

                entity.Property(e => e.Postfix).HasMaxLength(255);

                entity.Property(e => e.Prefix).HasMaxLength(255);

                entity.Property(e => e.UpdDate).HasColumnType("datetime");

                entity.Property(e => e.VoucherName)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.HasOne(d => d.Action)
                    .WithMany(p => p.VoucherGroup)
                    .HasForeignKey(d => d.ActionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__VoucherGr__Actio__1F98B2C1");

                entity.HasOne(d => d.Brand)
                    .WithMany(p => p.VoucherGroup)
                    .HasForeignKey(d => d.BrandId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__VoucherGr__Brand__208CD6FA");

                entity.HasOne(d => d.GiftNavigation)
                    .WithMany(p => p.VoucherGroup)
                    .HasForeignKey(d => d.GiftId)
                    .HasConstraintName("FK__VoucherGr__GiftI__2180FB33");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
