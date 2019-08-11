using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RFT.Api.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RFT.Api.Repository.Configuration
{
    public class TeamPlayerConfiguration : IEntityTypeConfiguration<TeamPlayer>
    {
        public void Configure(EntityTypeBuilder<TeamPlayer> builder)
        {
            builder.HasKey(x => new { x.PlayerId, x.TeamId });
            builder.HasOne(x => x.Team)
                .WithMany(x => x.TeamPlayers)
                .HasForeignKey(x => x.TeamId)
                .IsRequired();
            builder.HasOne(x => x.Player)
                .WithMany(x => x.TeamPlayers)
                .HasForeignKey(x => x.PlayerId)
                .IsRequired();
        }
    }
}
