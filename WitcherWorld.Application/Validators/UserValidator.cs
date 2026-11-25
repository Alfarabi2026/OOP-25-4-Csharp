using System.Text.RegularExpressions;
using WitcherWorld.Application.DTOs;

namespace WitcherWorld.Application.Validators;

public class UserValidator
{
    public (bool IsValid, string ErrorMessage) ValidateRegistration(
        RegisterUserDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.Username))
            return (false, "Введите имя пользователя.");

        if (!Regex.IsMatch(dto.Username, @"^[a-zA-Z0-9_]{3,20}$"))
            return (false,
                "Имя должно содержать 3–20 символов: латинские буквы, цифры или _.");

        if (string.IsNullOrWhiteSpace(dto.Email))
            return (false, "Введите Email.");

        if (!Regex.IsMatch(dto.Email,
            @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            return (false, "Некорректный Email.");

        if (string.IsNullOrWhiteSpace(dto.Password))
            return (false, "Введите пароль.");

        if (!Regex.IsMatch(dto.Password,
            @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^a-zA-Z0-9]).{8,}$"))
            return (false,
                "Пароль должен содержать минимум 8 символов, заглавную и строчную букву, цифру и специальный символ.");

        if (dto.Password != dto.ConfirmPassword)
            return (false, "Пароли не совпадают.");

        return (true, string.Empty);
    }
}
