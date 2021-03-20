using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.data.Config
{
    public class GeneralConfiguration : IEntityTypeConfiguration<General>
    {
        public void Configure(EntityTypeBuilder<General> builder)
        {
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p => p.Story).IsRequired();
            builder.Property(p => p.ComStory).IsRequired();

        }


    }

}