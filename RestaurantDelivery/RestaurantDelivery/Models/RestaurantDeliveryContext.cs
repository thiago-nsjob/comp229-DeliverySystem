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

        public virtual DbSet<MenuItem> MenuItem { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<Restaurant> Restaurant { get; set; }

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

            modelBuilder.Entity<MenuItem>(entity =>
            {
                entity.HasKey(e => e.IdMenuItem)
                    .HasName("PK_MenuItems");

                entity.Property(e => e.ItemDescription)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ItemName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ItemPrice).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.IdRestaurantNavigation)
                    .WithMany(p => p.MenuItem)
                    .HasForeignKey(d => d.IdRestaurant)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MenuItems_Restaurants");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.IdOrder)
                    .HasName("PK_Orders");

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

                entity.HasOne(d => d.MenuItemNavigation)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.IdMenuItem)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orders_MenuItems");

                entity.HasOne(d => d.RestaurantNavigation)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.IdRestaurant)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Orders_Restaurants");
            });

            modelBuilder.Entity<Restaurant>(entity =>
            {
                entity.HasKey(e => e.IdRestaurant)
                    .HasName("PK_Restaurants");

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
