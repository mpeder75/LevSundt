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

    void IEditBmiCommand.Edit(BmiEditRequestDto requestDto)
    {
        // Load
        var model = _repository.Load(requestDto.Id);

        // Do
        model.Edit(requestDto.Height, requestDto.Weight, requestDto.RowVersion);

        // Update
        _repository.Update(model);
    }
}