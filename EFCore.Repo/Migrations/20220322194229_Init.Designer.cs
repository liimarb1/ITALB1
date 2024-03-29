﻿// <auto-generated />
using System;
using EFCore.Repo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EFCore.Repo.Migrations
{
    [DbContext(typeof(ITContext))]
    [Migration("20220322194229_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.15")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EFCore.Dominio.Equipamento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FuncionarioId")
                        .HasColumnType("int");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FuncionarioId");

                    b.ToTable("Equipamentos");
                });

            modelBuilder.Entity("EFCore.Dominio.FuncSquad", b =>
                {
                    b.Property<int>("SquadId")
                        .HasColumnType("int");

                    b.Property<int>("FuncionarioId")
                        .HasColumnType("int");

                    b.HasKey("SquadId", "FuncionarioId");

                    b.HasIndex("FuncionarioId");

                    b.ToTable("FuncionariosSquads");
                });

            modelBuilder.Entity("EFCore.Dominio.Funcionario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Funcionarios");
                });

            modelBuilder.Entity("EFCore.Dominio.Gestor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FuncionarioId")
                        .HasColumnType("int");

                    b.Property<string>("NomeReal")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FuncionarioId")
                        .IsUnique();

                    b.ToTable("Gestores");
                });

            modelBuilder.Entity("EFCore.Dominio.Squad", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DtFim")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DtInicio")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nome")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Squads");
                });

            modelBuilder.Entity("EFCore.Dominio.Equipamento", b =>
                {
                    b.HasOne("EFCore.Dominio.Funcionario", "Funcionario")
                        .WithMany("Equipamentos")
                        .HasForeignKey("FuncionarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Funcionario");
                });

            modelBuilder.Entity("EFCore.Dominio.FuncSquad", b =>
                {
                    b.HasOne("EFCore.Dominio.Funcionario", "Funcionario")
                        .WithMany("FuncionariosSquads")
                        .HasForeignKey("FuncionarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EFCore.Dominio.Squad", "Squad")
                        .WithMany("FuncionariosSquads")
                        .HasForeignKey("SquadId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Funcionario");

                    b.Navigation("Squad");
                });

            modelBuilder.Entity("EFCore.Dominio.Gestor", b =>
                {
                    b.HasOne("EFCore.Dominio.Funcionario", "Funcionario")
                        .WithOne("Gestor")
                        .HasForeignKey("EFCore.Dominio.Gestor", "FuncionarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Funcionario");
                });

            modelBuilder.Entity("EFCore.Dominio.Funcionario", b =>
                {
                    b.Navigation("Equipamentos");

                    b.Navigation("FuncionariosSquads");

                    b.Navigation("Gestor");
                });

            modelBuilder.Entity("EFCore.Dominio.Squad", b =>
                {
                    b.Navigation("FuncionariosSquads");
                });
#pragma warning restore 612, 618
        }
    }
}
