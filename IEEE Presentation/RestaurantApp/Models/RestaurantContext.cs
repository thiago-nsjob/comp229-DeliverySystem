using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace RestaurantApp.Models
{
    public partial class RestaurantContext : DbContext
    {
        public RestaurantContext()
        {
        }

        public RestaurantContext(DbContextOptions<RestaurantContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Restaurant> Restaurant { get; set; }
        public virtual DbSet<RestaurantMenu> RestaurantMenu { get; set; }
        public virtual DbSet<RestaurantMenuItem> RestaurantMenuItem { get; set; }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Restaurant>(entity =>
            {
                entity.HasKey(e => e.IdRestaurant);

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
                entity.HasKey(e => e.IdRestaurantMenu);

                entity.Property(e => e.MenuName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.MenuType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdRestaurantNavigation)
                    .WithMany(p => p.RestaurantMenu)
                    .HasForeignKey(d => d.IdRestaurant)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RestaurantMenu_Restaurant");
            });

            modelBuilder.Entity<RestaurantMenuItem>(entity =>
            {
                entity.HasKey(e => e.IdRestaurantMenuItem);

                entity.Property(e => e.ItemDescription)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ItemName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.ItemPrice).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.IdRestaurantMenuNavigation)
                    .WithMany(p => p.RestaurantMenuItem)
                    .HasForeignKey(d => d.IdRestaurantMenu)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_RestaurantMenuItem_RestaurantMenu");
            });
        }
    }
}
