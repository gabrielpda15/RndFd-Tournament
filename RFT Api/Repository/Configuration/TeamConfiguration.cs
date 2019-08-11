using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RFT.Api.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RFT.Api.Repository.Configuration
{
    public class TeamConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.HasOne(x => x.Tournament)
                .WithMany(x => x.Teams);

            builder.HasOne(x => x.Admin)
                .WithOne(x => x.TeamAdmin)
                .HasForeignKey<User>(x => x.TeamAdminId);
        }
    }
}
