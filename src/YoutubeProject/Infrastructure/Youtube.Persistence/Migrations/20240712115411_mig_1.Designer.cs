﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Youtube.Persistence.Context;

#nullable disable

namespace Youtube.Persistence.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240712115411_mig_1")]
    partial class mig_1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Youtube.Domain.Entities.Brand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Brands");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2024, 7, 12, 11, 54, 11, 687, DateTimeKind.Utc).AddTicks(8950),
                            IsDeleted = false,
                            Name = "Jewelery & Automotive"
                        },
                        new
                        {
                            Id = 2,
                            CreatedDate = new DateTime(2024, 7, 12, 11, 54, 11, 687, DateTimeKind.Utc).AddTicks(8960),
                            IsDeleted = false,
                            Name = "Sports, Books & Clothing"
                        },
                        new
                        {
                            Id = 3,
                            CreatedDate = new DateTime(2024, 7, 12, 11, 54, 11, 687, DateTimeKind.Utc).AddTicks(8970),
                            IsDeleted = false,
                            Name = "Outdoors, Outdoors & Garden"
                        },
                        new
                        {
                            Id = 4,
                            CreatedDate = new DateTime(2024, 7, 12, 11, 54, 11, 687, DateTimeKind.Utc).AddTicks(8980),
                            IsDeleted = true,
                            Name = "Toys, Garden & Sports"
                        });
                });

            modelBuilder.Entity("Youtube.Domain.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("ParentId")
                        .HasColumnType("integer");

                    b.Property<int>("Priorty")
                        .HasColumnType("integer");

                    b.Property<int?>("ProductId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedDate = new DateTime(2024, 7, 12, 11, 54, 11, 687, DateTimeKind.Utc).AddTicks(9750),
                            IsDeleted = false,
                            Name = "Elektrik",
                            ParentId = 0,
                            Priorty = 1
                        },
                        new
                        {
                            Id = 2,
                            CreatedDate = new DateTime(2024, 7, 12, 11, 54, 11, 687, DateTimeKind.Utc).AddTicks(9750),
                            IsDeleted = false,
                            Name = "Moda",
                            ParentId = 0,
                            Priorty = 1
                        },
                        new
                        {
                            Id = 3,
                            CreatedDate = new DateTime(2024, 7, 12, 11, 54, 11, 687, DateTimeKind.Utc).AddTicks(9750),
                            IsDeleted = false,
                            Name = "bilgisayar",
                            ParentId = 1,
                            Priorty = 1
                        },
                        new
                        {
                            Id = 4,
                            CreatedDate = new DateTime(2024, 7, 12, 11, 54, 11, 687, DateTimeKind.Utc).AddTicks(9750),
                            IsDeleted = false,
                            Name = "Kadın",
                            ParentId = 2,
                            Priorty = 1
                        });
                });

            modelBuilder.Entity("Youtube.Domain.Entities.Detail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Details");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            CreatedDate = new DateTime(2024, 7, 12, 11, 54, 11, 688, DateTimeKind.Utc).AddTicks(8460),
                            Description = "Patlıcan ratione amet qui sit.",
                            IsDeleted = false,
                            Title = "Ad mi sed."
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 3,
                            CreatedDate = new DateTime(2024, 7, 12, 11, 54, 11, 688, DateTimeKind.Utc).AddTicks(8480),
                            Description = "Voluptatem dışarı totam sinema ve.",
                            IsDeleted = true,
                            Title = "Inventore ut nihil."
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 4,
                            CreatedDate = new DateTime(2024, 7, 12, 11, 54, 11, 688, DateTimeKind.Utc).AddTicks(8500),
                            Description = "Vitae qui masaya oldular gördüm.",
                            IsDeleted = false,
                            Title = "Nemo sıfat."
                        });
                });

            modelBuilder.Entity("Youtube.Domain.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("BrandId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Discount")
                        .HasColumnType("numeric");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 2,
                            BrandId = 3,
                            CreatedDate = new DateTime(2024, 7, 12, 11, 54, 11, 689, DateTimeKind.Utc).AddTicks(7240),
                            Description = "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive",
                            Discount = 8.411105565730940m,
                            IsDeleted = false,
                            Price = 206.69m,
                            Title = "Generic Cotton Chips"
                        },
                        new
                        {
                            Id = 1,
                            BrandId = 1,
                            CreatedDate = new DateTime(2024, 7, 12, 11, 54, 11, 689, DateTimeKind.Utc).AddTicks(7230),
                            Description = "New ABC 13 9370, 13.3, 5th Gen CoreA5-8250U, 8GB RAM, 256GB SSD, power UHD Graphics, OS 10 Home, OS Office A & J 2016",
                            Discount = 1.206887494225560m,
                            IsDeleted = false,
                            Price = 482.22m,
                            Title = "Ergonomic Soft Gloves"
                        });
                });

            modelBuilder.Entity("Youtube.Domain.Entities.Category", b =>
                {
                    b.HasOne("Youtube.Domain.Entities.Product", null)
                        .WithMany("MyProperty")
                        .HasForeignKey("ProductId");
                });

            modelBuilder.Entity("Youtube.Domain.Entities.Detail", b =>
                {
                    b.HasOne("Youtube.Domain.Entities.Category", "Category")
                        .WithMany("Details")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Youtube.Domain.Entities.Product", b =>
                {
                    b.HasOne("Youtube.Domain.Entities.Brand", "Brand")
                        .WithMany()
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");
                });

            modelBuilder.Entity("Youtube.Domain.Entities.Category", b =>
                {
                    b.Navigation("Details");
                });

            modelBuilder.Entity("Youtube.Domain.Entities.Product", b =>
                {
                    b.Navigation("MyProperty");
                });
#pragma warning restore 612, 618
        }
    }
}
