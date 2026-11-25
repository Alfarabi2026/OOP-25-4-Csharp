using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WitcherWorld.Domain.Entities;

namespace WitcherWorld.Infrastructure.Configurations;

public class ReviewConfiguration
    : IEntityTypeConfiguration<Review>
{
    public void Configure(EntityTypeBuilder<Review> builder)
    {
        builder.ToTable("Reviews", table =>
        {
            table.HasCheckConstraint(
                "CK_Reviews_Rating",
                "\"Rating\" >= 1 AND \"Rating\" <= 5");

            table.HasCheckConstraint(
                "CK_Reviews_ExactlyOneItem",
                """
                (CASE WHEN "MonsterId" IS NOT NULL THEN 1 ELSE 0 END +
                 CASE WHEN "WeaponId" IS NOT NULL THEN 1 ELSE 0 END +
                 CASE WHEN "ArmorId" IS NOT NULL THEN 1 ELSE 0 END +
                 CASE WHEN "CharacterId" IS NOT NULL THEN 1 ELSE 0 END +
                 CASE WHEN "QuestId" IS NOT NULL THEN 1 ELSE 0 END +
                 CASE WHEN "LocationId" IS NOT NULL THEN 1 ELSE 0 END) = 1
                """);
        });

        builder.HasKey(r => r.Id);

        builder.Property(r => r.Content)
            .IsRequired()
            .HasMaxLength(2000);

        builder.Property(r => r.Rating)
            .IsRequired();

        builder.HasOne(r => r.User)
            .WithMany()
            .HasForeignKey(r => r.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(r => r.Monster)
            .WithMany()
            .HasForeignKey(r => r.MonsterId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(r => r.Weapon)
            .WithMany()
            .HasForeignKey(r => r.WeaponId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(r => r.Armor)
            .WithMany()
            .HasForeignKey(r => r.ArmorId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(r => r.Character)
            .WithMany()
            .HasForeignKey(r => r.CharacterId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(r => r.Quest)
            .WithMany()
            .HasForeignKey(r => r.QuestId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(r => r.Location)
            .WithMany()
            .HasForeignKey(r => r.LocationId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(r => new { r.UserId, r.MonsterId })
            .IsUnique();

        builder.HasIndex(r => new { r.UserId, r.WeaponId })
            .IsUnique();

        builder.HasIndex(r => new { r.UserId, r.ArmorId })
            .IsUnique();

        builder.HasIndex(r => new { r.UserId, r.CharacterId })
            .IsUnique();

        builder.HasIndex(r => new { r.UserId, r.QuestId })
            .IsUnique();

        builder.HasIndex(r => new { r.UserId, r.LocationId })
            .IsUnique();
    }
}
