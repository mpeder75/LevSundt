using LevSundt.Bmi.Application.Queries.Dto;
using LevSundt.Bmi.Application.Repositories;
using LevSundt.Bmi.Domain.Model;

namespace LevSundt.Bmi.Infrastructure.Repository;

public class BmiRepository : IBmiRepository
{
    public static readonly Dictionary<int, BmiEntity> _database = new();

    void IBmiRepository.Add(BmiEntity bmi)
    {
        _database.Add(bmi.Id, bmi);
    }

    int IBmiRepository.GetNextKey()
    {
        if (!_database.Keys.Any()) return 1;

        return _database.Keys.Max() + 1;
    }

    IEnumerable<BmiQueryResultDto> IBmiRepository.GetAll()
    {
        foreach (var entity in _database.Values)
            yield return new BmiQueryResultDto
            {
                Height = entity.Height,
                Weight = entity.Weight,
                Bmi = entity.Bmi,
                Id = entity.Id
            };
    }

    BmiEntity IBmiRepository.Load(int id)
    {
        return _database[id];
    }

    void IBmiRepository.Update(BmiEntity model)
    {
        // Her settes model til at være den nye værdi for den eksisterende model
        _database[model.Id] = model;
    }

    BmiQueryResultDto IBmiRepository.Get(int id)
    {
        var dbEntity = _database[id];

        return new BmiQueryResultDto
        {
            Height = dbEntity.Height,
            Weight = dbEntity.Weight,
            Bmi = dbEntity.Bmi,
            Id = dbEntity.Id
        };
    }
}