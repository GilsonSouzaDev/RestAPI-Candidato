﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using candidatos.Data;

#nullable disable

namespace candidato.Migrations
{
    [DbContext(typeof(CandidatoContext))]
    [Migration("20240313025335_firstMigration")]
    partial class firstMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("candidatos.Models.Candidato", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("CandidatoId");

                    b.Property<long>("EnderecoId")
                        .HasColumnType("bigint");

                    b.Property<long>("FiliacaoId")
                        .HasColumnType("bigint");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("VARCHAR");

                    b.HasKey("Id");

                    b.HasIndex("EnderecoId")
                        .IsUnique();

                    b.HasIndex("FiliacaoId")
                        .IsUnique();

                    b.ToTable("Candidatos");
                });

            modelBuilder.Entity("candidatos.Models.Cidade", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("CidadeId");

                    b.Property<long>("EstadoId")
                        .HasColumnType("bigint");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("VARCHAR");

                    b.HasKey("Id");

                    b.HasIndex("EstadoId")
                        .IsUnique();

                    b.ToTable("Cidades");
                });

            modelBuilder.Entity("candidatos.Models.Curso", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("CursoId");

                    b.Property<long?>("CandidatoId")
                        .HasColumnType("bigint");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("VARCHAR");

                    b.HasKey("Id");

                    b.HasIndex("CandidatoId");

                    b.ToTable("Cursos");
                });

            modelBuilder.Entity("candidatos.Models.Endereco", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("EnderecoId");

                    b.Property<string>("Cep")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.Property<long>("CidadeId")
                        .HasColumnType("bigint");

                    b.Property<string>("Logradouro")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("VARCHAR");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("VARCHAR");

                    b.HasKey("Id");

                    b.HasIndex("CidadeId")
                        .IsUnique();

                    b.ToTable("Enderecos");
                });

            modelBuilder.Entity("candidatos.Models.Estado", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("EstadoId");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("VARCHAR");

                    b.Property<string>("Sigla")
                        .IsRequired()
                        .HasMaxLength(2)
                        .HasColumnType("varchar(2)");

                    b.HasKey("Id");

                    b.ToTable("Estados");
                });

            modelBuilder.Entity("candidatos.Models.Filiacao", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("FiliacaoId");

                    b.Property<string>("NomeMae")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("VARCHAR");

                    b.Property<string>("NomePai")
                        .HasMaxLength(200)
                        .HasColumnType("VARCHAR");

                    b.HasKey("Id");

                    b.ToTable("Filiacoes");
                });

            modelBuilder.Entity("candidatos.Models.Telefone", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("TelefoneId");

                    b.Property<long?>("CandidatoId")
                        .HasColumnType("bigint");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("VARCHAR");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("CandidatoId");

                    b.ToTable("Telefones");
                });

            modelBuilder.Entity("candidatos.Models.Candidato", b =>
                {
                    b.HasOne("candidatos.Models.Endereco", "Endereco")
                        .WithOne()
                        .HasForeignKey("candidatos.Models.Candidato", "EnderecoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("candidatos.Models.Filiacao", "Filiacao")
                        .WithOne()
                        .HasForeignKey("candidatos.Models.Candidato", "FiliacaoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Endereco");

                    b.Navigation("Filiacao");
                });

            modelBuilder.Entity("candidatos.Models.Cidade", b =>
                {
                    b.HasOne("candidatos.Models.Estado", "Estado")
                        .WithOne()
                        .HasForeignKey("candidatos.Models.Cidade", "EstadoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Estado");
                });

            modelBuilder.Entity("candidatos.Models.Curso", b =>
                {
                    b.HasOne("candidatos.Models.Candidato", null)
                        .WithMany("Cursos")
                        .HasForeignKey("CandidatoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("candidatos.Models.Endereco", b =>
                {
                    b.HasOne("candidatos.Models.Cidade", "Cidade")
                        .WithOne()
                        .HasForeignKey("candidatos.Models.Endereco", "CidadeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cidade");
                });

            modelBuilder.Entity("candidatos.Models.Telefone", b =>
                {
                    b.HasOne("candidatos.Models.Candidato", null)
                        .WithMany("Telefones")
                        .HasForeignKey("CandidatoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("candidatos.Models.Candidato", b =>
                {
                    b.Navigation("Cursos");

                    b.Navigation("Telefones");
                });
#pragma warning restore 612, 618
        }
    }
}
