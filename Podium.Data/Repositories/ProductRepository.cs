using Podium.Data.Abstractions;
using Podium.Data.Primitives.Entities;

namespace Podium.Data.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(PodiumDbContext databaseContext) : base(databaseContext)
        {
        }
    }
}