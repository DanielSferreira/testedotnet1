﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using gerenciador_de_horas_de_desenvolvedores.ContextDB;

namespace gerenciador_de_horas_de_desenvolvedores.Migrations
{
    [DbContext(typeof(LubyTestDB))]
    [Migration("20201226121806_Atualizando2")]
    partial class Atualizando2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("gerenciador_de_horas_de_desenvolvedores.ContextDB.BancoHorasTable", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DataFim")
                        .HasColumnName("Data Final")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("DataId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataIni")
                        .HasColumnName("Data Inicio")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Desenvolvedor")
                        .IsRequired()
                        .HasColumnName("Desenvolvedor")
                        .HasColumnType("varchar(120) CHARACTER SET utf8mb4")
                        .HasMaxLength(120);

                    b.HasKey("Id");

                    b.ToTable("BancoHoras");
                });

            modelBuilder.Entity("gerenciador_de_horas_de_desenvolvedores.ContextDB.DesenvolvedorTable", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Cargo")
                        .IsRequired()
                        .HasColumnName("Cargo")
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
                        .HasMaxLength(50);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnName("Nome desenvolvedor")
                        .HasColumnType("varchar(120) CHARACTER SET utf8mb4")
                        .HasMaxLength(120);

                    b.Property<double>("ValorH")
                        .HasColumnName("Valor por hora")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.ToTable("Desenvolvedores");
                });

            modelBuilder.Entity("gerenciador_de_horas_de_desenvolvedores.ContextDB.HorasAcomuladasDevTable", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Desenvolvedor")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("HorasAcomuladas")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("HorasAcomuladasDev");
                });
#pragma warning restore 612, 618
        }
    }
}
