using LevSundt.Bmi.Application.Queries;
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
    private readonly IBmiGetAllQuery _bmiGetAllQuery;
    [BindProperty] public List<BmiIndexViewModel> IndexViewModel { get; set; } = new();

    public IndexModel(IBmiGetAllQuery bmiGetAllQuery)
    {
        _bmiGetAllQuery = bmiGetAllQuery;
    }

    public void OnGet()
    {
        var businessModel = 
            _bmiGetAllQuery.GetAll( User.Identity?.Name ?? String.Empty);
        /* // Metode 1 : Manuelt mapning
        foreach (var dto in businessModel)
        {
            IndexViewModel.Add(new BmiIndexViewModel { 
                Bmi = dto.Bmi, 
                Weight  = dto.Weight,
                Height = dto.Height,
                Id = dto.Id});
        } */

        // Metode 2 : Mapping med Lampda & Linq
        // Business model konverteres til en list, derefter bruges en Foreach på List
        businessModel.ToList().ForEach(dto => IndexViewModel.Add(new BmiIndexViewModel
        {
            Bmi = dto.Bmi,
            Weight = dto.Weight, 
            Height = dto.Height, 
            Id = dto.Id,
            Date = dto.Date
        }));
    }
}