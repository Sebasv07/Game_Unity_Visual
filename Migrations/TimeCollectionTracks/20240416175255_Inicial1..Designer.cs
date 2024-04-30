﻿// <auto-generated />
using System;
using Game_Unity.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Game_Unity.Migrations.TimeCollectionTracks
{
    [DbContext(typeof(TimeCollectionTracksContext))]
    [Migration("20240416175255_Inicial1.")]
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

            modelBuilder.Entity("Game_Unity.Models.TimeCollectionTracksModel", b =>
                {
                    b.Property<int>("TimeCollectionTracksId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TimeCollectionTracksId"));

                    b.Property<int>("DetectiveCluesId")
                        .HasColumnType("int");

                    b.Property<int>("DetectiveId")
                        .HasColumnType("int");

                    b.Property<int>("GameId")
                        .HasColumnType("int");

                    b.Property<TimeSpan?>("TimeClues")
                        .HasColumnType("time");

                    b.HasKey("TimeCollectionTracksId");

                    b.ToTable("TimeCollectionTracks");
                });
#pragma warning restore 612, 618
        }
    }
}
