using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Podium.Service.Primitives.Models.UserDetail;

namespace Podium.Service.Abstractions
{
    public interface IUserDetailService
    {
        Task<UserDetailResourceModel> GetById(string id);

        Task<HashSet<UserDetailResourceModel>> GetAll();

        Task<UserDetailResourceModel> Create(CreateUserDetailModel model);
    }
}