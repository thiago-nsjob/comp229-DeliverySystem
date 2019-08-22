using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace RestaurantDelivery.Models
{
    public partial class RestaurantDeliveryContext : DbContext
    {
        public RestaurantDeliveryContext()
        {
        }

        public RestaurantDeliveryContext(DbContextOptions<RestaurantDeliveryContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MenuItems> MenuItems { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Restaurants> Restaurants { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=RestaurantDelivery;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<MenuItems>(entity =>
            {
                entity.HasKey(e => e.IdMenuItem);

                entity.Property(e => e.ItemDescription)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ItemName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ItemPrice).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.IdRestaurantNavigation)
                    .WithMany(p => p.MenuItems)
                    .HasForeignKey(d => d.IdRestaurant)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MenuItems_Restaurants");
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasKey(e => e.IdOrder);

                entity.Property(e => e.IdOrder).ValueGeneratedNever();

                entity.Property(e => e.CustomerAddress)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerNotes)
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.OrderGrossAmount).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.OrderNetAmount).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.OrderTax).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.IdMenuItemNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.IdMenuItem)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orders_MenuItems");

                entity.HasOne(d => d.IdRestaurantNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.IdRestaurant)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orders_Restaurants");
            });

            modelBuilder.Entity<Restaurants>(entity =>
            {
                entity.HasKey(e => e.IdRestaurant);

                entity.Property(e => e.Address).HasMaxLength(50);

                entity.Property(e => e.Cuisine).HasMaxLength(30);

                entity.Property(e => e.Description)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });
        }
    }
}
