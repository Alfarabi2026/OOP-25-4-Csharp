using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WitcherWorld.Domain.Entities;

namespace WitcherWorld.Infrastructure.Configurations;

public class WeaponConfiguration : IEntityTypeConfiguration<Weapon>
{
    public void Configure(EntityTypeBuilder<Weapon> builder)
    {
        builder.ToTable("Weapons");

        builder.HasKey(w => w.Id);

        builder.Property(w => w.Name)
            .IsRequired()
            .HasMaxLength(150);

        builder.Property(w => w.Description)
            .HasMaxLength(2000);

        builder.Property(w => w.ImageUrl)
            .HasMaxLength(500);

        builder.Property(w => w.WeaponType)
            .HasMaxLength(50);

        builder.Property(w => w.Rarity)
            .HasMaxLength(50);

        builder.Property(w => w.Damage)
            .IsRequired();

        builder.Property(w => w.RequiredLevel)
            .IsRequired();

        builder.Property(w => w.Weight)
            .IsRequired();

        builder.HasOne(w => w.Category)
            .WithMany(c => c.Weapons)
            .HasForeignKey(w => w.CategoryId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}
