using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RFT.Api.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RFT.Api.Repository.Configuration
{
    public class PlayerTournamentConfiguration : IEntityTypeConfiguration<PlayerTournament>
    {
        public void Configure(EntityTypeBuilder<PlayerTournament> builder)
        {
            builder.HasKey(x => new { x.PlayerId, x.TournamentId });
            builder.HasOne(x => x.Tournament)
                .WithMany(x => x.PlayerTournaments)
                .HasForeignKey(x => x.TournamentId)
                .IsRequired();
            builder.HasOne(x => x.Player)
                .WithMany(x => x.PlayerTournaments)
                .HasForeignKey(x => x.PlayerId)
                .IsRequired();
        }
    }
}
