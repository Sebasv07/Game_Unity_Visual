﻿// <auto-generated />
using System;
using Game_Unity.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Game_Unity.Migrations.MaturationMonitoring
{
    [DbContext(typeof(MaturationMonitoringContext))]
    [Migration("20240416164532_Inicial1.")]
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

            modelBuilder.Entity("Game_Unity.Models.MaturationMonitoringModel", b =>
                {
                    b.Property<int>("MaturationMonitoringId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MaturationMonitoringId"));

                    b.Property<int?>("CropId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("EstimatedPlanningDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("EstimatedRipeningDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("MaturationState")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Observations")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MaturationMonitoringId");

                    b.ToTable("MaturationMonitorings");
                });
#pragma warning restore 612, 618
        }
    }
}
