﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using rest_api.Models;

namespace REST.Migrations
{
    [DbContext(typeof(ProductContext))]
    [Migration("20220225211337_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.14")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("rest_api.Models.Product", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Manufacturer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ID = 123456,
                            Manufacturer = "company1",
                            Price = 50.350000000000001,
                            Stock = 10,
                            Type = "keyboard"
                        },
                        new
                        {
                            ID = 444444,
                            Manufacturer = "company2",
                            Price = 39.0,
                            Stock = 0,
                            Type = "keyboard"
                        },
                        new
                        {
                            ID = 344324,
                            Manufacturer = "company1",
                            Price = 15.949999999999999,
                            Stock = 2,
                            Type = "mouse"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
