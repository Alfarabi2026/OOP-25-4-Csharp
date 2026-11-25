namespace WitcherWorld.Domain.Entities;

public class Review : BaseEntity
{
    public int UserId { get; set; }
    public User User { get; set; } = null!;

    public string Content { get; set; } = string.Empty;

    public int Rating { get; set; }

    public int? MonsterId { get; set; }
    public Monster? Monster { get; set; }

    public int? WeaponId { get; set; }
    public Weapon? Weapon { get; set; }

    public int? ArmorId { get; set; }
    public Armor? Armor { get; set; }

    public int? CharacterId { get; set; }
    public Character? Character { get; set; }

    public int? QuestId { get; set; }
    public Quest? Quest { get; set; }

    public int? LocationId { get; set; }
    public Location? Location { get; set; }
}
