﻿// <auto-generated />
using System;
using IPS.Feed.Infra;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace IPS.Feed.Infa.Migrations
{
    [DbContext(typeof(FeedContext))]
    partial class FeedContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("IPS.Feed.Domain.Models.Comentario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Data")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("IdPostagem")
                        .HasColumnType("uuid");

                    b.Property<Guid>("IdUsuario")
                        .HasColumnType("uuid");

                    b.Property<string>("Mensagem")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("character varying(300)");

                    b.HasKey("Id");

                    b.HasIndex("IdPostagem");

                    b.ToTable("Comentarios", (string)null);
                });

            modelBuilder.Entity("IPS.Feed.Domain.Models.Curtida", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("DataCurtida")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("IdPostagem")
                        .HasColumnType("uuid");

                    b.Property<Guid>("IdUsuario")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("IdPostagem");

                    b.ToTable("Curtidas", (string)null);
                });

            modelBuilder.Entity("IPS.Feed.Domain.Models.Postagem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("DataPostagems")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("EntidadesNlp")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("IdUsuario")
                        .HasColumnType("uuid");

                    b.Property<double>("Latitude")
                        .HasColumnType("double precision");

                    b.Property<double>("Longitude")
                        .HasColumnType("double precision");

                    b.Property<string>("Mensagem")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("character varying(300)");

                    b.Property<bool>("Modificado")
                        .HasColumnType("boolean");

                    b.Property<string>("Regiao")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Postagens", (string)null);
                });

            modelBuilder.Entity("IPS.Feed.Domain.Models.RelacaoSeguindo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("IdSeguidores")
                        .HasColumnType("uuid");

                    b.Property<Guid>("IdUsuario")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("IdUsuario", "IdSeguidores")
                        .IsUnique();

                    b.ToTable("Seguidores", (string)null);
                });

            modelBuilder.Entity("IPS.Feed.Domain.Models.Comentario", b =>
                {
                    b.HasOne("IPS.Feed.Domain.Models.Postagem", "Postagem")
                        .WithMany("Comentarios")
                        .HasForeignKey("IdPostagem")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Postagem");
                });

            modelBuilder.Entity("IPS.Feed.Domain.Models.Curtida", b =>
                {
                    b.HasOne("IPS.Feed.Domain.Models.Postagem", "Postagem")
                        .WithMany("Curtidas")
                        .HasForeignKey("IdPostagem")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Postagem");
                });

            modelBuilder.Entity("IPS.Feed.Domain.Models.Postagem", b =>
                {
                    b.Navigation("Comentarios");

                    b.Navigation("Curtidas");
                });
#pragma warning restore 612, 618
        }
    }
}
