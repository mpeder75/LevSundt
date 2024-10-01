﻿using LevSundt.Bmi.Application.Queries.Dto;
using LevSundt.Bmi.Domain.Model;

namespace LevSundt.Bmi.Application.Repositories;

public interface IBmiRepository
{
    void Add(BmiEntity bmi);
    IEnumerable<BmiQueryResultDto> GetAll();
    BmiEntity Load(int id);
    void Update(BmiEntity model);
    BmiQueryResultDto Get(int id);
}