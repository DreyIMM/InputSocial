﻿// <auto-generated />
using System;
using IPS.Feed.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
#nullable disable

namespace IPS.Feed.API.Migrations
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

            modelBuilder.Entity("IPS.Feed.API.Models.Comentario", b =>
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

            modelBuilder.Entity("IPS.Feed.API.Models.Curtida", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("DataCurtida")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("IdPostagem")
                        .HasColumnType("uuid");

                    b.Property<Guid>("IdUsuario")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("IdPostagem");

                    b.ToTable("Curtidas", (string)null);
                });

            modelBuilder.Entity("IPS.Feed.API.Models.Postagem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("DataPostagems")
                        .HasColumnType("timestamp without time zone");

                    b.Property<Guid>("IdUsuario")
                        .HasColumnType("uuid");

                    b.Property<string>("Mensagem")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("character varying(300)");

                    b.Property<bool>("Modificado")
                        .HasColumnType("boolean");

                    b.HasKey("Id");

                    b.ToTable("Postagens", (string)null);
                });

            modelBuilder.Entity("IPS.Feed.API.Models.Comentario", b =>
                {
                    b.HasOne("IPS.Feed.API.Models.Postagem", "Postagem")
                        .WithMany("Comentarios")
                        .HasForeignKey("IdPostagem")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Postagem");
                });

            modelBuilder.Entity("IPS.Feed.API.Models.Curtida", b =>
                {
                    b.HasOne("IPS.Feed.API.Models.Postagem", "Postagem")
                        .WithMany("Curtidas")
                        .HasForeignKey("IdPostagem")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Postagem");
                });

            modelBuilder.Entity("IPS.Feed.API.Models.Postagem", b =>
                {
                    b.Navigation("Comentarios");

                    b.Navigation("Curtidas");
                });
#pragma warning restore 612, 618
        }
    }
}
