using Podium.Data.Abstractions;
using Podium.Data.Primitives.Entities;

namespace Podium.Data.Repositories
{
    public class PropertyDetailsRepository : BaseRepository<PropertyDetails>, IPropertyDetailsRepository
    {
        public PropertyDetailsRepository(PodiumDbContext databaseContext) : base(databaseContext)
        {
        }
    }
}