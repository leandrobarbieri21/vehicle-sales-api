namespace Vehicle.Sales.Web.Api.Endpoints.VehicleSaleEndpoints
{
    public record VehicleSaleRecord(int id, int dealNumber, string customerName, string dealershipName, string vehicle, decimal price, DateTime date);
}
