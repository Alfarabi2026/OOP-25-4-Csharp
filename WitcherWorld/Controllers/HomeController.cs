using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WitcherWorld.Application.Interfaces.Services;
using WitcherWorld.Models;
using WitcherWorld.ViewModels;

namespace WitcherWorld.Controllers;

public class HomeController : Controller
{
    private readonly ICharacterService _characterService;

    public HomeController(ICharacterService characterService)
    {
        _characterService = characterService;
    }

    public async Task<IActionResult> Index()
    {
        var characters = await _characterService.GetAllAsync();

        var model = new HomeViewModel
        {
            Characters = characters.Select(character =>
                new CharacterCardViewModel
                {
                    Name = character.Name,
                    Title = character.Title,
                    Description = character.Description,
                    ImageUrl = character.ImageUrl
                }).ToList()
        };

        return View(model);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel
        {
            RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
        });
    }
}
