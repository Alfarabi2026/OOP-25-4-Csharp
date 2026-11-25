namespace WitcherWorld.Domain.Entities;

public class Armor : BaseEntity
{
    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }

    public string? ImageUrl { get; set; }

    public string? ArmorType { get; set; }

    public int ArmorRating { get; set; }

    public int RequiredLevel { get; set; }

    public string? SetName { get; set; }

    public float Weight { get; set; }

    public int? CategoryId { get; set; }

    public Category? Category { get; set; }
}
