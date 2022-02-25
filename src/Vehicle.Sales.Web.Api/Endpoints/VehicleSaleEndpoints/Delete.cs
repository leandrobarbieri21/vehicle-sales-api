using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Vehicle.Sales.Core.Interfaces;
using Vehicle.Sales.Web.Api.Endpoints.Common;

namespace Vehicle.Sales.Web.Api.Endpoints.VehicleSaleEndpoints
{
    public class Delete : EndpointBaseAsync
        .WithoutRequest
        .WithoutResult
    {
        private readonly IVehicleSaleDeleteService _vehicleSaleDeleteService;

        public Delete(IVehicleSaleDeleteService vehicleSaleDeleteService)
        {
            _vehicleSaleDeleteService = vehicleSaleDeleteService;
        }

        [HttpDelete("/VehicleSales/DeleteAll")]
        [SwaggerOperation(
            Summary = "Delete All Vehicle Sales",
            Description = "Delete All Vehicle Sales",
            OperationId = "VehicleSale.DeleteAll",
            Tags = new[] { "VehicleSaleEndpoints" })
        ]
        public override async Task<ActionResult> HandleAsync(CancellationToken cancellationToken = default)
        {
            await _vehicleSaleDeleteService.DeleteAllVehicleSales(cancellationToken);
            return new StatusCodeResult(204);
        }
    }
}
