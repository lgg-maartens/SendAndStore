using System.ComponentModel.DataAnnotations;

namespace SendAndStore.Models
{
  public class Person
  {
    [Required(ErrorMessage = "Gelieve uw voornaam in te vullen")]
    [Display(Name = "Voornaam")]
    public string FirstName { get; set; }
    
    [Required(ErrorMessage = "Achternaam is een verplicht veld")]
    [Display(Name = "Achternaam")]
    public string LastName { get; set; }

    [Required(ErrorMessage = "Emailadres is verplicht")]
    [EmailAddress(ErrorMessage = "Geen geldig email adres")]
    public string Email { get; set; }
    
    public string Password { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }

    [Required(ErrorMessage = "Bericht is verplicht")]
    [Display(Name = "Bericht")]
    public string Description { get; set; }
  }
}
