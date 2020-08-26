using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Podium.Service.Abstractions
{
    public interface IValidationService
    {
        bool ValidateAdultAge(DateTime birthday);
    }
}