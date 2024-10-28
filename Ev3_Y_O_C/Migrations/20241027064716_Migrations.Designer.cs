﻿// <auto-generated />
using System;
using Ev3_Y_O_C.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Ev3_Y_O_C.Migrations
{
    [DbContext(typeof(AspWebContext))]
    [Migration("20241027064716_Migrations")]
    partial class Migrations
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.35")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Ev3_Y_O_C.Models.Asignacion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("FechaAsignacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FechaRetorno")
                        .HasColumnType("datetime2");

                    b.Property<int>("HerramientaId")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("HerramientaId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Asignaciones");
                });

            modelBuilder.Entity("Ev3_Y_O_C.Models.Herramienta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Estado")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaIngreso")
                        .HasColumnType("datetime2");

                    b.Property<int>("ModeloId")
                        .HasColumnType("int");

                    b.Property<string>("NumeroSerie")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ModeloId");

                    b.ToTable("Herramientas");
                });

            modelBuilder.Entity("Ev3_Y_O_C.Models.Marca", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Marcas");
                });

            modelBuilder.Entity("Ev3_Y_O_C.Models.ModeloHerramienta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("MarcaId")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MarcaId");

                    b.ToTable("ModelosHerramienta");
                });

            modelBuilder.Entity("Ev3_Y_O_C.Models.Movimiento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("FechaMovimiento")
                        .HasColumnType("datetime2");

                    b.Property<int>("HerramientaId")
                        .HasColumnType("int");

                    b.Property<int>("TipoMovimiento")
                        .HasColumnType("int");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("HerramientaId");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Movimientos");
                });

            modelBuilder.Entity("Ev3_Y_O_C.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("Ev3_Y_O_C.Models.Asignacion", b =>
                {
                    b.HasOne("Ev3_Y_O_C.Models.Herramienta", "Herramienta")
                        .WithMany()
                        .HasForeignKey("HerramientaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ev3_Y_O_C.Models.Usuario", "Usuario")
                        .WithMany("Asignaciones")
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Herramienta");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Ev3_Y_O_C.Models.Herramienta", b =>
                {
                    b.HasOne("Ev3_Y_O_C.Models.ModeloHerramienta", "Modelo")
                        .WithMany("Herramientas")
                        .HasForeignKey("ModeloId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Modelo");
                });

            modelBuilder.Entity("Ev3_Y_O_C.Models.ModeloHerramienta", b =>
                {
                    b.HasOne("Ev3_Y_O_C.Models.Marca", "Marca")
                        .WithMany("Modelos")
                        .HasForeignKey("MarcaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Marca");
                });

            modelBuilder.Entity("Ev3_Y_O_C.Models.Movimiento", b =>
                {
                    b.HasOne("Ev3_Y_O_C.Models.Herramienta", "Herramienta")
                        .WithMany()
                        .HasForeignKey("HerramientaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Ev3_Y_O_C.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Herramienta");

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("Ev3_Y_O_C.Models.Marca", b =>
                {
                    b.Navigation("Modelos");
                });

            modelBuilder.Entity("Ev3_Y_O_C.Models.ModeloHerramienta", b =>
                {
                    b.Navigation("Herramientas");
                });

            modelBuilder.Entity("Ev3_Y_O_C.Models.Usuario", b =>
                {
                    b.Navigation("Asignaciones");
                });
#pragma warning restore 612, 618
        }
    }
}