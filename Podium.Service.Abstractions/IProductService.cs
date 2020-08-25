using Podium.Service.Primitives.Models.Product;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Podium.Service.Abstractions
{
    public interface IProductService
    {
        Task<HashSet<ProductResourceModel>> GetAll();

        Task<ProductResourceModel> Get(string id);
    }
}