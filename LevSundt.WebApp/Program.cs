using LevSundt.Bmi.Application.Command;
using LevSundt.Bmi.Application.Queries;
using LevSundt.Bmi.Application.Repositories;
using LevSundt.Bmi.Domain.DomainServices;
using LevSundt.Bmi.Infrastructure.DomainServices;
using LevSundt.Bmi.Infrastructure.Repository;
using LevSundt.SqlServerContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using LevSundt.WebApp.UserContext;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

// Add services to the DI container
builder.Services.AddScoped<ICreateBmiCommand, CreateBmiCommand>();
builder.Services.AddScoped<IBmiRepository, BmiRepository>();
builder.Services.AddScoped<IBmiGetAllQuery, BmiGetAllQuery>();
builder.Services.AddScoped<IEditBmiCommand, EditBmiCommand>();
builder.Services.AddScoped<IBmiGetQuery, BmiGetQuery>();
builder.Services.AddScoped<IBmiDomainService, BmiDomainService>();

// ------------------------EF Core------------------------

// Configure EF Core
var connectionString = builder.Configuration.GetConnectionString("WebAppUserDbConnection");

/// <summary>
/// HUSK når du laver en ny migration, at du skal angive hvilket projekt migrations skal gemmes i
/// UserContext.Migrations ELLER 
/// 

// Add-Migration userMigration -Context LevSundtContext -Project LevSundt.SqlServerContext.Migrations
// Update-Database -Context LevSundtContext
builder.Services.AddDbContext<LevSundtContext>(options => 
    options.UseSqlServer(builder.Configuration.GetConnectionString("LevSundtDbConnection") + ";TrustServerCertificate=True",
        x => x.MigrationsAssembly("LevSundt.SqlServerContext.Migrations")));

// Add-Migration InitialCreate -Context WebAppUserDbContext -Project LevSundt.WebApp.UserContext.Migrations
// Update-Database -Context WebAppUserDbContext
builder.Services.AddDbContext<WebAppUserDbContext>(options => 
    options.UseSqlServer(connectionString + ";TrustServerCertificate=True",
        x => x.MigrationsAssembly("LevSundt.WebApp.UserContext.Migrations")));

// ------------------------EF Core------------------------


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
