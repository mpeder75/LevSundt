using System.Runtime.InteropServices.JavaScript;
using LevSundt.Bmi.Application.Command;
using LevSundt.Bmi.Application.Command.Dto;
using LevSundt.Bmi.Application.Queries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LevSundt.WebApp.Pages.Bmi;

public class EditModel : PageModel
{
    private readonly IEditBmiCommand _bmiCommand;
    private readonly IBmiGetQuery _query;
    [BindProperty] 
    public BmiEditViewModel BmiModel { get; set; }

    public EditModel(IEditBmiCommand bmiCommand, IBmiGetQuery query)
    {
        _bmiCommand = bmiCommand;
        _query = query;
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid) return Page();

        _bmiCommand.Edit(new BmiEditRequestDto
        {
            Height = BmiModel.Height, 
            Id = BmiModel.Id, 
            Weight = BmiModel.Weight,
            Date = BmiModel.Date,
            // Lost update håndteres med optimistic concurrency rowVersion
            RowVersion = BmiModel.RowVersion,
            UserId = User.Identity?.Name ?? String.Empty
        });
        return new RedirectToPageResult("/Bmi/Index");
    }

    public IActionResult OnGet(int? id)
    {
        if (id == null) return NotFound();

        // Hvis der ikke er en bruger logget ind, så sendes en tom string med
        var dto = _query.Get(id.Value, User.Identity?.Name ?? String.Empty);

        BmiModel = new BmiEditViewModel
        {
            Height = dto.Height, 
            Id = dto.Id, 
            Weight = dto.Weight,
            Date = dto.Date,
            // Lost update håndteres med optimistic concurrency rowVersion
            RowVersion = dto.RowVersion
        };
        return Page();
    }
}