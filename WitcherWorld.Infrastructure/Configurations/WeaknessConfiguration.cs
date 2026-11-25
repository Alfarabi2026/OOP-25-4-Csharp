using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WitcherWorld.Domain.Entities;

namespace WitcherWorld.Infrastructure.Configurations;

public class WeaknessConfiguration
    : IEntityTypeConfiguration<Weakness>
{
    public void Configure(EntityTypeBuilder<Weakness> builder)
    {
        builder.ToTable("Weaknesses");

        builder.HasKey(w => w.Id);

        builder.Property(w => w.Name)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(w => w.Description)
            .HasMaxLength(1000);

        builder.HasIndex(w => w.Name)
            .IsUnique();
    }
}
