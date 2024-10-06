using LevSundt.WebApp.Infrastructure.Contract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BmiEditRequestDto = LevSundt.WebApp.Infrastructure.Contract.Dto.BmiEditRequestDto;

namespace LevSundt.WebApp.Pages.Bmi;

public class EditModel : PageModel
{
    private readonly ILevSundtService _levSundtService;
    [BindProperty] public BmiEditViewModel BmiModel { get; set; }

    public EditModel(ILevSundtService levSundtService)
    {
        _levSundtService = levSundtService;
    }

    public async Task<IActionResult> OnPost()
    {
        if (!ModelState.IsValid) return Page();

        try
        {
            await _levSundtService.Edit(new BmiEditRequestDto
            {
                Height = BmiModel.Height,
                Id = BmiModel.Id,
                Weight = BmiModel.Weight,
                Date = BmiModel.Date,
                // Lost update håndteres med optimistic concurrency rowVersion
                RowVersion = BmiModel.RowVersion,
                UserId = User.Identity?.Name ?? string.Empty
            });

        }
        catch (Exception e)
        {
         ModelState.AddModelError(string.Empty, e.Message);
            return Page();
        }
        return new RedirectToPageResult("/Bmi/Index");
    }

    public async Task<IActionResult> OnGet(int? id)
    {
        if (id == null) return NotFound();

        // Hvis der ikke er en bruger logget ind, så sendes en tom string med
        var dto = await _levSundtService.Get(id.Value, User.Identity?.Name ?? string.Empty);

        BmiModel = new BmiEditViewModel
        {
            Height = BmiModel.Height,
            Id = BmiModel.Id,
            Weight = BmiModel.Weight,
            Date = BmiModel.Date,
            // Lost update håndteres med optimistic concurrency rowVersion
            RowVersion = BmiModel.RowVersion
        };
        return Page();
    }
}