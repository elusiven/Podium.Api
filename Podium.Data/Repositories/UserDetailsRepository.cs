using Podium.Data.Abstractions;
using Podium.Data.Primitives.Entities;

namespace Podium.Data.Repositories
{
    public class UserDetailsRepository : BaseRepository<UserDetails>, IUserDetailsRepository
    {
        public UserDetailsRepository(PodiumDbContext databaseContext) : base(databaseContext)
        {
        }
    }
}