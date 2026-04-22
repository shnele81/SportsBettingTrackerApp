using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using SportsBettingTrackerApp.Data;
using SportsBettingTrackerApp.Models;

namespace SportsBettingTrackerApp.Controllers;

public class WagerController : Controller
{
    private readonly IWagerRepository _wagerRepository;

    public WagerController(IWagerRepository wagerRepository)
    {
        _wagerRepository = wagerRepository;
    }

    public IActionResult Index()
    {
        var wagers = _wagerRepository.GetWagersByFilter(null, null, null);
        return View(wagers);
    }

    [HttpGet]
    public IActionResult InsertWager()
    {
        return View();
    }

    [HttpPost]
    public IActionResult InsertWager(WagerModel model)
    {
        var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
        model.UserId = userId;
        _wagerRepository.InsertWager(model);
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult UpdateWager(int WagerId )
    {
        var wager = _wagerRepository.GetWagerById(WagerId);
        return View(wager);
    }

    [HttpPost]
    public IActionResult UpdateWager(WagerModel model)
    {
        var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
        model.UserId = userId;
        _wagerRepository.UpdateWager(model);
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult DeleteWager(int WagerId)
    {
        var wager = _wagerRepository.GetWagerById(WagerId);
        return View(wager);
    }

    [HttpPost]
    [ActionName("DeleteWager")]
    public IActionResult DeleteWagerConfirmed(int WagerId)
    {
        _wagerRepository.DeleteWager(WagerId);
        return RedirectToAction("Index");
    }

}