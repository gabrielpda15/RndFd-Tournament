using Microsoft.EntityFrameworkCore;
using RFT.Api.Repository.Configuration;
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

            modelBuilder.ApplyConfiguration(new PlayerTournamentConfiguration());
            modelBuilder.ApplyConfiguration(new TeamPlayerConfiguration());

            modelBuilder.ApplyConfiguration(new TeamConfiguration());

            modelBuilder.Entity<User>()
                .HasOne(x => x.Player)
                .WithOne(x => x.User)
                .HasForeignKey<User>(x => x.PlayerId);          
        }

        public DbSet<Team> Teams { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Tournament> Tournaments { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
