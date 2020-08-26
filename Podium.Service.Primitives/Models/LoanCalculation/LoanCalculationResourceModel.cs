using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Podium.Service.Primitives.Models.Product;
using Podium.Service.Primitives.Models.PropertyDetail;
using Podium.Service.Primitives.Models.UserDetail;

namespace Podium.Service.Primitives.Models.LoanCalculation
{
    public class LoanCalculationResourceModel
    {
        public string Id { get; set; }

        public virtual IEnumerable<LoanCalculationProductModel> Products { get; set; }

        public string UserDetailsId { get; set; }
        public UserDetailResourceModel UserDetails { get; set; }

        public string PropertyDetailsId { get; set; }
        public PropertyDetailResourceModel PropertyDetails { get; set; }
    }
}