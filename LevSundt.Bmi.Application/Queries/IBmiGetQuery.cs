using LevSundt.Bmi.Application.Queries.Dto;

namespace LevSundt.Bmi.Application.Queries;

public interface IBmiGetQuery
{
    BmiQueryResultDto Get(int id, string userId);
}