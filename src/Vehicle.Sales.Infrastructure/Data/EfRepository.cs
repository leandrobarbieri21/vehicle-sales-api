using Vehicle.Sales.Shared;
using Vehicle.Sales.Shared.Interfaces;

namespace Vehicle.Sales.Infrastructure.Data
{
    public class EfRepository<T> : RepositoryBase<T>, IReadRepositoryBase<T>, IRepositoryBase<T> where T : class
    {
        public EfRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
