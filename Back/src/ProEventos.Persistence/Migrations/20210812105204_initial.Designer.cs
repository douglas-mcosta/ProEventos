// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProEventos.API.Context;

namespace ProEventos.Persistence.Migrations
{
    [DbContext(typeof(ProEventosContext))]
    [Migration("20210812105204_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.8");

            modelBuilder.Entity("ProEventos.Domain.Evento", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("DataEvento")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("ImagemURL")
                        .HasColumnType("TEXT");

                    b.Property<string>("Local")
                        .HasColumnType("varchar(255)");

                    b.Property<int>("QtdPessoas")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Telefone")
                        .HasColumnType("TEXT");

                    b.Property<string>("Tema")
                        .IsRequired()
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Eventos");
                });

            modelBuilder.Entity("ProEventos.Domain.Lote", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("DataFim")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("DataInicio")
                        .HasColumnType("TEXT");

                    b.Property<int>("EventoId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(30)");

                    b.Property<decimal>("Preco")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Quantidade")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("EventoId");

                    b.ToTable("Lotes");
                });

            modelBuilder.Entity("ProEventos.Domain.Palestrante", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .HasColumnType("varchar(200)");

                    b.Property<string>("ImgURL")
                        .HasColumnType("varchar(200)");

                    b.Property<string>("MiniCurriculo")
                        .HasColumnType("varchar(500)");

                    b.Property<string>("Nome")
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Telefone")
                        .HasColumnType("varchar(9)");

                    b.HasKey("Id");

                    b.ToTable("Palestrantes");
                });

            modelBuilder.Entity("ProEventos.Domain.PalestranteEvento", b =>
                {
                    b.Property<int>("EventoId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PalentranteId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("PalestranteEventoEventoId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("PalestranteEventoPalentranteId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("PalestranteId")
                        .HasColumnType("INTEGER");

                    b.HasKey("EventoId", "PalentranteId");

                    b.HasIndex("PalestranteId");

                    b.HasIndex("PalestranteEventoEventoId", "PalestranteEventoPalentranteId");

                    b.ToTable("PalestrantesEventos");
                });

            modelBuilder.Entity("ProEventos.Domain.RedeSocial", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("EventoId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .HasColumnType("varchar(200)");

                    b.Property<int?>("PalestranteId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("URL")
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("EventoId");

                    b.HasIndex("PalestranteId");

                    b.ToTable("RedeSociais");
                });

            modelBuilder.Entity("ProEventos.Domain.Lote", b =>
                {
                    b.HasOne("ProEventos.Domain.Evento", "Evento")
                        .WithMany("Lotes")
                        .HasForeignKey("EventoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Evento");
                });

            modelBuilder.Entity("ProEventos.Domain.PalestranteEvento", b =>
                {
                    b.HasOne("ProEventos.Domain.Evento", "Evento")
                        .WithMany("PalestrantesEventos")
                        .HasForeignKey("EventoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProEventos.Domain.Palestrante", "Palestrante")
                        .WithMany()
                        .HasForeignKey("PalestranteId");

                    b.HasOne("ProEventos.Domain.PalestranteEvento", null)
                        .WithMany("PalestrantesEventos")
                        .HasForeignKey("PalestranteEventoEventoId", "PalestranteEventoPalentranteId");

                    b.Navigation("Evento");

                    b.Navigation("Palestrante");
                });

            modelBuilder.Entity("ProEventos.Domain.RedeSocial", b =>
                {
                    b.HasOne("ProEventos.Domain.Evento", "Evento")
                        .WithMany("RedeSociais")
                        .HasForeignKey("EventoId");

                    b.HasOne("ProEventos.Domain.Palestrante", "Palestrante")
                        .WithMany("RedeSociais")
                        .HasForeignKey("PalestranteId");

                    b.Navigation("Evento");

                    b.Navigation("Palestrante");
                });

            modelBuilder.Entity("ProEventos.Domain.Evento", b =>
                {
                    b.Navigation("Lotes");

                    b.Navigation("PalestrantesEventos");

                    b.Navigation("RedeSociais");
                });

            modelBuilder.Entity("ProEventos.Domain.Palestrante", b =>
                {
                    b.Navigation("RedeSociais");
                });

            modelBuilder.Entity("ProEventos.Domain.PalestranteEvento", b =>
                {
                    b.Navigation("PalestrantesEventos");
                });
#pragma warning restore 612, 618
        }
    }
}
