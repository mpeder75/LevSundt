using LevSundt.Bmi.Application.Command;
using LevSundt.Bmi.Application.Queries;
using LevSundt.Bmi.Application.Repositories;
using LevSundt.Bmi.Domain.DomainServices;
using LevSundt.Bmi.Infrastructure.DomainServices;
using LevSundt.Bmi.Infrastructure.Repository;
using LevSundt.SqlServerContext;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ICreateBmiCommand, CreateBmiCommand>();
builder.Services.AddScoped<IBmiRepository, BmiRepository>();
builder.Services.AddScoped<IBmiGetAllQuery, BmiGetAllQuery>();
builder.Services.AddScoped<IEditBmiCommand, EditBmiCommand>();
builder.Services.AddScoped<IBmiGetQuery, BmiGetQuery>();
builder.Services.AddScoped<IBmiDomainService, BmiDomainService>();

// Add-Migration userMigration -Context LevSundtContext -Project LevSundt.SqlServerContext.Migrations
// Update-Database -Context LevSundtContext
builder.Services.AddDbContext<LevSundtContext>(
    options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("LevSundtDbConnection") + ";TrustServerCertificate=True",
        x => x.MigrationsAssembly("LevSundt.SqlServerContext.Migrations")));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();