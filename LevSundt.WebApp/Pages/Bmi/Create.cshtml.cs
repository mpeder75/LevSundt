using LevSundt.Bmi.Application.Command;
using LevSundt.Bmi.Application.Command.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LevSundt.WebApp.Pages.Bmi;

public class CreateModel : PageModel
{
    private readonly ICreateBmiCommand _createBmiCommand;
    
    [BindProperty]
    public BmiCreateViewModel BmiCreateViewModel { get; set; } = new();


    public CreateModel(ICreateBmiCommand createBmiCommand)
    {
        _createBmiCommand = createBmiCommand;
    }
    
    public void OnGet()
    {
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)  return Page(); 

        // Opretter en dto ud fra BmiCreateReview model
        var dto = new BmiCreateRequestDto
        {
            Height = BmiCreateViewModel.Height.Value,
            Weight = BmiCreateViewModel.Weight.Value
        };

        // N�r deto er oprettet sendes den med som parameter i _createBmiComman
        _createBmiCommand.Create(dto);

        // N�r bmi er oprettet sendes brugeren tilbage til index siden
        return new RedirectToPageResult("/Bmi/Index");
    }
}


