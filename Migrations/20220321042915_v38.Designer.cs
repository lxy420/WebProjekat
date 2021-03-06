// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Models;

#nullable disable

namespace web_projekat.Migrations
{
    [DbContext(typeof(RezervacijaKarataContext))]
    [Migration("20220321042915_v38")]
    partial class v38
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Models.Grad", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Ime")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Grad");
                });

            modelBuilder.Entity("Models.Izvodjac", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Ime")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Instrument")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Prezime")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Izvodjac");
                });

            modelBuilder.Entity("Models.Koncert", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Ime")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("IzvodjacId")
                        .HasColumnType("int");

                    b.Property<int>("SalaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IzvodjacId");

                    b.HasIndex("SalaId");

                    b.ToTable("Koncert");
                });

            modelBuilder.Entity("Models.Rezervacija", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("KoncertId")
                        .HasColumnType("int");

                    b.Property<int>("Sediste")
                        .HasColumnType("int");

                    b.Property<string>("Telefon")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("KoncertId");

                    b.ToTable("Rezervacija");
                });

            modelBuilder.Entity("Models.Sala", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("GradId")
                        .HasColumnType("int");

                    b.Property<string>("Ime")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("Kapacitet")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GradId");

                    b.ToTable("Sala");
                });

            modelBuilder.Entity("Models.Koncert", b =>
                {
                    b.HasOne("Models.Izvodjac", "Izvodjac")
                        .WithMany()
                        .HasForeignKey("IzvodjacId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Models.Sala", "Sala")
                        .WithMany("Koncert")
                        .HasForeignKey("SalaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Izvodjac");

                    b.Navigation("Sala");
                });

            modelBuilder.Entity("Models.Rezervacija", b =>
                {
                    b.HasOne("Models.Koncert", "Koncert")
                        .WithMany()
                        .HasForeignKey("KoncertId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Koncert");
                });

            modelBuilder.Entity("Models.Sala", b =>
                {
                    b.HasOne("Models.Grad", "Grad")
                        .WithMany("Sala")
                        .HasForeignKey("GradId");

                    b.Navigation("Grad");
                });

            modelBuilder.Entity("Models.Grad", b =>
                {
                    b.Navigation("Sala");
                });

            modelBuilder.Entity("Models.Sala", b =>
                {
                    b.Navigation("Koncert");
                });
#pragma warning restore 612, 618
        }
    }
}
