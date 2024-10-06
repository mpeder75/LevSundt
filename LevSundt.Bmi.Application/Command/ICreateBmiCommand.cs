using LevSundt.Bmi.Application.Command.Dto;

namespace LevSundt.Bmi.Application.Command;

public interface ICreateBmiCommand
{
    void Create(BmiCreateRequestDto bmiCreateRequestDto);
}