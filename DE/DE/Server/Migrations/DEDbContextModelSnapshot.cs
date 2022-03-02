﻿// <auto-generated />
using System;
using DE.Server.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DE.Server.Migrations
{
    [DbContext(typeof(DEDbContext))]
    partial class DEDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("DE.Server.DataModels.AssetDataModel", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("AssetClass")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("AssetDateOfService")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("AssetGroup")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("AssetHeight")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("AssetId")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("AssetIdCode")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("AssetLength")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("AssetNameArabic")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("AssetNameEnglish")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("AssetSizeUnit")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("AssetStatus")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("AssetType")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("AssetWidth")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("PicureId")
                        .HasColumnType("varchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("PicureId");

                    b.ToTable("Assets");
                });

            modelBuilder.Entity("DE.Server.DataModels.StoredFileDataModel", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("varchar(255)");

                    b.Property<string>("AssetDataModelId")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("FileExtention")
                        .HasColumnType("longtext");

                    b.Property<string>("FileName")
                        .HasColumnType("longtext");

                    b.Property<string>("Path")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("AssetDataModelId");

                    b.ToTable("StoredFiles");
                });

            modelBuilder.Entity("DE.Server.DataModels.AssetDataModel", b =>
                {
                    b.HasOne("DE.Server.DataModels.StoredFileDataModel", "Picure")
                        .WithMany()
                        .HasForeignKey("PicureId");

                    b.Navigation("Picure");
                });

            modelBuilder.Entity("DE.Server.DataModels.StoredFileDataModel", b =>
                {
                    b.HasOne("DE.Server.DataModels.AssetDataModel", null)
                        .WithMany("Decuments")
                        .HasForeignKey("AssetDataModelId");
                });

            modelBuilder.Entity("DE.Server.DataModels.AssetDataModel", b =>
                {
                    b.Navigation("Decuments");
                });
#pragma warning restore 612, 618
        }
    }
}