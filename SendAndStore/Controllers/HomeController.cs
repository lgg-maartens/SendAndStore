using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;
using SendAndStore.Models;
using System.Diagnostics;

namespace SendAndStore.Controllers
{
  public class HomeController : Controller
  {
    private readonly ILogger<HomeController> _logger;
    private readonly string connectionString = "Server=172.16.160.21;Port=3306;Database=fastfood;Uid=lgg;Pwd=smurf;";


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
      if (ModelState.IsValid) {
        // alle benodigde gegevens zijn aanwezig, we kunnen opslaan!
        SavePerson(person);

        return Redirect("/succes");
      }

      // niet goed? Dan sturen we de gegevens door naar de view zodat we de fouten kunnen tonen
      return View(person);
    }

    [Route("succes")]
    public IActionResult Succes()
    {
      return View();
    }

    private void SavePerson(Person person)
    {
      using (MySqlConnection conn = new MySqlConnection(connectionString))
      {
        conn.Open();
        MySqlCommand cmd = new MySqlCommand("INSERT INTO klant(voornaam, achternaam, email, bericht) VALUES(?voornaam, ?achternaam, ?email, ?bericht)", conn);

        cmd.Parameters.Add("?voornaam", MySqlDbType.Text).Value = person.FirstName;
        cmd.Parameters.Add("?achternaam", MySqlDbType.Text).Value = person.LastName;
        cmd.Parameters.Add("?email", MySqlDbType.Text).Value = person.Email;
        cmd.Parameters.Add("?bericht", MySqlDbType.Text).Value = person.Description;
        cmd.ExecuteNonQuery();
      }
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
      return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
  }
}
