
using Vehicle.Sales.Core.Interfaces;
using Vehicle.Sales.Core.VehicleSaleAggregate;
using Vehicle.Sales.Shared.Interfaces;

namespace Vehicle.Sales.Core.Services
{
    public class VehicleSaleCreateService : IVehicleSaleCreateService
    {
        private readonly IRepositoryBase<VehicleSale> _repository;

        public VehicleSaleCreateService(IRepositoryBase<VehicleSale> repository)
        {
            _repository = repository;
        }

        public Task<VehicleSale> CreateVehicleSale(VehicleSale newVehicleSale, CancellationToken cancellationToken)
        {
            return _repository.AddAsync(newVehicleSale, cancellationToken);
        }
    }
}
