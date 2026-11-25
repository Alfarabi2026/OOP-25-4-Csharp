namespace WitcherWorld.Domain.Entities;

public class Quest : BaseEntity
{
    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }

    public string? ImageUrl { get; set; }

    public string? QuestType { get; set; }

    public int RecommendedLevel { get; set; }

    public string? Location { get; set; }

    public string? Rewards { get; set; }

    public string? Difficulty { get; set; }
}
