using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using LevSundt.Bmi.Application.Repositories;
using LevSundt.Bmi.Domain.Model;

namespace LevSundt.Bmi.Infrastructure.Repository
{
    public class BmiRepository : IBmiRepository
    {
        private Dictionary<int, BmiEntity> _database = new();

        void IBmiRepository.Add(BmiEntity bmi)
        {
            _database.Add(bmi.Id, bmi);
        }

        int IBmiRepository.GetNextKey()
        {
            if (!_database.Keys.Any()) return 1;

            return _database.Keys.Max() + 1;
        }
    }
}
