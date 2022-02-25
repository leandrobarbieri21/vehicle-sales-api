namespace Vehicle.Sales.Core.Interfaces
{
    public interface IVehicleSaleImportService
    {
        Task ImportVehicleSalesFromFile(List<string> fileLines);
    }
}
