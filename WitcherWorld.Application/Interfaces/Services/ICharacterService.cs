using WitcherWorld.Domain.Entities;

namespace WitcherWorld.Application.Interfaces.Services;

public interface ICharacterService
{
    Task<IReadOnlyList<Character>> GetAllAsync();
}
