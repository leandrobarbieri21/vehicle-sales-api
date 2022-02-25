
using Vehicle.Sales.Core.Interfaces;
using Vehicle.Sales.Core.VehicleSaleAggregate;
using Vehicle.Sales.Shared.Interfaces;

namespace Vehicle.Sales.Core.Services
{
    public class VehicleSaleSearchService : IVehicleSaleSearchService
    {
        private readonly IReadRepositoryBase<VehicleSale> _readRepository;

        public VehicleSaleSearchService(IReadRepositoryBase<VehicleSale> readRepository)
        {
            _readRepository = readRepository;
        }

        public Task<List<VehicleSale>> GetAllVehicleSales()
        {
            return _readRepository.ListAsync();
        }

        public async Task<string> GetVehicleSoldMostOften()
        {
            return (await _readRepository.ListAsync())
                .GroupBy(i => i.Vehicle)
                .OrderByDescending(grp => grp.Count())
                .Select(grp => grp.Key).FirstOrDefault() ?? "";
        }
    }
}
