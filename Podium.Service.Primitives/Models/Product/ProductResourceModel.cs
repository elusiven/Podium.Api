using Podium.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Podium.Service.Primitives.Models.Product
{
    public class ProductResourceModel
    {
        public string Id { get; set; }

        public string Lender { get; set; }
        public double InterestRate { get; set; }
        public Enums.LoanType LoanType { get; set; }
        public double LoanToValue { get; set; }
    }
}