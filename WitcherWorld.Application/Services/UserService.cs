using WitcherWorld.Application.Validators;
using WitcherWorld.Application.DTOs;
using WitcherWorld.Application.Interfaces.Repositories;
using WitcherWorld.Application.Interfaces.Services;
using WitcherWorld.Domain.Entities;

namespace WitcherWorld.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    private readonly UserValidator _validator;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
        _validator = new UserValidator();
    }

    public async Task<(bool Success, string Message)> RegisterAsync(
        RegisterUserDto dto)
    {
        var validation = _validator.ValidateRegistration(dto);

        if (!validation.IsValid)
        {
            return (false, validation.ErrorMessage);
        }

        if (string.IsNullOrWhiteSpace(dto.Username) ||
            string.IsNullOrWhiteSpace(dto.Email) ||
            string.IsNullOrWhiteSpace(dto.Password))
        {
            return (false, "Заполните все обязательные поля.");
        }

        if (dto.Password != dto.ConfirmPassword)
        {
            return (false, "Пароли не совпадают.");
        }

        if (await _userRepository.ExistsByEmailAsync(dto.Email))
        {
            return (false, "Пользователь с такой почтой уже существует.");
        }

        if (await _userRepository.ExistsByUsernameAsync(dto.Username))
        {
            return (false, "Это имя пользователя уже занято.");
        }

        var user = new User
        {
            Username = dto.Username.Trim(),
            Email = dto.Email.Trim().ToLowerInvariant(),
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password),
            Role = "User",
            IsActive = true
        };

        await _userRepository.AddAsync(user);

        return (true, "Регистрация успешно завершена.");
    }

    public async Task<User?> LoginAsync(LoginUserDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.Login) ||
            string.IsNullOrWhiteSpace(dto.Password))
        {
            return null;
        }

        var login = dto.Login.Trim();

        User? user;

        if (login.Contains('@'))
        {
            user = await _userRepository.GetByEmailAsync(
                login.ToLowerInvariant());
        }
        else
        {
            user = await _userRepository.GetByUsernameAsync(login);
        }

        if (user == null || !user.IsActive)
        {
            return null;
        }

        bool passwordValid = BCrypt.Net.BCrypt.Verify(
            dto.Password,
            user.PasswordHash);

        return passwordValid ? user : null;
    }
}
