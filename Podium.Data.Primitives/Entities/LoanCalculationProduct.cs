using System.ComponentModel.DataAnnotations.Schema;

namespace Podium.Data.Primitives.Entities
{
    public class LoanCalculationProduct
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        public string LoanCalculationId { get; set; }
        public string ProductId { get; set; }
    }
}