using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WitcherWorld.Domain.Entities;

namespace WitcherWorld.Infrastructure.Configurations;

public class MonsterWeaknessConfiguration
    : IEntityTypeConfiguration<MonsterWeakness>
{
    public void Configure(EntityTypeBuilder<MonsterWeakness> builder)
    {
        builder.ToTable("MonsterWeaknesses");

        builder.HasKey(mw => mw.Id);

        builder.HasOne(mw => mw.Monster)
            .WithMany()
            .HasForeignKey(mw => mw.MonsterId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(mw => mw.Weakness)
            .WithMany(w => w.MonsterWeaknesses)
            .HasForeignKey(mw => mw.WeaknessId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(mw => new
        {
            mw.MonsterId,
            mw.WeaknessId
        }).IsUnique();
    }
}
