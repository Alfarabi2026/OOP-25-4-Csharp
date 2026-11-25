namespace WitcherWorld.ViewModels;

public class HomeViewModel
{
    public IReadOnlyList<CharacterCardViewModel> Characters { get; set; }
        = [];
}

public class CharacterCardViewModel
{
    public string Name { get; set; } = string.Empty;
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? ImageUrl { get; set; }
}