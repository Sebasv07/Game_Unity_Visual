﻿// <auto-generated />
using System;
using Game_Unity.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Game_Unity.Migrations.Detective
{
    [DbContext(typeof(DetectiveContext))]
    partial class DetectiveContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Game_Unity.Models.DetectiveModel", b =>
                {
                    b.Property<int>("DetectiveId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DetectiveId"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("DateCreation")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NameDetective")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Skills")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DetectiveId");

                    b.ToTable("Detectives");
                });
#pragma warning restore 612, 618
        }
    }
}
