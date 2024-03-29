﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TanulmanyiRendszerDemo.DAL;

namespace TanulmanyiRendszerDemo.DAL.Migrations
{
    [DbContext(typeof(TanulmanyiRendszerDbContext))]
    partial class TanulmanyiRendszerDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.15")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TanulmanyiRendszerDemo.DAL.Entities.Kurzus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Megnevezes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OktatoNev")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SzemeszterId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SzemeszterId");

                    b.ToTable("Kurzusok");
                });

            modelBuilder.Entity("TanulmanyiRendszerDemo.DAL.Entities.Szemeszter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Kezdet")
                        .HasColumnType("datetime2");

                    b.Property<string>("Megnevezes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("TargyJelentkezesVeg")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("TargyjelentkezesKezdet")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Veg")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("VizsgajelentkezesKezdet")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("VizsgajelentkezesVeg")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Szemeszterek");
                });

            modelBuilder.Entity("TanulmanyiRendszerDemo.DAL.Entities.Kurzus", b =>
                {
                    b.HasOne("TanulmanyiRendszerDemo.DAL.Entities.Szemeszter", "Szemeszter")
                        .WithMany("Kurzusok")
                        .HasForeignKey("SzemeszterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Szemeszter");
                });

            modelBuilder.Entity("TanulmanyiRendszerDemo.DAL.Entities.Szemeszter", b =>
                {
                    b.Navigation("Kurzusok");
                });
#pragma warning restore 612, 618
        }
    }
}
