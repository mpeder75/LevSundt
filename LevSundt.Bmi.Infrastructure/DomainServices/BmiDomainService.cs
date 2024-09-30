using LevSundt.Bmi.Domain.DomainServices;
using LevSundt.Bmi.Infrastructure.Repository;

namespace LevSundt.Bmi.Infrastructure.DomainServices;

public class BmiDomainService : IBmiDomainService
{

    bool IBmiDomainService.BmiExistsOnDate(DateTime date, int id)
    {
        return BmiRepository._database.Values.Any(a => a.Date.Date == date.Date && a.Id == id );
    }
}