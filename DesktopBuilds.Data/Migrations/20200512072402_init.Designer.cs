﻿// <auto-generated />
using System;
using DesktopBuilds.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DesktopBuilds.Data.Migrations
{
    [DbContext(typeof(DesktopBuildsContext))]
    [Migration("20200512072402_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DesktopBuilds.Domain.CPU", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Cache")
                        .HasColumnType("int");

                    b.Property<float>("DefaultFrequency")
                        .HasColumnType("real");

                    b.Property<string>("Manufacturer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("MaxFrequency")
                        .HasColumnType("real");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CPUs");
                });

            modelBuilder.Entity("DesktopBuilds.Domain.Desktop", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CPUId")
                        .HasColumnType("int");

                    b.Property<int?>("GraphicCardId")
                        .HasColumnType("int");

                    b.Property<int?>("MotherboardId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RamId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CPUId");

                    b.HasIndex("GraphicCardId");

                    b.HasIndex("MotherboardId");

                    b.HasIndex("RamId");

                    b.ToTable("Desktops");
                });

            modelBuilder.Entity("DesktopBuilds.Domain.GraphicCard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Frequency")
                        .HasColumnType("int");

                    b.Property<string>("Manufacturer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Memory")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("GraphicCards");
                });

            modelBuilder.Entity("DesktopBuilds.Domain.Motherboard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Manufacturer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PCICount")
                        .HasColumnType("int");

                    b.Property<int>("PCIEx16Count")
                        .HasColumnType("int");

                    b.Property<int>("PCIExCount")
                        .HasColumnType("int");

                    b.Property<string>("Socket")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Motherboards");
                });

            modelBuilder.Entity("DesktopBuilds.Domain.Ram", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<int>("Frequency")
                        .HasColumnType("int");

                    b.Property<string>("Generation")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Manufacturer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Rams");
                });

            modelBuilder.Entity("DesktopBuilds.Domain.Desktop", b =>
                {
                    b.HasOne("DesktopBuilds.Domain.CPU", "CPU")
                        .WithMany()
                        .HasForeignKey("CPUId");

                    b.HasOne("DesktopBuilds.Domain.GraphicCard", "GraphicCard")
                        .WithMany()
                        .HasForeignKey("GraphicCardId");

                    b.HasOne("DesktopBuilds.Domain.Motherboard", "Motherboard")
                        .WithMany()
                        .HasForeignKey("MotherboardId");

                    b.HasOne("DesktopBuilds.Domain.Ram", "Ram")
                        .WithMany()
                        .HasForeignKey("RamId");
                });
#pragma warning restore 612, 618
        }
    }
}
