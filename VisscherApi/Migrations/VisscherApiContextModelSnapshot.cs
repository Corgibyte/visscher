﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VisscherApi.Models;

#nullable disable

namespace VisscherApi.Migrations
{
    [DbContext(typeof(VisscherApiContext))]
    partial class VisscherApiContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("VisscherApi.Models.Battle", b =>
                {
                    b.Property<int>("BattleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("longtext");

                    b.Property<int>("Latitude")
                        .HasColumnType("int");

                    b.Property<int>("Longitude")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<string>("Url")
                        .HasColumnType("longtext");

                    b.HasKey("BattleId");

                    b.ToTable("Battles");
                });

            modelBuilder.Entity("VisscherApi.Models.BattleBelligerent", b =>
                {
                    b.Property<int>("BattleBelligerentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("BattleId")
                        .HasColumnType("int");

                    b.Property<int>("BelligerentId")
                        .HasColumnType("int");

                    b.HasKey("BattleBelligerentId");

                    b.HasIndex("BattleId");

                    b.HasIndex("BelligerentId");

                    b.ToTable("BattleBelligerents");
                });

            modelBuilder.Entity("VisscherApi.Models.Belligerent", b =>
                {
                    b.Property<int>("BelligerentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext");

                    b.Property<string>("Url")
                        .HasColumnType("longtext");

                    b.HasKey("BelligerentId");

                    b.ToTable("Belligerents");
                });

            modelBuilder.Entity("VisscherApi.Models.BattleBelligerent", b =>
                {
                    b.HasOne("VisscherApi.Models.Battle", "Battle")
                        .WithMany("BattleBelligerents")
                        .HasForeignKey("BattleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VisscherApi.Models.Belligerent", "Belligerent")
                        .WithMany("BattleBelligerents")
                        .HasForeignKey("BelligerentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Battle");

                    b.Navigation("Belligerent");
                });

            modelBuilder.Entity("VisscherApi.Models.Battle", b =>
                {
                    b.Navigation("BattleBelligerents");
                });

            modelBuilder.Entity("VisscherApi.Models.Belligerent", b =>
                {
                    b.Navigation("BattleBelligerents");
                });
#pragma warning restore 612, 618
        }
    }
}
