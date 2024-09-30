﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using bruhBruh.Models;

#nullable disable

namespace bruhBruh.Migrations
{
    [DbContext(typeof(FruitContext))]
    partial class FruitContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.33")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("bruhBruh.Models.Fruits", b =>
                {
                    b.Property<string>("Color")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Size")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Value")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("Color");

                    b.ToTable("newFruit");

                    b.HasData(
                        new
                        {
                            Color = "Red",
                            Name = "Apple",
                            Size = "Small",
                            Value = 2
                        },
                        new
                        {
                            Color = "Yellow",
                            Name = "Banana",
                            Size = "Long",
                            Value = 3
                        },
                        new
                        {
                            Color = "Greenish",
                            Name = "Mango",
                            Size = "Medium",
                            Value = 2
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
