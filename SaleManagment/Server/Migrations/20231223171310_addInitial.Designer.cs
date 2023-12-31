﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SaleManagment.Server.Data;

#nullable disable

namespace SaleManagment.Server.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20231223171310_addInitial")]
    partial class addInitial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SaleManagment.Shared.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "New York Building 1",
                            State = "NY"
                        },
                        new
                        {
                            Id = 2,
                            Name = "California Hotel AJK",
                            State = "CA"
                        });
                });

            modelBuilder.Entity("SaleManagment.Shared.SubElement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Element")
                        .HasColumnType("int");

                    b.Property<int>("Height")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Width")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("SubElements");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Element = 1,
                            Height = 2200,
                            Type = "Door",
                            Width = 1400
                        },
                        new
                        {
                            Id = 2,
                            Element = 1,
                            Height = 2200,
                            Type = "windo",
                            Width = 1400
                        });
                });

            modelBuilder.Entity("SaleManagment.Shared.Window", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("QuantityOfWindows")
                        .HasColumnType("int");

                    b.Property<int>("TotalSubElements")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Windows");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "GLB",
                            QuantityOfWindows = 3,
                            TotalSubElements = 2
                        },
                        new
                        {
                            Id = 2,
                            Name = "C Zone 5",
                            QuantityOfWindows = 2,
                            TotalSubElements = 1
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
