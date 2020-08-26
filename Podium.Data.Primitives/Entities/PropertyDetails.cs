using System.ComponentModel.DataAnnotations.Schema;

namespace Podium.Data.Primitives.Entities
{
    public class PropertyDetails
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        public double PropertyValue { get; set; }
        public double DepositAmount { get; set; }
    }
}