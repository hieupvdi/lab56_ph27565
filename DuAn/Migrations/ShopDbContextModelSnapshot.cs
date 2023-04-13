﻿// <auto-generated />
using System;
using DuAn.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DuAn.Migrations
{
    [DbContext(typeof(ShopDbContext))]
    partial class ShopDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("DuAn.Models.Bill", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("HoaDon", (string)null);
                });

            modelBuilder.Entity("DuAn.Models.BillDetails", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdHD")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdSP")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdHD");

                    b.HasIndex("IdSP");

                    b.ToTable("HoaDonCT", (string)null);
                });

            modelBuilder.Entity("DuAn.Models.Cart", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("UserId");

                    b.ToTable("GioHang", (string)null);
                });

            modelBuilder.Entity("DuAn.Models.CartDetails", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdSP")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("IdSP");

                    b.HasIndex("UserId");

                    b.ToTable("GioHangCT", (string)null);
                });

            modelBuilder.Entity("DuAn.Models.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Categorys");
                });

            modelBuilder.Entity("DuAn.Models.Color", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Colors");
                });

            modelBuilder.Entity("DuAn.Models.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AvailableQuantity")
                        .HasColumnType("int");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ColorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LinkAnh")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<Guid>("SizeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Supplier")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(true)
                        .HasColumnType("nchar(100)")
                        .IsFixedLength();

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ColorId");

                    b.HasIndex("SizeId");

                    b.ToTable("SanPham", (string)null);
                });

            modelBuilder.Entity("DuAn.Models.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(1000)");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("ChucVu", (string)null);
                });

            modelBuilder.Entity("DuAn.Models.Size", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Kichthuoc")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Sizes");
                });

            modelBuilder.Entity("DuAn.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Gmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LinkAnh")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("varchar(256)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("varchar(256)");

                    b.HasKey("Id");

                    b.HasAlternateKey("Username");

                    b.HasIndex("RoleId");

                    b.ToTable("NguoiDung", (string)null);
                });

            modelBuilder.Entity("DuAn.Models.Bill", b =>
                {
                    b.HasOne("DuAn.Models.User", "User")
                        .WithMany("Bill")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("DuAn.Models.BillDetails", b =>
                {
                    b.HasOne("DuAn.Models.Bill", "Bill")
                        .WithMany("BillDetails")
                        .HasForeignKey("IdHD")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DuAn.Models.Product", "Product")
                        .WithMany("BillDetails")
                        .HasForeignKey("IdSP")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bill");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("DuAn.Models.Cart", b =>
                {
                    b.HasOne("DuAn.Models.User", "User")
                        .WithOne("Cart")
                        .HasForeignKey("DuAn.Models.Cart", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("DuAn.Models.CartDetails", b =>
                {
                    b.HasOne("DuAn.Models.Product", "Product")
                        .WithMany("CartDetails")
                        .HasForeignKey("IdSP")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DuAn.Models.Cart", "Cart")
                        .WithMany("CartDetails")
                        .HasForeignKey("UserId");

                    b.Navigation("Cart");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("DuAn.Models.Product", b =>
                {
                    b.HasOne("DuAn.Models.Category", "Category")
                        .WithMany("Product")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DuAn.Models.Color", "Color")
                        .WithMany("Product")
                        .HasForeignKey("ColorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DuAn.Models.Size", "Size")
                        .WithMany("Product")
                        .HasForeignKey("SizeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Color");

                    b.Navigation("Size");
                });

            modelBuilder.Entity("DuAn.Models.User", b =>
                {
                    b.HasOne("DuAn.Models.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("DuAn.Models.Bill", b =>
                {
                    b.Navigation("BillDetails");
                });

            modelBuilder.Entity("DuAn.Models.Cart", b =>
                {
                    b.Navigation("CartDetails");
                });

            modelBuilder.Entity("DuAn.Models.Category", b =>
                {
                    b.Navigation("Product");
                });

            modelBuilder.Entity("DuAn.Models.Color", b =>
                {
                    b.Navigation("Product");
                });

            modelBuilder.Entity("DuAn.Models.Product", b =>
                {
                    b.Navigation("BillDetails");

                    b.Navigation("CartDetails");
                });

            modelBuilder.Entity("DuAn.Models.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("DuAn.Models.Size", b =>
                {
                    b.Navigation("Product");
                });

            modelBuilder.Entity("DuAn.Models.User", b =>
                {
                    b.Navigation("Bill");

                    b.Navigation("Cart")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
