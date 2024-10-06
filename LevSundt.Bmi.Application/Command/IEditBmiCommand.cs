using LevSundt.Bmi.Application.Command.Dto;

namespace LevSundt.Bmi.Application.Command;

public interface IEditBmiCommand
{
    void Edit(BmiEditRequestDto bmiEditRequestDto);
}