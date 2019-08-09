using Microsoft.EntityFrameworkCore;
using RFT.Api.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RFT.Api.Repository
{
    public class RFTContext : DbContext
    {
        public RFTContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PlayerTournament>()
                .HasKey(x => new { x.PlayerId, x.TournamentId });
            modelBuilder.Entity<PlayerTournament>()
                .HasOne(x => x.Tournament)
                .WithMany(x => x.PlayerTournaments)
                .HasForeignKey(x => x.TournamentId)
                .IsRequired();
            modelBuilder.Entity<PlayerTournament>()
                .HasOne(x => x.Player)
                .WithMany(x => x.PlayerTournaments)
                .HasForeignKey(x => x.PlayerId)
                .IsRequired();
        }

        public DbSet<Player> Players { get; set; }
        public DbSet<Tournament> Tournaments { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
