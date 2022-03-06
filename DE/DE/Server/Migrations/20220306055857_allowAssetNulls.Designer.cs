﻿// <auto-generated />
using System;
using DE.Server.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DE.Server.Migrations
{
    [DbContext(typeof(DEDbContext))]
    [Migration("20220306055857_allowAssetNulls")]
    partial class allowAssetNulls
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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
                        .HasColumnType("longtext");

                    b.Property<DateTime?>("AssetDateOfService")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("AssetGroup")
                        .HasColumnType("longtext");

                    b.Property<string>("AssetHeight")
                        .HasColumnType("longtext");

                    b.Property<string>("AssetId")
                        .HasColumnType("longtext");

                    b.Property<string>("AssetIdCode")
                        .HasColumnType("longtext");

                    b.Property<string>("AssetLength")
                        .HasColumnType("longtext");

                    b.Property<string>("AssetNameArabic")
                        .HasColumnType("longtext");

                    b.Property<string>("AssetNameEnglish")
                        .HasColumnType("longtext");

                    b.Property<string>("AssetSizeUnit")
                        .HasColumnType("longtext");

                    b.Property<string>("AssetStatus")
                        .HasColumnType("longtext");

                    b.Property<string>("AssetType")
                        .HasColumnType("longtext");

                    b.Property<string>("AssetWidth")
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
