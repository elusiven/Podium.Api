using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Podium.Service.Primitives.Models.LoanCalculation;

namespace Podium.Service.Abstractions
{
    public interface ILoanCalculationService
    {
        Task<LoanCalculationResourceModel> CalculateLoansAsync(CreateLoanCalculationModel model);
    }
}