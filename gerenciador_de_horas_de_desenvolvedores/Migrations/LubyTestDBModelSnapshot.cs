﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using gerenciador_de_horas_de_desenvolvedores.ContextDB;

namespace gerenciador_de_horas_de_desenvolvedores.Migrations
{
    [DbContext(typeof(LubyTestDB))]
    partial class LubyTestDBModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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
                    b.Property<int>("DesenvolvedorTableId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Cargo")
                        .IsRequired()
                        .HasColumnName("Cargo")
                        .HasColumnType("varchar(50) CHARACTER SET utf8mb4")
                        .HasMaxLength(50);

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnName("Nome")
                        .HasColumnType("varchar(120) CHARACTER SET utf8mb4")
                        .HasMaxLength(120);

                    b.Property<double>("ValorH")
                        .HasColumnName("Valor por hora")
                        .HasColumnType("double");

                    b.HasKey("DesenvolvedorTableId");

                    b.ToTable("Desenvolvedores");
                });

            modelBuilder.Entity("gerenciador_de_horas_de_desenvolvedores.ContextDB.DevsEmProjetosTable", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Desenvolvedor")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("ProjetoTableId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProjetoTableId");

                    b.ToTable("DevsEmProjetos");
                });

            modelBuilder.Entity("gerenciador_de_horas_de_desenvolvedores.ContextDB.HorasAcomuladasDevTable", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Desenvolvedor")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<double>("HorasAcomuladas")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.ToTable("HorasAcomuladasDev");
                });

            modelBuilder.Entity("gerenciador_de_horas_de_desenvolvedores.ContextDB.ProjetoTable", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("descricao")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("projeto")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("Projetos");
                });

            modelBuilder.Entity("gerenciador_de_horas_de_desenvolvedores.ContextDB.DevsEmProjetosTable", b =>
                {
                    b.HasOne("gerenciador_de_horas_de_desenvolvedores.ContextDB.ProjetoTable", null)
                        .WithMany("DevsEmProjetosTable")
                        .HasForeignKey("ProjetoTableId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
