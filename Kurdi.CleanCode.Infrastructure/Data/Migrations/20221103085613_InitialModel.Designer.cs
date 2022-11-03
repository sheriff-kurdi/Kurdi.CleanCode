﻿// <auto-generated />
using System;
using Kurdi.CleanCode.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Kurdi.CleanCode.Infrastructure.Data.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20221103085613_InitialModel")]
    partial class InitialModel
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Kurdi.CleanCode.Core.Entities.CategoryAggregate.Category", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("name");

                    b.Property<bool>("IsParent")
                        .HasColumnType("bit")
                        .HasColumnName("is_parent");

                    b.Property<string>("ParentName")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("parent");

                    b.Property<string>("parent")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("parent1");

                    b.HasKey("Name");

                    b.HasIndex("parent");

                    b.ToTable("categories");
                });

            modelBuilder.Entity("Kurdi.CleanCode.Core.Entities.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Department")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Salary")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Kurdi.CleanCode.Core.Entities.Language", b =>
                {
                    b.Property<string>("LanguageCode")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("language_code");

                    b.Property<string>("LanguageName")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("language_name");

                    b.HasKey("LanguageCode");

                    b.ToTable("languages");
                });

            modelBuilder.Entity("Kurdi.CleanCode.Core.Entities.StockAggregate.StockItem", b =>
                {
                    b.Property<string>("Sku")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("sku");

                    b.Property<string>("CategoryName")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("category");

                    b.Property<int>("SupplierIdentity")
                        .HasColumnType("int")
                        .HasColumnName("supplier_identity");

                    b.HasKey("Sku");

                    b.HasIndex("CategoryName");

                    b.ToTable("stock_items");
                });

            modelBuilder.Entity("Kurdi.CleanCode.Core.Entities.StockAggregate.StockItemDetails", b =>
                {
                    b.Property<string>("LanguageCode")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("language_code");

                    b.Property<string>("Sku")
                        .HasColumnType("nvarchar(450)")
                        .HasColumnName("sku");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("name");

                    b.HasKey("LanguageCode", "Sku");

                    b.HasIndex("Sku");

                    b.ToTable("stock_items_details");
                });

            modelBuilder.Entity("Kurdi.CleanCode.Core.Entities.CategoryAggregate.Category", b =>
                {
                    b.HasOne("Kurdi.CleanCode.Core.Entities.CategoryAggregate.Category", "Parent")
                        .WithMany()
                        .HasForeignKey("parent");

                    b.Navigation("Parent");
                });

            modelBuilder.Entity("Kurdi.CleanCode.Core.Entities.StockAggregate.StockItem", b =>
                {
                    b.HasOne("Kurdi.CleanCode.Core.Entities.CategoryAggregate.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryName");

                    b.OwnsOne("Kurdi.CleanCode.Core.Entities.StockAggregate.StockItemPrices", "StockItemPrices", b1 =>
                        {
                            b1.Property<string>("StockItemSku")
                                .HasColumnType("nvarchar(450)");

                            b1.Property<double>("CostPrice")
                                .HasColumnType("float")
                                .HasColumnName("cost_price");

                            b1.Property<double>("Discount")
                                .HasColumnType("float")
                                .HasColumnName("discount");

                            b1.Property<bool>("IsDiscounted")
                                .HasColumnType("bit")
                                .HasColumnName("is_discounted");

                            b1.Property<double>("SellingPrice")
                                .HasColumnType("float")
                                .HasColumnName("selling_price");

                            b1.HasKey("StockItemSku");

                            b1.ToTable("stock_items");

                            b1.WithOwner()
                                .HasForeignKey("StockItemSku");
                        });

                    b.OwnsOne("Kurdi.CleanCode.Core.Entities.StockAggregate.StockItemQuantity", "StockItemQuantity", b1 =>
                        {
                            b1.Property<string>("StockItemSku")
                                .HasColumnType("nvarchar(450)");

                            b1.Property<int>("AvailableStock")
                                .HasColumnType("int")
                                .HasColumnName("available_stock");

                            b1.Property<int>("ReservedStock")
                                .HasColumnType("int")
                                .HasColumnName("reserved_stock");

                            b1.Property<int>("TotalStock")
                                .HasColumnType("int")
                                .HasColumnName("total_stock");

                            b1.HasKey("StockItemSku");

                            b1.ToTable("stock_items");

                            b1.WithOwner()
                                .HasForeignKey("StockItemSku");
                        });

                    b.Navigation("Category");

                    b.Navigation("StockItemPrices");

                    b.Navigation("StockItemQuantity");
                });

            modelBuilder.Entity("Kurdi.CleanCode.Core.Entities.StockAggregate.StockItemDetails", b =>
                {
                    b.HasOne("Kurdi.CleanCode.Core.Entities.Language", "Language")
                        .WithMany()
                        .HasForeignKey("LanguageCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Kurdi.CleanCode.Core.Entities.StockAggregate.StockItem", "StockItem")
                        .WithMany("StockItemDetails")
                        .HasForeignKey("Sku")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Language");

                    b.Navigation("StockItem");
                });

            modelBuilder.Entity("Kurdi.CleanCode.Core.Entities.StockAggregate.StockItem", b =>
                {
                    b.Navigation("StockItemDetails");
                });
#pragma warning restore 612, 618
        }
    }
}