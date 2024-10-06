using LevSundt.WebApp.Infrastructure.Contract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LevSundt.WebApp.Pages.Bmi;

/// <summary>
///     CQS: IBmiGetAllQuery interface injecttes så man kan lave queries på db
///     CQS: IBmiGetAllQuery definere der skal returneres en IEnumerable
///     ViewModel: IndexViewModel er model Index benytter til at repræsentere data udfra
/// </summary>
public class IndexModel : PageModel
{
    private readonly ILevSundtService _levSundtService;
    [BindProperty] public List<BmiIndexViewModel> IndexViewModel { get; set; } = new();

    public IndexModel(ILevSundtService levSundtService)
    {
        _levSundtService = levSundtService;
    }

    public async Task OnGet()
    {
        var businessModel = await _levSundtService.GetAll(User.Identity?.Name ?? string.Empty);

        businessModel?.ToList().ForEach(dto => IndexViewModel.Add(new BmiIndexViewModel
            { Bmi = dto.Bmi, Weight = dto.Weight, Height = dto.Height, Id = dto.Id, Date = dto.Date }));
    }
}