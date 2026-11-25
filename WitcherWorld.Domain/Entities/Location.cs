namespace WitcherWorld.Domain.Entities;

public class Location : BaseEntity
{
    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }

    public string? ImageUrl { get; set; }

    public string? Region { get; set; }

    public string? LocationType { get; set; }

    public string? Coordinates { get; set; }

    public bool IsDiscovered { get; set; } = false;
}
