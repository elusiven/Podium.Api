using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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