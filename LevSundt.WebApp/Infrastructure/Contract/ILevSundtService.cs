using LevSundt.WebApp.Infrastructure.Contract.Dto;
using BmiCreateRequestDto = LevSundt.WebApp.Infrastructure.Contract.Dto.BmiCreateRequestDto;
using BmiEditRequestDto = LevSundt.WebApp.Infrastructure.Contract.Dto.BmiEditRequestDto;

namespace LevSundt.WebApp.Infrastructure.Contract;

public interface ILevSundtService
{
    Task Create(BmiCreateRequestDto dto);
    Task Edit(BmiEditRequestDto bmiEditRequestDto);
    Task<BmiQueryResultDto?> Get(int id, string userId);
    Task<IEnumerable<BmiQueryResultDto>?> GetAll(string userId);
}