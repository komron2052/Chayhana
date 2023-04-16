﻿// <auto-generated />
using System;
using Chayhana.Data.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Chayhana.Data.Migrations
{
    [DbContext(typeof(ChayhanaDbContext))]
    [Migration("20230416191700_SecondMigration")]
    partial class SecondMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Chayhana.Domain.Entities.Meal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<double>("ToTalRemainingAmount")
                        .HasColumnType("float");

                    b.Property<double>("TotalAmount")
                        .HasColumnType("float");

                    b.Property<decimal>("TotalMoneyOfSoldMeal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<double>("TotalSoldAmount")
                        .HasColumnType("float");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Meals");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2023, 4, 16, 19, 16, 59, 855, DateTimeKind.Utc).AddTicks(2086),
                            Description = "Choyxona",
                            Name = "Osh",
                            Price = 35000m,
                            ToTalRemainingAmount = 25.0,
                            TotalAmount = 25.0,
                            TotalMoneyOfSoldMeal = 0m,
                            TotalSoldAmount = 0.0,
                            Type = 0
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2023, 4, 16, 19, 16, 59, 855, DateTimeKind.Utc).AddTicks(2096),
                            Description = "Suyuq",
                            Name = "Lagmon",
                            Price = 20000m,
                            ToTalRemainingAmount = 35.0,
                            TotalAmount = 35.0,
                            TotalMoneyOfSoldMeal = 0m,
                            TotalSoldAmount = 0.0,
                            Type = 0
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(2023, 4, 16, 19, 16, 59, 855, DateTimeKind.Utc).AddTicks(2100),
                            Description = "Achchiq",
                            Name = "Kimchi",
                            Price = 22000m,
                            ToTalRemainingAmount = 22.0,
                            TotalAmount = 22.0,
                            TotalMoneyOfSoldMeal = 0m,
                            TotalSoldAmount = 0.0,
                            Type = 0
                        },
                        new
                        {
                            Id = 4,
                            CreatedAt = new DateTime(2023, 4, 16, 19, 16, 59, 855, DateTimeKind.Utc).AddTicks(2103),
                            Description = "Gijduvon",
                            Name = "Kabob",
                            Price = 20000m,
                            ToTalRemainingAmount = 20.0,
                            TotalAmount = 20.0,
                            TotalMoneyOfSoldMeal = 0m,
                            TotalSoldAmount = 0.0,
                            Type = 0
                        },
                        new
                        {
                            Id = 5,
                            CreatedAt = new DateTime(2023, 4, 16, 19, 16, 59, 855, DateTimeKind.Utc).AddTicks(2108),
                            Description = "Tovuqli",
                            Name = "Shurva",
                            Price = 18000m,
                            ToTalRemainingAmount = 40.0,
                            TotalAmount = 40.0,
                            TotalMoneyOfSoldMeal = 0m,
                            TotalSoldAmount = 0.0,
                            Type = 0
                        });
                });

            modelBuilder.Entity("Chayhana.Domain.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("MealId")
                        .HasColumnType("int");

                    b.Property<decimal>("Money")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<bool>("isPaid")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("MealId");

                    b.ToTable("Oreders");
                });

            modelBuilder.Entity("Chayhana.Domain.Entities.Order", b =>
                {
                    b.HasOne("Chayhana.Domain.Entities.Meal", "Meal")
                        .WithMany("Oredrs")
                        .HasForeignKey("MealId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Meal");
                });

            modelBuilder.Entity("Chayhana.Domain.Entities.Meal", b =>
                {
                    b.Navigation("Oredrs");
                });
#pragma warning restore 612, 618
        }
    }
}
