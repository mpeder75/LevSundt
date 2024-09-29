using LevSundt.Bmi.Application.Queries;
using LevSundt.Bmi.Application.Queries.Dto;
using LevSundt.Bmi.Application.Repositories;

namespace LevSundt.Bmi.Application.Command;

public class BmiGetQuery : IBmiGetQuery
{
    private readonly IBmiRepository _repository;

    public BmiGetQuery(IBmiRepository repository)
    {
        _repository = repository;
    }

    BmiQueryResultDto IBmiGetQuery.Get(int id)
    {
        return _repository.Get(id);
    }
}