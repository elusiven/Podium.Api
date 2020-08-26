using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Podium.Service.Primitives.Models.PropertyDetail;

namespace Podium.Service.Primitives.Models.UserDetail
{
    public class UserDetailResourceModel
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }

        public IEnumerable<PropertyDetailResourceModel> PropertyDetails { get; set; }
    }
}