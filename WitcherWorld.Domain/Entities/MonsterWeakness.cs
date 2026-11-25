namespace WitcherWorld.Domain.Entities;

public class MonsterWeakness : BaseEntity
{
    public int MonsterId { get; set; }

    public Monster Monster { get; set; } = null!;

    public int WeaknessId { get; set; }

    public Weakness Weakness { get; set; } = null!;
}
