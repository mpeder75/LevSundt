﻿using LevSundt.Bmi.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LevSundt.SqlServerContext.BmiConfiguration;

public class BmiTypeConfiguration : IEntityTypeConfiguration<BmiEntity>
{
    void IEntityTypeConfiguration<BmiEntity>.Configure(EntityTypeBuilder<BmiEntity> builder)
    {
        builder.ToTable("Bmi", "bmi");
        builder.HasKey(x => x.Id);
    }
}

