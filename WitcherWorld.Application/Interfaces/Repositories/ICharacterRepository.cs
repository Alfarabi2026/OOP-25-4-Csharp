using WitcherWorld.Domain.Entities;

namespace WitcherWorld.Application.Interfaces.Repositories;

public interface ICharacterRepository
{
    Task<IReadOnlyList<Character>> GetAllAsync();
}
