using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.data.Config
{
    public class TournyAwardConfiguration : IEntityTypeConfiguration<TournamentAward>
    {
        public void Configure(EntityTypeBuilder<TournamentAward> builder)
        {
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.TournamentName).IsRequired().HasMaxLength(100);
            builder.Property(p => p.FinishedPosition).IsRequired().HasMaxLength(100);

        }
    }
}