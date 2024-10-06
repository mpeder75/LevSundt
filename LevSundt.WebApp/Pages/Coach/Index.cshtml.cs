using LevSundt.WebApp.UserContext;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LevSundt.WebApp.Pages.Coach;

public class IndexModel : PageModel
{
    private readonly WebAppUserDbContext _userDb;

    // Liste af brugere
    public List<CoachIndexViewModel> Users { get; set; } = new();

    public IndexModel(WebAppUserDbContext userDb)
    {
        _userDb = userDb;
    }

    // OnGet()
    // Hent brugere der IKKE er at typen Coach
    // De må ikke haevven claimType != "Coach"
    public void OnGet()
    {
        var users = from user in _userDb.Users
            join claims in _userDb.UserClaims
                on user.Id equals claims.UserId
                into userClaimsGroup
            from claim in userClaimsGroup.DefaultIfEmpty()
            where claim.ClaimValue == null || claim.ClaimType != "Coach"
            select new CoachIndexViewModel { UserId = user.UserName };

        Users.AddRange(users);
    }
}