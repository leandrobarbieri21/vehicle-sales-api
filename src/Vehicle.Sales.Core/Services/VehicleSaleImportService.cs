
using Vehicle.Sales.Core.Interfaces;
using Vehicle.Sales.Core.VehicleSaleAggregate;
using Vehicle.Sales.Shared.Interfaces;

namespace Vehicle.Sales.Core.Services
{
    public class VehicleSaleImportService : IVehicleSaleImportService
    {
        private readonly IRepositoryBase<VehicleSale> _repository;
        private readonly IReadRepositoryBase<VehicleSale> _readRepository;

        public VehicleSaleImportService(IRepositoryBase<VehicleSale> repository,
                                        IReadRepositoryBase<VehicleSale> readRepository)
        {
            _repository = repository;
            _readRepository = readRepository;
        }

        public async Task ImportVehicleSalesFromFile(List<string> fileLines)
        {
            var vehicleSales = fileLines
                .Skip(1)
                .Select(line => VehicleSale.CreateFromCsvLine(line))
                .ToList();

            var existingVehicleSales = await _readRepository.ListAsync();

            vehicleSales.RemoveAll(x => existingVehicleSales.Exists(y => y.DealNumber == x.DealNumber));

            await _repository.AddRangeAsync(vehicleSales);
        }
    }
}
