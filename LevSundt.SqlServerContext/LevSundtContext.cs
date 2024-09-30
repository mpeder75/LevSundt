using LevSundt.Bmi.Domain.Model;
using LevSundt.SqlServerContext.BmiConfiguration;
using Microsoft.EntityFrameworkCore;

namespace LevSundt.SqlServerContext;

public class LevSundtContext : DbContext
{
    public DbSet<BmiEntity> BmiEntities { get; set; }

    public LevSundtContext(DbContextOptions<LevSundtContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new BmiTypeConfiguration());
    }
}