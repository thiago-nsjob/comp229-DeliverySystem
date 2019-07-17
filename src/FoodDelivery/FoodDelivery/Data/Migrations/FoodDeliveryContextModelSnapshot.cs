﻿// <auto-generated />
using System;
using FoodDelivery.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FoodDelivery.Data.Migrations
{
    [DbContext(typeof(FoodDeliveryContext))]
    partial class FoodDeliveryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FoodDelivery.Models.Customer", b =>
                {
                    b.Property<int>("IdCustomer")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasMaxLength(150)
                        .IsUnicode(false);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<byte[]>("Password")
                        .IsRequired();

                    b.Property<int>("Phone");

                    b.HasKey("IdCustomer")
                        .HasName("PK__tbl_Cust__DB43864AD52E05A5");

                    b.ToTable("tbl_Customer");
                });

            modelBuilder.Entity("FoodDelivery.Models.DeliveryAddress", b =>
                {
                    b.Property<int>("IdAddress")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<int>("IdCustomer");

                    b.Property<int>("Number");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.HasKey("IdAddress")
                        .HasName("PK__tbl_Deli__F1CFF37FF175AFF1");

                    b.HasIndex("IdCustomer");

                    b.ToTable("tbl_DeliveryAddress");
                });

            modelBuilder.Entity("FoodDelivery.Models.Order", b =>
                {
                    b.Property<int>("IdOrder")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CustomerNotes")
                        .HasMaxLength(2000)
                        .IsUnicode(false);

                    b.Property<int>("IdAddress");

                    b.Property<int>("IdCustomer");

                    b.Property<int>("IdOrderStatus");

                    b.Property<int>("IdPaymentMethod");

                    b.Property<int>("IdRestaurant");

                    b.Property<decimal>("OrderGrossAmount")
                        .HasColumnType("decimal(18, 0)");

                    b.Property<decimal>("OrderNetAmount")
                        .HasColumnType("decimal(18, 0)");

                    b.Property<decimal>("OrderTax")
                        .HasColumnType("decimal(18, 0)");

                    b.HasKey("IdOrder")
                        .HasName("PK__tbl_Orde__C38F3009BDFD1FDD");

                    b.HasIndex("IdAddress");

                    b.HasIndex("IdCustomer");

                    b.HasIndex("IdOrderStatus");

                    b.HasIndex("IdPaymentMethod");

                    b.HasIndex("IdRestaurant");

                    b.ToTable("tbl_Order");
                });

            modelBuilder.Entity("FoodDelivery.Models.OrderItem", b =>
                {
                    b.Property<int>("IdOrderItem")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdOrder");

                    b.Property<int>("IdRestaurantMenuItem");

                    b.Property<decimal>("PricePerUnity")
                        .HasColumnType("decimal(18, 0)");

                    b.Property<decimal>("Quantity")
                        .HasColumnType("decimal(18, 0)");

                    b.HasKey("IdOrderItem")
                        .HasName("PK__tbl_Orde__65E8C2F3807E9B8E");

                    b.HasIndex("IdOrder");

                    b.HasIndex("IdRestaurantMenuItem");

                    b.ToTable("tbl_OrderItem");
                });

            modelBuilder.Entity("FoodDelivery.Models.OrderStatus", b =>
                {
                    b.Property<int>("IdOrderStatus")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("StatusName")
                        .HasMaxLength(30)
                        .IsUnicode(false);

                    b.HasKey("IdOrderStatus")
                        .HasName("PK__tbl_Orde__CFDB504663CAB332");

                    b.ToTable("tbl_OrderStatus");
                });

            modelBuilder.Entity("FoodDelivery.Models.PaymentMethod", b =>
                {
                    b.Property<int>("IdPaymentMethod")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CardNumber");

                    b.Property<DateTime>("ExpireDate")
                        .HasColumnType("datetime");

                    b.Property<int>("IdCustomer");

                    b.Property<int>("SecurityCode");

                    b.HasKey("IdPaymentMethod")
                        .HasName("PK__tbl_Paym__92CFFF9611484FED");

                    b.HasIndex("IdCustomer");

                    b.ToTable("tbl_PaymentMethod");
                });

            modelBuilder.Entity("FoodDelivery.Models.Restaurant", b =>
                {
                    b.Property<int>("IdRestaurant")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cuisine")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("Description")
                        .HasMaxLength(1000)
                        .IsUnicode(false);

                    b.Property<byte[]>("Image");

                    b.Property<string>("Name")
                        .HasMaxLength(30)
                        .IsUnicode(false);

                    b.HasKey("IdRestaurant")
                        .HasName("PK__tbl_Rest__311D1D13132FA81F");

                    b.ToTable("tbl_Restaurant");
                });

            modelBuilder.Entity("FoodDelivery.Models.RestaurantMenu", b =>
                {
                    b.Property<int>("IdRestaurantMenu")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdRestaurant");

                    b.Property<string>("MenuName")
                        .HasMaxLength(30)
                        .IsUnicode(false);

                    b.Property<string>("MenuType")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.HasKey("IdRestaurantMenu")
                        .HasName("PK__tbl_Rest__6861EAA44F8D8670");

                    b.HasIndex("IdRestaurant");

                    b.ToTable("tbl_RestaurantMenu");
                });

            modelBuilder.Entity("FoodDelivery.Models.RestaurantMenuItem", b =>
                {
                    b.Property<int>("IdRestaurantMenuItem")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdRestaurantMenu");

                    b.Property<string>("ItemDescription")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<string>("ItemName")
                        .HasMaxLength(30)
                        .IsUnicode(false);

                    b.Property<decimal>("ItemPrice")
                        .HasColumnType("decimal(18, 0)");

                    b.HasKey("IdRestaurantMenuItem")
                        .HasName("PK__tbl_Rest__97544FC9D2184FB8");

                    b.HasIndex("IdRestaurantMenu");

                    b.ToTable("tbl_RestaurantMenuItem");
                });

            modelBuilder.Entity("FoodDelivery.Models.DeliveryAddress", b =>
                {
                    b.HasOne("FoodDelivery.Models.Customer", "CustomerNavigation")
                        .WithMany("TblDeliveryAddress")
                        .HasForeignKey("IdCustomer")
                        .HasConstraintName("FK_DeliveryAddress_Customer");
                });

            modelBuilder.Entity("FoodDelivery.Models.Order", b =>
                {
                    b.HasOne("FoodDelivery.Models.DeliveryAddress", "AddressNavigation")
                        .WithMany("TblOrder")
                        .HasForeignKey("IdAddress")
                        .HasConstraintName("FK_Order_DeliveryAddress");

                    b.HasOne("FoodDelivery.Models.Customer", "CustomerNavigation")
                        .WithMany("TblOrder")
                        .HasForeignKey("IdCustomer")
                        .HasConstraintName("FK_Order_Customer");

                    b.HasOne("FoodDelivery.Models.OrderStatus", "OrderStatusNavigation")
                        .WithMany("TblOrder")
                        .HasForeignKey("IdOrderStatus")
                        .HasConstraintName("FK_Order_Status");

                    b.HasOne("FoodDelivery.Models.PaymentMethod", "PaymentMethodNavigation")
                        .WithMany("TblOrder")
                        .HasForeignKey("IdPaymentMethod")
                        .HasConstraintName("FK_Order_PaymentMethod");

                    b.HasOne("FoodDelivery.Models.Restaurant", "RestaurantNavigation")
                        .WithMany("TblOrder")
                        .HasForeignKey("IdRestaurant")
                        .HasConstraintName("FK_Order_Restaurant");
                });

            modelBuilder.Entity("FoodDelivery.Models.OrderItem", b =>
                {
                    b.HasOne("FoodDelivery.Models.Order", "OrderNavigation")
                        .WithMany("TblOrderItem")
                        .HasForeignKey("IdOrder")
                        .HasConstraintName("FK_OrderItem_Order");

                    b.HasOne("FoodDelivery.Models.RestaurantMenuItem", "RestaurantMenuItemNavigation")
                        .WithMany("TblOrderItem")
                        .HasForeignKey("IdRestaurantMenuItem")
                        .HasConstraintName("FK_OrderItem_RestaurantMenuItem");
                });

            modelBuilder.Entity("FoodDelivery.Models.PaymentMethod", b =>
                {
                    b.HasOne("FoodDelivery.Models.Customer", "CustomerNavigation")
                        .WithMany("TblPaymentMethod")
                        .HasForeignKey("IdCustomer")
                        .HasConstraintName("FK_PaymentMethod_Customer");
                });

            modelBuilder.Entity("FoodDelivery.Models.RestaurantMenu", b =>
                {
                    b.HasOne("FoodDelivery.Models.Restaurant", "RestaurantNavigation")
                        .WithMany("TblRestaurantMenu")
                        .HasForeignKey("IdRestaurant")
                        .HasConstraintName("FK_RestaurantMenu_Restaurant");
                });

            modelBuilder.Entity("FoodDelivery.Models.RestaurantMenuItem", b =>
                {
                    b.HasOne("FoodDelivery.Models.RestaurantMenu", "RestaurantMenuNavigation")
                        .WithMany("TblRestaurantMenuItem")
                        .HasForeignKey("IdRestaurantMenu")
                        .HasConstraintName("FK_RestaurantMenuItem_RestaurantMenu");
                });
#pragma warning restore 612, 618
        }
    }
}
