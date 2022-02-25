using System.ComponentModel.DataAnnotations;

namespace Vehicle.Sales.Web.Api.Endpoints.VehicleSaleEndpoints
{
    public class CreateVehicleSaleRequest
    {
        public const string Route = "/VehicleSales";

        [Required]
        public int DealNumber { get; set; }
        public string CustomerName { get; set; }
        public string DealershipName { get; set; }
        public string Vehicle { get; set; }
        public decimal Price { get; set; }
        public DateTime Date { get; set; }
    }
}
