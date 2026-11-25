using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WitcherWorld.Domain.Entities;

namespace WitcherWorld.Infrastructure.Configurations;

public class CharacterConfiguration
    : IEntityTypeConfiguration<Character>
{
    public void Configure(EntityTypeBuilder<Character> builder)
    {
        builder.ToTable("Characters");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(c => c.Title)
            .HasMaxLength(150);

        builder.Property(c => c.Description)
            .HasMaxLength(2000);

        builder.Property(c => c.Biography)
            .HasMaxLength(5000);

        builder.Property(c => c.ImageUrl)
            .HasMaxLength(500);

        builder.Property(c => c.Gender)
            .HasMaxLength(30);

        builder.Property(c => c.Race)
            .HasMaxLength(50);

        builder.Property(c => c.Affiliation)
            .HasMaxLength(100);

        builder.Property(c => c.IsPlayable)
            .IsRequired();
    }
}
