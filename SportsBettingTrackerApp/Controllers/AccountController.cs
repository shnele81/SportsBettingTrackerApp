using Microsoft.AspNetCore.Mvc;
using SportsBettingTrackerApp.Data;
using SportsBettingTrackerApp.Models;

namespace SportsBettingTrackerApp.Controllers;

public class AccountController : Controller
{
    
    private readonly IUserLoginInformationRepository _userRepository;

    public AccountController(IUserLoginInformationRepository userRepository)
    {
        _userRepository = userRepository;
    }

    [HttpGet] 
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(LoginViewModel model)
    {
        var user = _userRepository.GetUserByEmail(model.Email);
        if (user == null)
        {
            return View(model);
        }
        
        bool isValidPassword = BCrypt.Net.BCrypt.Verify(model.Password, user.PasswordHash);
        if (!isValidPassword)
        {
            return View(model);
        }
        
        return RedirectToAction("Index", "Home");
    }

    [HttpGet]
    public IActionResult SignUp()
    {
        return View();
    }

    [HttpPost]
    public IActionResult SignUp(RegisterViewModel model)
    {
        var passwordHash = BCrypt.Net.BCrypt.HashPassword(model.Password);
        var user = new UserModel(model.UserName, model.Email, passwordHash);
        _userRepository.InsertUser(user);
        return RedirectToAction("Login");
    }
}