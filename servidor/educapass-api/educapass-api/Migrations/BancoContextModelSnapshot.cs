﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using educapass_api.Db;

#nullable disable

namespace educapass_api.Migrations
{
    [DbContext(typeof(BancoContext))]
    partial class BancoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("educapass_api.Models.ClaseModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Descricao")
                        .HasColumnType("text");

                    b.Property<int>("Escola_id")
                        .HasColumnType("integer");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Escola_id");

                    b.ToTable("Clase");
                });

            modelBuilder.Entity("educapass_api.Models.EscolaModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Cep")
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Endereco")
                        .HasColumnType("text");

                    b.Property<string>("Logo")
                        .HasColumnType("text");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Telefone")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Escola");
                });

            modelBuilder.Entity("educapass_api.Models.ClaseModel", b =>
                {
                    b.HasOne("educapass_api.Models.EscolaModel", "Escola")
                        .WithMany("Clase")
                        .HasForeignKey("Escola_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Escola");
                });

            modelBuilder.Entity("educapass_api.Models.EscolaModel", b =>
                {
                    b.Navigation("Clase");
                });
#pragma warning restore 612, 618
        }
    }
}
