using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Podium.Data.Primitives.Entities
{
    public class LoanCalculation
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        public IEnumerable<Product> Products { get; set; }

        public string UserDetailsId { get; set; }
        public UserDetails UserDetails { get; set; }

        public string PropertyDetailsId { get; set; }
        public PropertyDetails PropertyDetails { get; set; }
    }
}