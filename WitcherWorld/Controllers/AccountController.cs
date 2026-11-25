using Microsoft.AspNetCore.Mvc;
using WitcherWorld.Application.DTOs;
using WitcherWorld.Application.Interfaces.Services;

namespace WitcherWorld.Controllers;

public class AccountController : Controller
{
    private readonly IUserService _userService;

    public AccountController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register(RegisterUserDto dto)
    {
        var result = await _userService.RegisterAsync(dto);

        if (!result.Success)
        {
            ViewBag.Error = result.Message;
            return View(dto);
        }

        TempData["Success"] = result.Message;

        return RedirectToAction("Login");
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginUserDto dto)
    {
        var user = await _userService.LoginAsync(dto);

        if (user == null)
        {
            ViewBag.Error = "Неверный логин или пароль.";
            return View(dto);
        }

        HttpContext.Session.SetInt32("UserId", user.Id);
        HttpContext.Session.SetString("Username", user.Username);
        HttpContext.Session.SetString("UserRole", user.Role);

        return RedirectToAction("Index", "Home");
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();

        return RedirectToAction("Index", "Home");
    }
}
