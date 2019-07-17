using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using FoodDelivery.Models;

namespace FoodDelivery.Data
{
    public partial class FoodDeliveryContext : DbContext
    {
        public FoodDeliveryContext()
        {
        }

        public FoodDeliveryContext(DbContextOptions<FoodDeliveryContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<DeliveryAddress> DeliveryAddress { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderItem> OrderItem { get; set; }
        public virtual DbSet<OrderStatus> OrderStatus { get; set; }
        public virtual DbSet<PaymentMethod> PaymentMethod { get; set; }
        public virtual DbSet<Restaurant> Restaurant { get; set; }
        public virtual DbSet<RestaurantMenu> RestaurantMenu { get; set; }
        public virtual DbSet<RestaurantMenuItem> RestaurantMenuItem { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.IdCustomer)
                    .HasName("PK__tbl_Cust__DB43864AD52E05A5");

                entity.ToTable("tbl_Customer");

                entity.Property(e => e.Email)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Password).IsRequired();
            });

            modelBuilder.Entity<DeliveryAddress>(entity =>
            {
                entity.HasKey(e => e.IdAddress)
                    .HasName("PK__tbl_Deli__F1CFF37FF175AFF1");

                entity.ToTable("tbl_DeliveryAddress");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Street)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.CustomerNavigation)
                    .WithMany(p => p.TblDeliveryAddress)
                    .HasForeignKey(d => d.IdCustomer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DeliveryAddress_Customer");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.IdOrder)
                    .HasName("PK__tbl_Orde__C38F3009BDFD1FDD");

                entity.ToTable("tbl_Order");

                entity.Property(e => e.CustomerNotes)
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.OrderGrossAmount).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.OrderNetAmount).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.OrderTax).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.AddressNavigation)
                    .WithMany(p => p.TblOrder)
                    .HasForeignKey(d => d.IdAddress)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_DeliveryAddress");

                entity.HasOne(d => d.CustomerNavigation)
                    .WithMany(p => p.TblOrder)
                    .HasForeignKey(d => d.IdCustomer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_Customer");

                entity.HasOne(d => d.OrderStatusNavigation)
                    .WithMany(p => p.TblOrder)
                    .HasForeignKey(d => d.IdOrderStatus)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_Status");

                entity.HasOne(d => d.PaymentMethodNavigation)
                    .WithMany(p => p.TblOrder)
                    .HasForeignKey(d => d.IdPaymentMethod)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_PaymentMethod");

                entity.HasOne(d => d.RestaurantNavigation)
                    .WithMany(p => p.TblOrder)
                    .HasForeignKey(d => d.IdRestaurant)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_Restaurant");
            });

            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.HasKey(e => e.IdOrderItem)
                    .HasName("PK__tbl_Orde__65E8C2F3807E9B8E");

                entity.ToTable("tbl_OrderItem");

                entity.Property(e => e.PricePerUnity).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Quantity).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.OrderNavigation)
                    .WithMany(p => p.TblOrderItem)
                    .HasForeignKey(d => d.IdOrder)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrderItem_Order");

                entity.HasOne(d => d.RestaurantMenuItemNavigation)
                  .WithMany(p => p.TblOrderItem)
                  .HasForeignKey(d => d.IdRestaurantMenuItem)
                  .OnDelete(DeleteBehavior.ClientSetNull)
                  .HasConstraintName("FK_OrderItem_RestaurantMenuItem");

            });

            modelBuilder.Entity<OrderStatus>(entity =>
            {
                entity.HasKey(e => e.IdOrderStatus)
                    .HasName("PK__tbl_Orde__CFDB504663CAB332");

                entity.ToTable("tbl_OrderStatus");

                entity.Property(e => e.StatusName)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PaymentMethod>(entity =>
            {
                entity.HasKey(e => e.IdPaymentMethod)
                    .HasName("PK__tbl_Paym__92CFFF9611484FED");

                entity.ToTable("tbl_PaymentMethod");

                entity.Property(e => e.ExpireDate).HasColumnType("datetime");

                entity.HasOne(d => d.CustomerNavigation)
                    .WithMany(p => p.TblPaymentMethod)
                    .HasForeignKey(d => d.IdCustomer)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PaymentMethod_Customer");
            });

            modelBuilder.Entity<Restaurant>(entity =>
            {
                entity.HasKey(e => e.IdRestaurant)
                    .HasName("PK__tbl_Rest__311D1D13132FA81F");

                entity.ToTable("tbl_Restaurant");

                entity.Property(e => e.Cuisine)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RestaurantMenu>(entity =>
            {
                entity.HasKey(e => e.IdRestaurantMenu)
                    .HasName("PK__tbl_Rest__6861EAA44F8D8670");

                entity.ToTable("tbl_RestaurantMenu");

                entity.Property(e => e.MenuName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.MenuType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.RestaurantNavigation)
                    .WithMany(p => p.TblRestaurantMenu)
                    .HasForeignKey(d => d.IdRestaurant)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RestaurantMenu_Restaurant");
            });

            modelBuilder.Entity<RestaurantMenuItem>(entity =>
            {
                entity.HasKey(e => e.IdRestaurantMenuItem)
                    .HasName("PK__tbl_Rest__97544FC9D2184FB8");

                entity.ToTable("tbl_RestaurantMenuItem");

                entity.Property(e => e.ItemDescription)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ItemName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ItemPrice).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.RestaurantMenuNavigation)
                    .WithMany(p => p.TblRestaurantMenuItem)
                    .HasForeignKey(d => d.IdRestaurantMenu)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RestaurantMenuItem_RestaurantMenu");
            });
        }
    }
}
