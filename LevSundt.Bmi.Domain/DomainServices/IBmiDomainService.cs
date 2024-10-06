namespace LevSundt.Bmi.Domain.DomainServices;

public interface IBmiDomainService
{
    bool BmiExistsOnDate(DateTime date, string userId);
}