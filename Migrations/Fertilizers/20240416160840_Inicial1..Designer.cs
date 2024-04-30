﻿// <auto-generated />
using Game_Unity.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Game_Unity.Migrations.Fertilizers
{
    [DbContext(typeof(FertilizersContext))]
    [Migration("20240416160840_Inicial1.")]
    partial class Inicial1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Game_Unity.Models.FertilizersModel", b =>
                {
                    b.Property<int>("FertilizerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FertilizerId"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameFertilizert")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FertilizerId");

                    b.ToTable("Fertilizers");
                });
#pragma warning restore 612, 618
        }
    }
}