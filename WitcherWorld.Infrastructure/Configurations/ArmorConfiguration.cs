using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WitcherWorld.Domain.Entities;

namespace WitcherWorld.Infrastructure.Configurations;

public class ArmorConfiguration : IEntityTypeConfiguration<Armor>
{
    public void Configure(EntityTypeBuilder<Armor> builder)
    {
        builder.ToTable("Armors");

        builder.HasKey(a => a.Id);

        builder.Property(a => a.Name)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(a => a.Description)
            .HasMaxLength(2000);

        builder.Property(a => a.ImageUrl)
            .HasMaxLength(500);

        builder.Property(a => a.ArmorType)
            .HasMaxLength(50);

        builder.Property(a => a.SetName)
            .HasMaxLength(100);

        builder.Property(a => a.ArmorRating)
            .IsRequired();

        builder.Property(a => a.RequiredLevel)
            .IsRequired();

        builder.Property(a => a.Weight)
            .IsRequired();

        builder.HasOne(a => a.Category)
            .WithMany(c => c.Armors)
            .HasForeignKey(a => a.CategoryId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}
