using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WitcherWorld.Domain.Entities;

namespace WitcherWorld.Infrastructure.Configurations;

public class QuestConfiguration
    : IEntityTypeConfiguration<Quest>
{
    public void Configure(EntityTypeBuilder<Quest> builder)
    {
        builder.ToTable("Quests");

        builder.HasKey(q => q.Id);

        builder.Property(q => q.Name)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(q => q.Description)
            .HasMaxLength(3000);

        builder.Property(q => q.ImageUrl)
            .HasMaxLength(500);

        builder.Property(q => q.QuestType)
            .HasMaxLength(100);

        builder.Property(q => q.RecommendedLevel)
            .IsRequired();

        builder.Property(q => q.Location)
            .HasMaxLength(200);

        builder.Property(q => q.Rewards)
            .HasMaxLength(1000);

        builder.Property(q => q.Difficulty)
            .HasMaxLength(50);
    }
}
