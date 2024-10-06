using LevSundt.Bmi.Application.Queries.Dto;

namespace LevSundt.Bmi.Application.Queries;

public interface IBmiGetAllQuery
{
    IEnumerable<BmiQueryResultDto> GetAll(string userId);
}