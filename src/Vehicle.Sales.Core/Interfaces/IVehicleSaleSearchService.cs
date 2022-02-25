using Vehicle.Sales.Core.VehicleSaleAggregate;

namespace Vehicle.Sales.Core.Interfaces
{
    public interface IVehicleSaleSearchService
    {
        Task<List<VehicleSale>> GetAllVehicleSales();
        Task<string> GetVehicleSoldMostOften();
    }
}
