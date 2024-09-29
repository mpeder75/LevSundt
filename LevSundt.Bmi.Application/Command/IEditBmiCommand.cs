using LevSundt.Bmi.Application.Command.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LevSundt.Bmi.Application.Command
{
    public interface IEditBmiCommand
    {
        void Edit(BmiEditRequestDto bmiEditRequestDto);
    }
    
}
