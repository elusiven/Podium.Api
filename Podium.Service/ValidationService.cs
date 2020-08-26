using Podium.Service.Abstractions;
using System;

namespace Podium.Service
{
    public class ValidationService : IValidationService
    {
        public bool ValidateAdultAge(DateTime birthday)
        {
            var today = DateTime.Today;
            var age = today.Year - birthday.Year;
            if (birthday.Date > today.AddYears(-age)) age--;
            return age >= 18;
        }
    }
}