using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Survey1.Models;

namespace Survey1.Controllers;

public class HomeController : Controller
{
    static Survey NewUser;
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }
    [HttpGet("")]
    public IActionResult Index()
    {
        return View();
    }
    [HttpPost("process")]
    public IActionResult Privacy(Survey user)
    {
        NewUser = user;
        return RedirectToAction("Result");
    }
    [HttpGet("result")]
    public IActionResult Result()
    {
        return View(NewUser);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
