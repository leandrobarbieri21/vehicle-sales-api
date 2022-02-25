namespace Vehicle.Sales.Web.Api.Endpoints.VehicleSaleEndpoints
{
    public class CreateVehicleSaleResponse
    {
        public VehicleSaleRecord? VehicleSale { get; set; }

        public CreateVehicleSaleResponse(int id,
                                         int dealNumber, 
                                         string customerName, 
                                         string dealershipName, 
                                         string vehicle, 
                                         decimal price, 
                                         DateTime date)
        {
            VehicleSale = new(id, dealNumber, customerName, dealershipName, vehicle, price, date);
        }
    }
}
