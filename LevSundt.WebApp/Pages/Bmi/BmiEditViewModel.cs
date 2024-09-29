using System.ComponentModel.DataAnnotations;

namespace LevSundt.WebApp.Pages.Bmi;

public class BmiEditViewModel
{
   // Properties må ikke være null, da det jo er her vi skal ændre deres data

    [Range(100, 250)]
    public double Height { get; set; }

    [Range(40.0, 250.0)]
    public double Weight { get; set; }

    public int Id { get; set; }
}

