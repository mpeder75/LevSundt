using LevSundt.Bmi.Application.Queries.Dto;
using LevSundt.Bmi.Application.Repositories;

namespace LevSundt.Bmi.Application.Queries;

public class BmiGetAllQuery : IBmiGetAllQuery
{
    private readonly IBmiRepository _repository;

    public BmiGetAllQuery(IBmiRepository repository)
    {
        _repository = repository;
    }

    IEnumerable<BmiQueryResultDto> IBmiGetAllQuery.GetAll(string userId)
    {
        return _repository.GetAll(userId);
    }
}