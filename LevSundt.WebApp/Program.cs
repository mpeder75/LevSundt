using LevSundt.Bmi.Application.Command;
using LevSundt.Bmi.Application.Queries;
using LevSundt.Bmi.Application.Repositories;
using LevSundt.Bmi.Infrastructure.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

// Tilføjer create command til DI container
builder.Services.AddScoped<ICreateBmiCommand, CreateBmiCommand>();
// Tilføjer repository til DI container
builder.Services.AddScoped<IBmiRepository, BmiRepository>();
// Tilføjer get all query til DI container
builder.Services.AddScoped<IBmiGetAllQuery, BmiGetAllQuery>();
// Tilføjer edit command til DI container
builder.Services.AddScoped<IEditBmiCommand, EditBmiCommand>();
// Tilføjer get query til DI container
builder.Services.AddScoped<IBmiGetQuery, BmiGetQuery>();

var app = builder.Build();

// Configure the HTTP request pipeline.
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
