namespace WitcherWorld.Domain.Entities;

public class Monster : BaseEntity
{
    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }

    public string? ImageUrl { get; set; }

    public string? Category { get; set; }
    
    public int RecommendedLevel { get; set; }

    public string? Habitat { get; set; }

    public string? DangerLevel { get; set; }

    public string? Loot { get; set; }
}
