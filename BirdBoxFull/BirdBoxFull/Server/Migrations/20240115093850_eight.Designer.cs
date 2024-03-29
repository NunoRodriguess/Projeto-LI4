﻿// <auto-generated />
using System;
using BirdBoxFull.Server.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BirdBoxFull.Server.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20240115093850_eight")]
    partial class eight
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.22")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BirdBoxFull.Shared.Encomenda", b =>
                {
                    b.Property<string>("codEncomenda")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)")
                        .HasDefaultValue("NEWID()");

                    b.Property<string>("LeilaoCodLeilao")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UtilizadorUsername")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("numeroSeguimento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("codEncomenda");

                    b.HasIndex("LeilaoCodLeilao")
                        .IsUnique();

                    b.HasIndex("UtilizadorUsername");

                    b.ToTable("Encomendas");
                });

            modelBuilder.Entity("BirdBoxFull.Shared.LeilaoImage", b =>
                {
                    b.Property<int>("ImageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ImageId"), 1L, 1);

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LeilaoCodLeilao")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ImageId");

                    b.HasIndex("LeilaoCodLeilao");

                    b.ToTable("LeilaoImages");
                });

            modelBuilder.Entity("BirdBoxFull.Shared.Licitacao", b =>
                {
                    b.Property<string>("codLicitacao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)")
                        .HasDefaultValue("NEWID()");

                    b.Property<string>("LeilaoCodLeilao")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UtilizadorUsername")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("timestamp")
                        .HasColumnType("datetime2");

                    b.Property<float>("valor")
                        .HasColumnType("real");

                    b.HasKey("codLicitacao");

                    b.HasIndex("LeilaoCodLeilao");

                    b.HasIndex("UtilizadorUsername");

                    b.ToTable("Licitacoes");
                });

            modelBuilder.Entity("BirdBoxFull.Shared.Utilizador", b =>
                {
                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("cc")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("codigoPostal")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("dataNascimento")
                        .HasColumnType("datetime2");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("indicativo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("localidade")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("metodoPagamento")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("numeroPorta")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("numeroTelemovel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("rua")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Username");

                    b.ToTable("Utilizadores");
                });

            modelBuilder.Entity("BirdBoxFull.Shared.WishList", b =>
                {
                    b.Property<string>("LeilaoCodLeilao")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("UtilizadorUsername")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LeilaoCodLeilao", "UtilizadorUsername");

                    b.HasIndex("UtilizadorUsername");

                    b.ToTable("WishLists");
                });

            modelBuilder.Entity("Leilao", b =>
                {
                    b.Property<string>("CodLeilao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(450)")
                        .HasDefaultValue("NEWID()");

                    b.Property<DateTime>("DataFinal")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("EntryPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Estado")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsPublic")
                        .HasColumnType("bit");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Relatorio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UtilizadorUsername")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<float>("ValorMinimo")
                        .HasColumnType("real");

                    b.HasKey("CodLeilao");

                    b.HasIndex("UtilizadorUsername");

                    b.ToTable("Leiloes");
                });

            modelBuilder.Entity("BirdBoxFull.Shared.Encomenda", b =>
                {
                    b.HasOne("Leilao", "Leilao")
                        .WithOne("Encomenda")
                        .HasForeignKey("BirdBoxFull.Shared.Encomenda", "LeilaoCodLeilao")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BirdBoxFull.Shared.Utilizador", "Utilizador")
                        .WithMany("Encomendas")
                        .HasForeignKey("UtilizadorUsername")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Leilao");

                    b.Navigation("Utilizador");
                });

            modelBuilder.Entity("BirdBoxFull.Shared.LeilaoImage", b =>
                {
                    b.HasOne("Leilao", "Leilao")
                        .WithMany()
                        .HasForeignKey("LeilaoCodLeilao")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Leilao");
                });

            modelBuilder.Entity("BirdBoxFull.Shared.Licitacao", b =>
                {
                    b.HasOne("Leilao", "Leilao")
                        .WithMany("Licitacoes")
                        .HasForeignKey("LeilaoCodLeilao")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("BirdBoxFull.Shared.Utilizador", "Utilizador")
                        .WithMany("Licitacoes")
                        .HasForeignKey("UtilizadorUsername")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Leilao");

                    b.Navigation("Utilizador");
                });

            modelBuilder.Entity("BirdBoxFull.Shared.WishList", b =>
                {
                    b.HasOne("Leilao", "Leilao")
                        .WithMany("WishLists")
                        .HasForeignKey("LeilaoCodLeilao")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("BirdBoxFull.Shared.Utilizador", "Utilizador")
                        .WithMany("WishLists")
                        .HasForeignKey("UtilizadorUsername")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Leilao");

                    b.Navigation("Utilizador");
                });

            modelBuilder.Entity("Leilao", b =>
                {
                    b.HasOne("BirdBoxFull.Shared.Utilizador", "Utilizador")
                        .WithMany("Leiloes")
                        .HasForeignKey("UtilizadorUsername")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Utilizador");
                });

            modelBuilder.Entity("BirdBoxFull.Shared.Utilizador", b =>
                {
                    b.Navigation("Encomendas");

                    b.Navigation("Leiloes");

                    b.Navigation("Licitacoes");

                    b.Navigation("WishLists");
                });

            modelBuilder.Entity("Leilao", b =>
                {
                    b.Navigation("Encomenda");

                    b.Navigation("Licitacoes");

                    b.Navigation("WishLists");
                });
#pragma warning restore 612, 618
        }
    }
}
