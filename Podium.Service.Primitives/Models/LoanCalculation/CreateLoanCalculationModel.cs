using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Podium.Service.Primitives.Models.PropertyDetail;

namespace Podium.Service.Primitives.Models.LoanCalculation
{
    public class CreateLoanCalculationModel
    {
        public PropertyDetailResourceModel PropertyDetail { get; set; }
        public string UserId { get; set; }
    }
}