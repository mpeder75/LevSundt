namespace LevSundt.WebApp.Infrastructure.Contract.Dto;

public class BmiCreateRequestDto
{
    // Dto skal kunne sættes frit, derfor er settere public
    public double Height { get; set; }
    public double Weight { get; set; }
    public string UserId { get; set; }
}