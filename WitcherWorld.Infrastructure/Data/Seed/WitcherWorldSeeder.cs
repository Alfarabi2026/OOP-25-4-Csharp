using Microsoft.EntityFrameworkCore;
using WitcherWorld.Domain.Entities;
using WitcherWorld.Infrastructure.Data;

namespace WitcherWorld.Infrastructure.Data.Seed;

public static class WitcherWorldSeeder
{
    public static async Task SeedAsync(WitcherWorldDbContext context)
    {
        // Добавляем персонажей
        if (!await context.Characters.AnyAsync())
        {
            context.Characters.AddRange(
                new Character
                {
                    ImageUrl = "/images/geralt.png",
                    Name = "Геральт из Ривии",
                    Title = "Белый Волк",
                    Description = "Главный герой игры, ведьмак из Школы Волка.",
                    Gender = "Мужской",
                    Race = "Человек",
                    Affiliation = "Школа Волка",
                    IsPlayable = true
                },
                new Character
                {
                    ImageUrl = "/images/yennefer.png",
                    Name = "Йеннифэр из Венгерберга",
                    Title = "Чародейка",
                    Description = "Могущественная чародейка и возлюбленная Геральта.",
                    Gender = "Женский",
                    Race = "Человек",
                    Affiliation = "Чародейки",
                    IsPlayable = false
                },
                new Character
                {
                    ImageUrl = "/images/ciri.png",
                    Name = "Цири",
                    Title = "Дитя Старшей Крови",
                    Description = "Приёмная дочь Геральта, обладающая необычными способностями.",
                    Gender = "Женский",
                    Race = "Человек",
                    Affiliation = "Школа Волка",
                    IsPlayable = true
                },
                new Character
                {
                    ImageUrl = "/images/triss.png",
                    Name = "Трисс Меригольд",
                    Title = "Чародейка",
                    Description = "Чародейка, подруга Геральта и Йеннифэр.",
                    Gender = "Женский",
                    Race = "Человек",
                    Affiliation = "Чародейки",
                    IsPlayable = false
                }
            );
        }

        // Добавляем категории
        if (!await context.Categories.AnyAsync())
        {
            context.Categories.AddRange(
                new Category
                {
                    Name = "Стальное оружие",
                    Description = "Оружие для сражения с людьми и обычными противниками."
                },
                new Category
                {
                    Name = "Серебряное оружие",
                    Description = "Оружие для охоты на чудовищ."
                },
                new Category
                {
                    Name = "Доспехи",
                    Description = "Защитное снаряжение ведьмака."
                }
            );
        }

        // Код обновления изображений персонажей находится здесь.
        var geralt = await context.Characters
    .FirstOrDefaultAsync(c => c.Name == "Геральт из Ривии");

        if (geralt != null)
            geralt.ImageUrl = "/images/geralt.png";

        var yennefer = await context.Characters
            .FirstOrDefaultAsync(c => c.Name == "Йеннифэр из Венгерберга");

        if (yennefer != null)
            yennefer.ImageUrl = "/images/yennefer.png";

        var ciri = await context.Characters
            .FirstOrDefaultAsync(c => c.Name == "Цири");

        if (ciri != null)
            ciri.ImageUrl = "/images/ciri.png";

        var triss = await context.Characters
            .FirstOrDefaultAsync(c => c.Name == "Трисс Меригольд");

        if (triss != null)
            triss.ImageUrl = "/images/triss.png";

        await context.SaveChangesAsync();
    }
}
