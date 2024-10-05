using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevSundt.Bmi.Domain.DomainServices
{
    public interface IBmiDomainService
    {
        bool BmiExistsOnDate(DateTime date, string userId);
    }
}
