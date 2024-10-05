using LevSundt.Bmi.Domain.DomainServices;
using LevSundt.SqlServerContext;
using Microsoft.EntityFrameworkCore;

namespace LevSundt.Bmi.Infrastructure.DomainServices;

public class BmiDomainService : IBmiDomainService
{
    private readonly LevSundtContext _db;

    public BmiDomainService(LevSundtContext db)
    {
        _db = db;
    }

    bool IBmiDomainService.BmiExistsOnDate(DateTime date, string userId)
    {
        return _db.BmiEntities.AsNoTracking().ToList().Any(a => a.Date.Date == date.Date && a.UserId == userId);
    }
}