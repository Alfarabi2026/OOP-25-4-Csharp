using WitcherWorld.Application.DTOs;
using WitcherWorld.Domain.Entities;

namespace WitcherWorld.Application.Interfaces.Services;

public interface IUserService
{
    Task<(bool Success, string Message)> RegisterAsync(
        RegisterUserDto dto);

    Task<User?> LoginAsync(LoginUserDto dto);
}
