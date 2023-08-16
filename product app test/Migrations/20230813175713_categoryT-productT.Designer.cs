﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using product_app_test.Controllers;

namespace product_app_test.Migrations
{
    [DbContext(typeof(DbcontextApp))]
    [Migration("20230813175713_categoryT-productT")]
    partial class categoryTproductT
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("product_app_test.Models.Category", b =>
                {
                    b.Property<byte>("ctg_id")
                        .HasColumnType("tinyint");

                    b.Property<string>("ctg_name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("ctg_id");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("product_app_test.Models.Product", b =>
                {
                    b.Property<byte>("item_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint")
                        .UseIdentityColumn();

                    b.Property<byte?>("categoryctg_id")
                        .HasColumnType("tinyint");

                    b.Property<byte>("ctg_id")
                        .HasColumnType("tinyint");

                    b.Property<string>("item_dec")
                        .IsRequired()
                        .HasMaxLength(2500)
                        .HasColumnType("nvarchar(2500)");

                    b.Property<byte[]>("item_img")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("item_name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("price")
                        .HasColumnType("int");

                    b.HasKey("item_id");

                    b.HasIndex("categoryctg_id");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("product_app_test.Models.Product", b =>
                {
                    b.HasOne("product_app_test.Models.Category", "category")
                        .WithMany()
                        .HasForeignKey("categoryctg_id");

                    b.Navigation("category");
                });
#pragma warning restore 612, 618
        }
    }
}
