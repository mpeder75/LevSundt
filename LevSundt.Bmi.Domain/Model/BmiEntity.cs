using System.ComponentModel.DataAnnotations;
using LevSundt.Bmi.Domain.DomainServices;

namespace LevSundt.Bmi.Domain.Model;

public class BmiEntity
{
    /// <summary>
    ///     Vi er IKKE interesseret i at man kan ændre i vores model, derfor er set private
    /// </summary>
    public double Height { get; private set; }
    public double Weight { get; private set; }
    public double Bmi { get; private set; }
    public string UserId { get; private set; }
    public int Id { get; }
    public DateTime Date { get; }
    private readonly IBmiDomainService _domainService;
    [Timestamp]
    public byte[] RowVersion { get; private set; }

    internal BmiEntity()
    {

    }

    public BmiEntity(IBmiDomainService domainService,double height, double weight, string userId)
    {
        _domainService = domainService;
        // Check pre-conditions
        Height = height;
        Weight = weight;
        Date = DateTime.Now;
        UserId = userId;

        if (!IsValid()) throw new ArgumentException("Pre-conditions er ikke overholdt");
        if (_domainService.BmiExistsOnDate(Date.Date, UserId)) throw new ArgumentException("Pre-conditions er ikke overholdt");

        CalculateBmi();
    }

    /// <summary>
    ///     Acceptabel højde er (100; 250)
    ///     Acceptabel vægt er (40,0; 250,0)
    /// </summary>
    protected bool IsValid()
    {
        // Break fast princip
        if (Height < 100) return false;
        if (Height > 250) return false;
        if (Weight < 40) return false;
        if (Weight > 250) return false;

        return true;
    }

    protected void CalculateBmi()
    {
        Bmi = Weight / (Height / 100 * Height / 100);
    }

    public void Edit(double weight,double height, byte[] rowVersion)
    {
        Height = height;
        Weight = weight;
        RowVersion = rowVersion;

        if (!IsValid()) throw new ArgumentException("Pre-conditions er ikke overholdt");

        CalculateBmi();
    }
}