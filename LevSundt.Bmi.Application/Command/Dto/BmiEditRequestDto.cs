namespace LevSundt.Bmi.Application.Command.Dto;

public class BmiEditRequestDto
{
    public double Height { get; set; }
    public double Weight { get; set; }
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public string UserId { get; set; }
    public byte[] RowVersion { get; set; }
}