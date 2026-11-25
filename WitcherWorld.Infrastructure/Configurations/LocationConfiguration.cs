using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WitcherWorld.Domain.Entities;

namespace WitcherWorld.Infrastructure.Configurations;

public class LocationConfiguration
    : IEntityTypeConfiguration<Location>
{
    public void Configure(EntityTypeBuilder<Location> builder)
    {
        builder.ToTable("Locations");

        builder.HasKey(l => l.Id);

        builder.Property(l => l.Name)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(l => l.Description)
            .HasMaxLength(3000);

        builder.Property(l => l.ImageUrl)
            .HasMaxLength(500);

        builder.Property(l => l.Region)
            .HasMaxLength(100);

        builder.Property(l => l.LocationType)
            .HasMaxLength(100);

        builder.Property(l => l.Coordinates)
            .HasMaxLength(100);

        builder.Property(l => l.IsDiscovered)
            .IsRequired();

        builder.HasIndex(l => l.Name);
    }
}
