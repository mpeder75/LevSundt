using LevSundt.Bmi.Application.Queries.Dto;
using LevSundt.Bmi.Application.Repositories;
using LevSundt.Bmi.Domain.Model;
using LevSundt.SqlServerContext;
using Microsoft.EntityFrameworkCore;

namespace LevSundt.Bmi.Infrastructure.Repository;

public class BmiRepository : IBmiRepository
{
    private readonly LevSundtContext _db;

    public BmiRepository(LevSundtContext db)
    {
        _db = db;
    }

    void IBmiRepository.Add(BmiEntity bmi)
    {
        _db.Add(bmi);
        _db.SaveChanges();
    }

    IEnumerable<BmiQueryResultDto> IBmiRepository.GetAll(string userId)
    {
        foreach (var entity in _db.BmiEntities.AsNoTracking().Where(x => x.UserId == userId).ToList())
            yield return new BmiQueryResultDto
            {
                Bmi = entity.Bmi,
                Height = entity.Height,
                Weight = entity.Weight,
                Id = entity.Id,
                Date = entity.Date,
                RowVersion = entity.RowVersion
            };
    }

    BmiEntity IBmiRepository.Load(int id, string userId)
    {
        // når der loades, skal der bruges AsNoTracking, da vi ikke vil have EF til at tracke objektet
        // der søges efter om Id og UserId matcher
        var dbEntity = _db.BmiEntities.AsNoTracking().FirstOrDefault(x => x.Id == id && x.UserId == userId);

        if (dbEntity == null) throw new Exception("Bmi måling findes ikke i database");

        return dbEntity;
    }

    void IBmiRepository.Update(BmiEntity model)
    {
        // Update tager et objekt der IKKE er tracked af EF, men har en eksisterendne Id
        _db.Update(model);
        _db.SaveChanges();
    }

    BmiQueryResultDto IBmiRepository.Get(int id, string userId)
    {
        var dbEntity = _db.BmiEntities.AsNoTracking().FirstOrDefault(x => x.Id == id && x.UserId == userId);

        if (dbEntity == null) throw new Exception("Bmi måling findes ikke i database");

        return new BmiQueryResultDto
        {
            Height = dbEntity.Height,
            Weight = dbEntity.Weight,
            Bmi = dbEntity.Bmi,
            Id = dbEntity.Id,
            RowVersion = dbEntity.RowVersion
        };
    }
}