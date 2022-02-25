using Vehicle.Sales.Core.VehicleSaleAggregate;

namespace Vehicle.Sales.Core.Interfaces
{
    public interface IVehicleSaleCreateService
    {
        Task<VehicleSale> CreateVehicleSale(VehicleSale newVehicleSale, CancellationToken cancellationToken);
    }
}
