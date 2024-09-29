using LevSundt.Bmi.Application.Command.Dto;
using LevSundt.Bmi.Application.Repositories;

namespace LevSundt.Bmi.Application.Command;

public class EditBmiCommand : IEditBmiCommand
{
    private readonly IBmiRepository _repository;

    public EditBmiCommand(IBmiRepository repository)
    {
        _repository = repository;
    }

    void IEditBmiCommand.Edit(BmiEditRequestDto bmiEditRequestDto)
    {
        // Load
        var model = _repository.Load(bmiEditRequestDto.Id);

        // Do
        model.Edit(bmiEditRequestDto.Height, bmiEditRequestDto.Weight);

        // Update
        _repository.Update(model);

    }
}