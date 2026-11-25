using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WitcherWorld.Domain.Entities;

namespace WitcherWorld.Infrastructure.Configurations;

public class FavoriteConfiguration
    : IEntityTypeConfiguration<Favorite>
{
    public void Configure(EntityTypeBuilder<Favorite> builder)
    {
        builder.ToTable("Favorites", table =>
        {
            table.HasCheckConstraint(
                "CK_Favorites_ExactlyOneItem",
                """
                (CASE WHEN "MonsterId" IS NOT NULL THEN 1 ELSE 0 END +
                 CASE WHEN "WeaponId" IS NOT NULL THEN 1 ELSE 0 END +
                 CASE WHEN "ArmorId" IS NOT NULL THEN 1 ELSE 0 END +
                 CASE WHEN "CharacterId" IS NOT NULL THEN 1 ELSE 0 END +
                 CASE WHEN "QuestId" IS NOT NULL THEN 1 ELSE 0 END +
                 CASE WHEN "LocationId" IS NOT NULL THEN 1 ELSE 0 END) = 1
                """);
        });

        builder.HasKey(f => f.Id);

        builder.HasOne(f => f.User)
            .WithMany()
            .HasForeignKey(f => f.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(f => f.Monster)
            .WithMany()
            .HasForeignKey(f => f.MonsterId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(f => f.Weapon)
            .WithMany()
            .HasForeignKey(f => f.WeaponId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(f => f.Armor)
            .WithMany()
            .HasForeignKey(f => f.ArmorId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(f => f.Character)
            .WithMany()
            .HasForeignKey(f => f.CharacterId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(f => f.Quest)
            .WithMany()
            .HasForeignKey(f => f.QuestId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(f => f.Location)
            .WithMany()
            .HasForeignKey(f => f.LocationId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(f => new { f.UserId, f.MonsterId })
            .IsUnique();

        builder.HasIndex(f => new { f.UserId, f.WeaponId })
            .IsUnique();

        builder.HasIndex(f => new { f.UserId, f.ArmorId })
            .IsUnique();

        builder.HasIndex(f => new { f.UserId, f.CharacterId })
            .IsUnique();

        builder.HasIndex(f => new { f.UserId, f.QuestId })
            .IsUnique();

        builder.HasIndex(f => new { f.UserId, f.LocationId })
            .IsUnique();
    }
}
