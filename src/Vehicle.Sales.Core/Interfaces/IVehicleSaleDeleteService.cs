using Vehicle.Sales.Core.VehicleSaleAggregate;

namespace Vehicle.Sales.Core.Interfaces
{
    public interface IVehicleSaleDeleteService
    {
        Task DeleteAllVehicleSales(CancellationToken cancellationToken);
    }
}
