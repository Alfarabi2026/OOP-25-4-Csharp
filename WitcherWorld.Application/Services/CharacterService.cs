using WitcherWorld.Application.Interfaces.Repositories;
using WitcherWorld.Application.Interfaces.Services;
using WitcherWorld.Domain.Entities;

namespace WitcherWorld.Application.Services;

public class CharacterService : ICharacterService
{
    private readonly ICharacterRepository _characterRepository;

    public CharacterService(ICharacterRepository characterRepository)
    {
        _characterRepository = characterRepository;
    }

    public async Task<IReadOnlyList<Character>> GetAllAsync()
    {
        return await _characterRepository.GetAllAsync();
    }
}
