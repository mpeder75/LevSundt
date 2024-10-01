using LevSundt.Bmi.Application.Command;
using LevSundt.Bmi.Application.Command.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LevSundt.WebApp.Pages.Bmi;

public class CreateModel : PageModel
{
    private readonly ICreateBmiCommand _createBmiCommand;
    
    [BindProperty]
    public BmiCreateViewModel BmiModel { get; set; } = new();


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
            Height = BmiModel.Height.Value,
            Weight = BmiModel.Weight.Value,
            UserId = User.Identity?.Name ?? string.Empty
        };

        // Når deto er oprettet sendes den med som parameter i _createBmiComman
        _createBmiCommand.Create(dto);

        // Når bmi er oprettet sendes brugeren tilbage til index siden
        return new RedirectToPageResult("/Bmi/Index");
    }
}


