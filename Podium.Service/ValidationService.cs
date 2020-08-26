using Podium.Service.Abstractions;
using System;

namespace Podium.Service
{
    public class ValidationService : IValidationService
    {
        /// <summary>
        /// Validates whether given date is over 18 years old
        /// </summary>
        /// <param name="birthday"></param>
        /// <returns>True or false</returns>
        public bool ValidateAdultAge(DateTime birthday)
        {
            var today = DateTime.Today;
            var age = today.Year - birthday.Year;
            if (birthday.Date > today.AddYears(-age)) age--;
            return age >= 18;
        }
    }
}