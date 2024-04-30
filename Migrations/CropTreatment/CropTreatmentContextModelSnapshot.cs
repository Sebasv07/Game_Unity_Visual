﻿// <auto-generated />
using System;
using Game_Unity.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Game_Unity.Migrations.CropTreatment
{
    [DbContext(typeof(CropTreatmentContext))]
    partial class CropTreatmentContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Game_Unity.Models.CropTreatmentModel", b =>
                {
                    b.Property<int>("CropTreatmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CropTreatmentId"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("ApplicationMethod")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CropId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DateTreatment")
                        .HasColumnType("datetime2");

                    b.Property<int?>("FertilizerId")
                        .HasColumnType("int");

                    b.Property<string>("Observations")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductUsed")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("QuantityUsed")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("TypeTreatment")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CropTreatmentId");

                    b.ToTable("CropTreatments");
                });
#pragma warning restore 612, 618
        }
    }
}
