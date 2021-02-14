﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using bela.Data;

namespace bela.Migrations
{
    [DbContext(typeof(belaKontekst))]
    [Migration("20210213220416_druga")]
    partial class druga
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("bela.Models.Bela", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BodoviMi")
                        .HasColumnType("int");

                    b.Property<int>("BodoviVi")
                        .HasColumnType("int");

                    b.Property<int>("PartijaId")
                        .HasColumnType("int");

                    b.Property<int>("ZvanjaMi")
                        .HasColumnType("int");

                    b.Property<int>("ZvanjaVi")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PartijaId");

                    b.ToTable("Bela");
                });

            modelBuilder.Entity("bela.Models.Partija", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("broj")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Partija");
                });

            modelBuilder.Entity("bela.Models.Bela", b =>
                {
                    b.HasOne("bela.Models.Partija", "Partija")
                        .WithMany()
                        .HasForeignKey("PartijaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
