using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SendAndStore.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SendAndStore.Controllers
{
  public class HomeController : Controller
  {
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
      _logger = logger;
    }

    public IActionResult Index()
    {
      return View();
    }

    public IActionResult Contact()
    {
      return View();
    }

    [HttpPost]
    public IActionResult Contact(Person person)
    {
      // hebben we alles goed ingevuld? Dan sturen we de gebruiker door naar de succes pagina
      if (ModelState.IsValid)
        return Redirect("/succes");

      // niet goed? Dan sturen we de gegevens door naar de view zodat we de fouten kunnen tonen
      return View(person);
    }

    [Route("succes")]
    public IActionResult Succes()
    {
      return View();
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
      return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
  }
}
