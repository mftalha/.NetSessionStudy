using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Session.Extensions;
using Session.Models;

namespace Session.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {

        //var session = HttpContext.Session.GetString("UserSession"); == düz mantık SetString diyerek atılan sesion verisinin key'i ile çekmek için.

        var session = HttpContext.Session.Get<LoginModel>("UserSession");
        var sessionString = HttpContext.Session.Get<string>("StringTest");
        var sessionInt = HttpContext.Session.Get<int>("IntTest");

        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
