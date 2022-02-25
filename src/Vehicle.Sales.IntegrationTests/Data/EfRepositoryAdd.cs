using System;
using System.Linq;
using System.Threading.Tasks;
using Vehicle.Sales.Core.Interfaces;
using Vehicle.Sales.Core.VehicleSaleAggregate;
using Xunit;

namespace Vehicle.Sales.IntegrationTests.Data
{
    public class EfRepositoryAdd : BaseEfRepoTestFixture
    {
        [Fact]
        public async Task Should_adds_vehicle_sale_and_sets_id()
        {
            var vehicleSale = new VehicleSale(1234, "Leandro", "Ford Marcas", "2022 Tucson", 30000, DateTime.Now);

            var repository = GetRepository();
            await repository.AddAsync(vehicleSale);

            var newVehicleSale = (await repository.ListAsync())
                .FirstOrDefault();

            Assert.Equal(vehicleSale.DealNumber, newVehicleSale?.DealNumber);
            Assert.Equal(vehicleSale.CustomerName, newVehicleSale?.CustomerName);
            Assert.True(newVehicleSale?.Id > 0);
        }

        [Fact]
        public async Task Should_delete_all_vehicle_sales()
        {
            var vehicleSale = new VehicleSale(1234, "Leandro", "Ford Marcas", "2022 Tucson", 30000, DateTime.Now);

            var repository = GetRepository();
            await repository.AddAsync(vehicleSale);

            var newVehicleSale = (await repository.ListAsync())
                .FirstOrDefault();

            Assert.Equal(vehicleSale.DealNumber, newVehicleSale?.DealNumber);
            Assert.Equal(vehicleSale.CustomerName, newVehicleSale?.CustomerName);
            Assert.True(newVehicleSale?.Id > 0);

            var vehicleSales = await repository.ListAsync();

            await repository.DeleteRangeAsync(vehicleSales);

            var checkListVehicleSale = await repository.ListAsync();

            Assert.Empty(checkListVehicleSale);
        }
    }
}
