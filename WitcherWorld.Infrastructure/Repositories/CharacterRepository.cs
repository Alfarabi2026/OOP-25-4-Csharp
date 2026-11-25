using Microsoft.EntityFrameworkCore;
using WitcherWorld.Application.Interfaces.Repositories;
using WitcherWorld.Domain.Entities;
using WitcherWorld.Infrastructure.Data;

namespace WitcherWorld.Infrastructure.Repositories;

public class CharacterRepository : ICharacterRepository
{
    private readonly WitcherWorldDbContext _context;

    public CharacterRepository(WitcherWorldDbContext context)
    {
        _context = context;
    }

    public async Task<IReadOnlyList<Character>> GetAllAsync()
    {
        return await _context.Characters
            .AsNoTracking()
            .OrderBy(character => character.Id)
            .ToListAsync();
    }
}
