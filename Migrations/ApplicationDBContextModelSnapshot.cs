﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using buy_and_sell_dotNetAPI.Data;

namespace buy_and_sell_dotNetAPI.Migrations
{
    [DbContext(typeof(ApplicationDBContext))]
    partial class ApplicationDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("buy_and_sell_dotNetAPI.Models.Listing", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("varchar(1000)")
                        .HasMaxLength(1000);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(45)")
                        .HasMaxLength(45);

                    b.Property<float>("Price")
                        .HasColumnType("float");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("varchar(36)")
                        .HasMaxLength(36);

                    b.Property<int>("Views")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Listings");
                });
#pragma warning restore 612, 618
        }
    }
}
