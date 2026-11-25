using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WitcherWorld.Domain.Entities;

namespace WitcherWorld.Infrastructure.Configurations;

public class MonsterConfiguration
    : IEntityTypeConfiguration<Monster>
{
    public void Configure(EntityTypeBuilder<Monster> builder)
    {
        builder.ToTable("Monsters");

        builder.HasKey(m => m.Id);

        builder.Property(m => m.Name)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(m => m.Description)
            .HasMaxLength(2000);

        builder.Property(m => m.ImageUrl)
            .HasMaxLength(500);

        builder.Property(m => m.Category)
            .HasMaxLength(100);

        builder.Property(m => m.RecommendedLevel)
            .IsRequired();

        builder.Property(m => m.Habitat)
            .HasMaxLength(200);

        builder.Property(m => m.DangerLevel)
            .HasMaxLength(50);

        builder.Property(m => m.Loot)
            .HasMaxLength(1000);
    }
}
