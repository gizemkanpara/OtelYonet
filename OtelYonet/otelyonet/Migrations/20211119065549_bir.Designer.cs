﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using otelyonet.Data;

namespace otelyonet.Migrations
{
    [DbContext(typeof(OtelYonetDBContext))]
    [Migration("20211119065549_bir")]
    partial class bir
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("otelyonet.Models.Birim", b =>
                {
                    b.Property<int>("BirimID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BirimAdı")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("BirimID");

                    b.ToTable("Birimler");
                });

            modelBuilder.Entity("otelyonet.Models.Cinsiyet", b =>
                {
                    b.Property<int>("CinsiyetID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CinsiyetTuru")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.HasKey("CinsiyetID");

                    b.ToTable("Cinsiyetler");
                });

            modelBuilder.Entity("otelyonet.Models.Kullanıcı", b =>
                {
                    b.Property<int>("KullanıcıID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EPosta")
                        .IsRequired()
                        .HasMaxLength(52)
                        .HasColumnType("nvarchar(52)");

                    b.Property<int>("RolID")
                        .HasColumnType("int");

                    b.Property<string>("Sifre")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.HasKey("KullanıcıID");

                    b.HasIndex("RolID");

                    b.ToTable("Kullanıcılar");
                });

            modelBuilder.Entity("otelyonet.Models.Musteri", b =>
                {
                    b.Property<int>("MusteriID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CinsiyetID")
                        .HasColumnType("int");

                    b.Property<string>("MusteriAdi")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("MusteriAdresi")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("MusteriSoyadi")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("MusteriTC")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("nvarchar(11)");

                    b.Property<string>("MusteriTel")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<int>("MusteriTipID")
                        .HasColumnType("int");

                    b.HasKey("MusteriID");

                    b.HasIndex("CinsiyetID");

                    b.HasIndex("MusteriTipID");

                    b.ToTable("Musteriler");
                });

            modelBuilder.Entity("otelyonet.Models.MusteriTip", b =>
                {
                    b.Property<int>("MusteriTipID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("MusteriTipleri")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.HasKey("MusteriTipID");

                    b.ToTable("MusteriTipleri");
                });

            modelBuilder.Entity("otelyonet.Models.Oda", b =>
                {
                    b.Property<int>("OdaID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("KatNO")
                        .HasColumnType("int");

                    b.Property<string>("OdaAdı")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("YatakSayısı")
                        .HasColumnType("int");

                    b.HasKey("OdaID");

                    b.ToTable("Odalar");
                });

            modelBuilder.Entity("otelyonet.Models.Rol", b =>
                {
                    b.Property<int>("RolID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("RolAdı")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("RolID");

                    b.ToTable("Roller");
                });

            modelBuilder.Entity("otelyonet.Models.Kullanıcı", b =>
                {
                    b.HasOne("otelyonet.Models.Rol", "Rol")
                        .WithMany()
                        .HasForeignKey("RolID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Rol");
                });

            modelBuilder.Entity("otelyonet.Models.Musteri", b =>
                {
                    b.HasOne("otelyonet.Models.Cinsiyet", "Cinsiyet")
                        .WithMany()
                        .HasForeignKey("CinsiyetID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("otelyonet.Models.MusteriTip", "MusteriTip")
                        .WithMany()
                        .HasForeignKey("MusteriTipID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cinsiyet");

                    b.Navigation("MusteriTip");
                });
#pragma warning restore 612, 618
        }
    }
}
