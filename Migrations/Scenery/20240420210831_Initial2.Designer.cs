﻿// <auto-generated />
using System;
using Game_Unity.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Game_Unity.Migrations.Scenery
{
    [DbContext(typeof(SceneryContext))]
    [Migration("20240420210831_Initial2")]
    partial class Initial2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Game_Unity.Models.SceneryModel", b =>
                {
                    b.Property<int>("SceneryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SceneryId"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DescriptionScenery")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DifficultyLevel")
                        .HasColumnType("int");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameScenery")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SceneryId");

                    b.ToTable("Sceneries");
                });
#pragma warning restore 612, 618
        }
    }
}
