using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LevSundt.Bmi.Application.Queries.Dto;

namespace LevSundt.Bmi.Application.Queries
{
    public interface IBmiGetQuery
    {
        BmiQueryResultDto Get(int id);
    }
}
