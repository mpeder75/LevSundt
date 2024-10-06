using LevSundt.WebApp.Infrastructure.Contract;
using LevSundt.WebApp.Infrastructure.Implementation;
using LevSundt.WebApp.UserContext;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// -----------------------EF Core------------------------

var connectionString = builder.Configuration.GetConnectionString("WebAppUserDbConnection");

// Add-Migration InitialCreate -Context WebAppUserDbContext -Project LevSundt.WebApp.UserContext.Migrations
// Update-Database -Context WebAppUserDbContext
builder.Services.AddDbContext<WebAppUserDbContext>(options =>
    options.UseSqlServer(connectionString + ";TrustServerCertificate=True",
        x => x.MigrationsAssembly("LevSundt.WebApp.UserContext.Migrations")));
// -----------------------EF Core-----------------------

// Her opsættes en rolle Coach
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("CoachPolicy", policyBuilder => policyBuilder.RequireClaim("Coach"));
});

// Her opsættes Identity
builder.Services.AddRazorPages(options =>
{
    // man skal være logget ind for at tilgå BMI folderen
    options.Conventions.AuthorizeFolder("/Bmi/");
    // man skal være logget ind som Coach, for at tilgå Coach folderen
    options.Conventions.AuthorizeFolder("/Coach/", "CoachPolicy");
});

// Opsætning af HttpClient til at kommunikere med API'et
builder.Services.AddHttpClient<ILevSundtService, LevSundtService>(client =>
{
    // Opsætning af base address til API'et - sættes præcist i appSettings.json
    client.BaseAddress = new Uri(builder.Configuration["LevSundtBaseUrl"]);
});


// Configure Identity
builder.Services.AddDefaultIdentity<IdentityUser>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequiredLength = 5;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredUniqueChars = 0;
    options.Password.RequireUppercase = false;
    options.SignIn.RequireConfirmedAccount = false;
}).AddEntityFrameworkStores<WebAppUserDbContext>();

var app = builder.Build();

// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapRazorPages();
app.Run();