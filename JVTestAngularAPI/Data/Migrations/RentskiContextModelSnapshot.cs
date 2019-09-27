﻿// <auto-generated />
using System;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Data.Migrations
{
    [DbContext(typeof(RentskiContext))]
    partial class RentskiContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Data.Models.RentModel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CustomerName")
                        .IsRequired();

                    b.Property<decimal>("HourlyRate");

                    b.Property<DateTime>("RentedAt");

                    b.Property<DateTime?>("ReturnedAt");

                    b.Property<long>("SkiId");

                    b.HasKey("Id");

                    b.HasIndex("SkiId");

                    b.ToTable("Rents");
                });

            modelBuilder.Entity("Data.Models.SkiModel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("HourlyRate");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<bool>("Rented");

                    b.HasKey("Id");

                    b.ToTable("Skis");
                });

            modelBuilder.Entity("Data.Models.RentModel", b =>
                {
                    b.HasOne("Data.Models.SkiModel", "Ski")
                        .WithMany()
                        .HasForeignKey("SkiId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
