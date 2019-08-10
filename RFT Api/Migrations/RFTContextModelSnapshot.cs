﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RFT.Api.Repository;

namespace RFT.Api.Migrations
{
    [DbContext(typeof(RFTContext))]
    partial class RFTContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0-preview7.19362.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RFT.Api.Repository.Models.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("EditionDate")
                        .IsConcurrencyToken();

                    b.Property<string>("EditionUser")
                        .HasMaxLength(50);

                    b.Property<int>("Elo");

                    b.Property<string>("Name")
                        .HasMaxLength(60);

                    b.Property<string>("Nickname")
                        .HasMaxLength(16);

                    b.Property<int>("Roles");

                    b.HasKey("Id");

                    b.ToTable("rft_players");
                });

            modelBuilder.Entity("RFT.Api.Repository.Models.PlayerTournament", b =>
                {
                    b.Property<int>("PlayerId");

                    b.Property<int>("TournamentId");

                    b.HasKey("PlayerId", "TournamentId");

                    b.HasIndex("TournamentId");

                    b.ToTable("rft_playertournament");
                });

            modelBuilder.Entity("RFT.Api.Repository.Models.Tournament", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date");

                    b.Property<DateTime?>("EditionDate")
                        .IsConcurrencyToken();

                    b.Property<string>("EditionUser")
                        .HasMaxLength(50);

                    b.Property<string>("Name")
                        .HasMaxLength(60);

                    b.HasKey("Id");

                    b.ToTable("rft_tournament");
                });

            modelBuilder.Entity("RFT.Api.Repository.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("EditionDate")
                        .IsConcurrencyToken();

                    b.Property<string>("EditionUser")
                        .HasMaxLength(50);

                    b.Property<string>("PasswordHash")
                        .HasMaxLength(120);

                    b.Property<int>("Permission");

                    b.Property<string>("Username")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("rft_users");
                });

            modelBuilder.Entity("RFT.Api.Repository.Models.PlayerTournament", b =>
                {
                    b.HasOne("RFT.Api.Repository.Models.Player", "Player")
                        .WithMany("PlayerTournaments")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RFT.Api.Repository.Models.Tournament", "Tournament")
                        .WithMany("PlayerTournaments")
                        .HasForeignKey("TournamentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
