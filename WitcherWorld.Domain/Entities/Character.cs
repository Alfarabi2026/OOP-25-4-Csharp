namespace WitcherWorld.Domain.Entities;

public class Character : BaseEntity
{
    public string Name { get; set; } = string.Empty;

    public string? Title { get; set; }

    public string? Description { get; set; }

    public string? Biography { get; set; }

    public string? ImageUrl { get; set; }

    public string? Gender { get; set; }

    public string? Race { get; set; }

    public string? Affiliation { get; set; }

    public bool IsPlayable { get; set; } = false;
}
