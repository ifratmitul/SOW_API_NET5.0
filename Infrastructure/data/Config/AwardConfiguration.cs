using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.data.Config
{
    public class AwardConfiguration : IEntityTypeConfiguration<Award>
    {
        public void Configure(EntityTypeBuilder<Award> builder)
        {
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.PlayerName).IsRequired().HasMaxLength(100);
            builder.Property(p => p.TournamentName).IsRequired().HasMaxLength(100);
            builder.Property(p => p.AwardName).IsRequired().HasMaxLength(100);
        }


    }
}