using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Podium.Service.Primitives.Models.LoanCalculation;
using Podium.Service.Primitives.Models.Product;

namespace Podium.Service.Abstractions
{
    public interface ILoanCalculationService
    {
        Task<List<ProductResourceModel>> CalculateLoansAsync(CreateLoanCalculationModel model);
    }
}