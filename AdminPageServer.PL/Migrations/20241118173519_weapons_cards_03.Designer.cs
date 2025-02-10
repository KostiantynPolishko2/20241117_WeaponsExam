﻿// <auto-generated />
using AdminPageServer.PL.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AdminPageServer.PL.Migrations
{
    [DbContext(typeof(WeaponsItemsContext))]
    [Migration("20241118173519_weapons_cards_03")]
    partial class weapons_cards_03
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AdminPageServer.PL.Entities.WeaponsImage", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<int>("idWeaponsItem")
                        .HasColumnType("int")
                        .HasColumnName("FK_IdWeaponsItem");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("path")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("idWeaponsItem")
                        .IsUnique()
                        .HasDatabaseName("IX_WeaponsImage_idWeaponsItem");

                    b.ToTable("weapons_images", (string)null);
                });

            modelBuilder.Entity("AdminPageServer.PL.Entities.WeaponsItem", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isVisible")
                        .HasColumnType("bit");

                    b.HasKey("id");

                    b.ToTable("weapons_items", (string)null);
                });

            modelBuilder.Entity("AdminPageServer.PL.Entities.WeaponsProperty", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Vendor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("idWeaponsItem")
                        .HasColumnType("int")
                        .HasColumnName("FK_IdWeaponsItem");

                    b.Property<float>("price")
                        .HasColumnType("real");

                    b.Property<float>("weight")
                        .HasColumnType("real");

                    b.HasKey("id");

                    b.HasIndex("idWeaponsItem")
                        .IsUnique()
                        .HasDatabaseName("IX_WeaponsProperty_idWeaponsItem");

                    b.ToTable("weapons_properties", (string)null);
                });

            modelBuilder.Entity("AdminPageServer.PL.Entities.WeaponsImage", b =>
                {
                    b.HasOne("AdminPageServer.PL.Entities.WeaponsItem", "weaponsItem")
                        .WithOne("weaponsImage")
                        .HasForeignKey("AdminPageServer.PL.Entities.WeaponsImage", "idWeaponsItem")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("weaponsItem");
                });

            modelBuilder.Entity("AdminPageServer.PL.Entities.WeaponsProperty", b =>
                {
                    b.HasOne("AdminPageServer.PL.Entities.WeaponsItem", "weaponsItem")
                        .WithOne("weaponsProperty")
                        .HasForeignKey("AdminPageServer.PL.Entities.WeaponsProperty", "idWeaponsItem")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("weaponsItem");
                });

            modelBuilder.Entity("AdminPageServer.PL.Entities.WeaponsItem", b =>
                {
                    b.Navigation("weaponsImage");

                    b.Navigation("weaponsProperty");
                });
#pragma warning restore 612, 618
        }
    }
}
