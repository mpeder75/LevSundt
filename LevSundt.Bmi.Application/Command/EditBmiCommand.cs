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
        // Load - Her henter vi modellen fra databasen basert på id og userId
        var model = _repository.Load(requestDto.Id, requestDto.UserId);

        // Do
        model.Edit(requestDto.Height, requestDto.Weight, requestDto.RowVersion);

        // Update
        _repository.Update(model);
    }
}