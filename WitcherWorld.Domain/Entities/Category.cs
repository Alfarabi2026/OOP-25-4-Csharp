namespace WitcherWorld.Domain.Entities;

public class Category : BaseEntity
{
    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }

    public string? ImageUrl { get; set; }

    public ICollection<Weapon> Weapons { get; set; }
        = new List<Weapon>();

    public ICollection<Armor> Armors { get; set; }
        = new List<Armor>();
}
