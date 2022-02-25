using Vehicle.Sales.Core.VehicleSaleAggregate;
using Vehicle.Sales.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace Vehicle.Sales.IntegrationTests.Data
{
    public abstract class BaseEfRepoTestFixture
    {
        protected AppDbContext _dbContext;

        protected BaseEfRepoTestFixture()
        {
            var options = CreateNewContextOptions();
            var mockMediator = new Mock<IMediator>();

            _dbContext = new AppDbContext(options, mockMediator.Object);
        }

        protected static DbContextOptions<AppDbContext> CreateNewContextOptions()
        {
            // Create a fresh service provider, and therefore a fresh
            // InMemory database instance.
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();
            
            // Create a new options instance telling the context to use an
            // InMemory database and the new service provider.
            var builder = new DbContextOptionsBuilder<AppDbContext>();
                builder.UseInMemoryDatabase("vehiclesales")
                       .UseInternalServiceProvider(serviceProvider);

            return builder.Options;
        }

        protected EfRepository<VehicleSale> GetRepository()
        {
            return new EfRepository<VehicleSale>(_dbContext);
        }
    }
}
