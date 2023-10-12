using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SmartNestAPI.Domain.Entities.Database
{
    public partial class PostgreSqlContext : DbContext
    {
        public PostgreSqlContext()
        {
        }

        public PostgreSqlContext(DbContextOptions<PostgreSqlContext> options)
            : base(options)
        {
        }
        public virtual DbSet<AlertMethodReq> SnAlertMethods { get; set; } = null!;
        public virtual DbSet<SnCategory> SnCategories { get; set; } = null!;
        public virtual DbSet<SnContainer> SnContainers { get; set; } = null!;
        public virtual DbSet<SnContainerLog> SnContainerLogs { get; set; } = null!;
        public virtual DbSet<SnContainerRule> SnContainerRules { get; set; } = null!;
        public virtual DbSet<SnOnBoarding> SnOnBoardings { get; set; } = null!;
        public virtual DbSet<SnOrder> SnOrders { get; set; } = null!;
        public virtual DbSet<SnProduct> SnProducts { get; set; } = null!;
        public virtual DbSet<SnShoppingList> SnShoppingLists { get; set; } = null!;
        public virtual DbSet<SnSupplier> SnSuppliers { get; set; } = null!;
        public virtual DbSet<SnSupplierProduct> SnSupplierProducts { get; set; } = null!;
        public virtual DbSet<SnUser> SnUsers { get; set; } = null!;
        public virtual DbSet<SnUserAddress> SnUserAddresses { get; set; } = null!;
        public virtual DbSet<SnUserContainer> SnUserContainers { get; set; } = null!;
        public virtual DbSet<SnUserDevice> SnUserDevices { get; set; } = null!;
        public virtual DbSet<SnUserPaymentMethod> SnUserPaymentMethods { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Your connection string");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AlertMethodReq>(entity =>
            {
                entity.ToTable("SN_AlertMethods");

                entity.Property(e => e.Id).HasDefaultValueSql("gen_random_uuid()");
            });

            modelBuilder.Entity<SnCategory>(entity =>
            {

                entity.ToTable("SN_Categories");

                entity.Property(e => e.Id).HasDefaultValueSql("gen_random_uuid()");

                entity.Property(e => e.IsVisible).HasColumnName("isVisible");

                entity.Property(e => e.OrderNumber).HasDefaultValueSql("100");
            });

            modelBuilder.Entity<SnContainer>(entity =>
            {
                entity.ToTable("SN_Containers");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Price).HasColumnType("money");
            });

            modelBuilder.Entity<SnContainerLog>(entity =>
            {

                entity.ToTable("SN_Container_Log");

                entity.Property(e => e.DateTimeStamp).HasDefaultValueSql("timezone('utc'::text, now())");
            });

            modelBuilder.Entity<SnContainerRule>(entity =>
            {

                entity.ToTable("SN_Container_Rules");
            });

            modelBuilder.Entity<SnOnBoarding>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("SN_OnBoarding");

                entity.Property(e => e.Id).HasDefaultValueSql("gen_random_uuid()");
            });

            modelBuilder.Entity<SnOrder>(entity =>
            {
                entity.ToTable("SN_Orders");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.DateOrdered).HasPrecision(6);

                entity.Property(e => e.PaidAmount).HasColumnType("money");
            });

            modelBuilder.Entity<SnProduct>(entity =>
            {
                entity.ToTable("SN_Products");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(255);
            });

            modelBuilder.Entity<SnShoppingList>(entity =>
            {

                entity.ToTable("SN_ShoppingList");
            });

            modelBuilder.Entity<SnSupplier>(entity =>
            {

                entity.ToTable("SN_Suppliers");

                entity.Property(e => e.Id).HasDefaultValueSql("gen_random_uuid()");
            });

            modelBuilder.Entity<SnSupplierProduct>(entity =>
            {
                entity.ToTable("SN_Supplier_Products");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.Rrp).HasColumnType("money");
            });

            modelBuilder.Entity<SnUser>(entity =>
            {
                entity.ToTable("SN_Users");

                entity.Property(e => e.Id).HasDefaultValueSql("gen_random_uuid()");

                entity.Property(e => e.DateCreate).HasDefaultValueSql("timezone('utc'::text, now())");

                entity.Property(e => e.ProfileUrl).HasMaxLength(255);
            });

            modelBuilder.Entity<SnUserAddress>(entity =>
            {
                entity.ToTable("SN_User_Addresses");

                entity.Property(e => e.Id).HasDefaultValueSql("gen_random_uuid()");
            });

            modelBuilder.Entity<SnUserContainer>(entity =>
            {

                entity.ToTable("SN_User_Containers");
            });

            modelBuilder.Entity<SnUserDevice>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("SN_User_Devices");

                entity.Property(e => e.Id).HasDefaultValueSql("gen_random_uuid()");
            });

            modelBuilder.Entity<SnUserPaymentMethod>(entity =>
            {
                entity.ToTable("SN_User_PaymentMethods");

                entity.Property(e => e.Id).HasDefaultValueSql("gen_random_uuid()");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
