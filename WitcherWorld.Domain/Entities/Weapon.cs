namespace WitcherWorld.Domain.Entities;

public class Weapon : BaseEntity
{
    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }

    public string? ImageUrl { get; set; }

    public string? WeaponType { get; set; }

    public int Damage { get; set; }

    public int RequiredLevel { get; set; }

    public string? Rarity { get; set; }

    public float Weight { get; set; }

    public int? CategoryId { get; set; }

    public Category? Category { get; set; }
}
