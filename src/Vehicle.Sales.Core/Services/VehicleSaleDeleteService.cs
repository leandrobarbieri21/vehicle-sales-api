
using Vehicle.Sales.Core.Interfaces;
using Vehicle.Sales.Core.VehicleSaleAggregate;
using Vehicle.Sales.Shared.Interfaces;

namespace Vehicle.Sales.Core.Services
{
    public class VehicleSaleDeleteService : IVehicleSaleDeleteService
    {
        private readonly IRepositoryBase<VehicleSale> _repository;
        private readonly IReadRepositoryBase<VehicleSale> _readRepository;

        public VehicleSaleDeleteService(IRepositoryBase<VehicleSale> repository,
                                        IReadRepositoryBase<VehicleSale> readRepository)
        {
            _repository = repository;
            _readRepository = readRepository;
        }

        public async Task DeleteAllVehicleSales(CancellationToken cancellationToken)
        {
            var vehicleSales = await _readRepository.ListAsync(cancellationToken);
            await _repository.DeleteRangeAsync(vehicleSales, cancellationToken);
        }
    }
}
