using System.Collections.Generic;
using System.Threading.Tasks;
using Podium.Data.Abstractions;
using Podium.Data.Primitives.Entities;

namespace Podium.Data.Repositories
{
    public class LoanCalculationRepository : BaseRepository<LoanCalculation>, ILoanCalculationRepository
    {
        public LoanCalculationRepository(PodiumDbContext databaseContext) : base(databaseContext)
        {
        }
    }
}