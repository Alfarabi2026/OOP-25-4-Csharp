namespace WitcherWorld.Domain.Entities;

public class Weakness : BaseEntity
{
    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }

    public ICollection<MonsterWeakness> MonsterWeaknesses { get; set; }
        = new List<MonsterWeakness>();
}
