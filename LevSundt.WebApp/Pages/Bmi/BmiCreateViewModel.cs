using System.ComponentModel.DataAnnotations;

namespace LevSundt.WebApp.Pages.Bmi;

public class BmiCreateViewModel
{
    // Acceptalbe højdde er [100 - 250]
    // Acceptabel vægt er [40.0 - 250.0]

    [Range(100, 250)] public double? Height { get; set; }

    [Range(40.0, 250.0)] public double? Weight { get; set; }
}