using Podium.Shared;
using System.ComponentModel.DataAnnotations.Schema;

namespace Podium.Data.Primitives.Entities
{
    public class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        public string Lender { get; set; }
        public decimal InterestRate { get; set; }
        public Enums.LoanType LoanType { get; set; }
        public decimal LoanToValue { get; set; }
    }
}