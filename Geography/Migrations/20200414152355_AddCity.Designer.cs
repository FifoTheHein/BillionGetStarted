﻿// <auto-generated />
using System;
using Geography;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Geography.Migrations
{
    [DbContext(typeof(GeographyContext))]
    [Migration("20200414152355_AddCity")]
    partial class AddCity
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Geography.City", b =>
                {
                    b.Property<Guid>("CityID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ASCIITitle")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("AlternateTitles")
                        .HasColumnType("nvarchar(max)")
                        .HasMaxLength(10000);

                    b.Property<string>("CountryCode")
                        .HasColumnType("nvarchar(2)")
                        .HasMaxLength(2);

                    b.Property<double>("Latitude")
                        .HasColumnType("float");

                    b.Property<double>("Longitude")
                        .HasColumnType("float");

                    b.Property<string>("Timezone")
                        .HasColumnType("nvarchar(40)")
                        .HasMaxLength(40);

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<int>("geonameid")
                        .HasColumnType("int");

                    b.HasKey("CityID");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("Geography.Country", b =>
                {
                    b.Property<string>("ISO")
                        .HasColumnType("nvarchar(2)")
                        .HasMaxLength(2);

                    b.Property<string>("Capital")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<string>("Continent")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("CurrencyCode")
                        .HasColumnType("nvarchar(3)")
                        .HasMaxLength(3);

                    b.Property<string>("CurrencyName")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("FIPS")
                        .HasColumnType("nvarchar(2)")
                        .HasMaxLength(2);

                    b.Property<string>("ISO3")
                        .HasColumnType("nvarchar(3)")
                        .HasMaxLength(3);

                    b.Property<string>("Languages")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("PhonePrefix")
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<int>("geonameid")
                        .HasColumnType("int");

                    b.HasKey("ISO");

                    b.ToTable("Countries");
                });
#pragma warning restore 612, 618
        }
    }
}
