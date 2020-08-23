using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Podium.Data.Primitives.Entities
{
    public class Product
    {
        public string Id { get; set; }
        public string Lender { get; set; }
        public double InterestRate { get; set; }
        public Enums.LoanType LoanType { get; set; }
        public double LoanToValue { get; set; }
    }
}