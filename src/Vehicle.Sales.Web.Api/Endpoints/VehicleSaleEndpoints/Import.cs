using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Vehicle.Sales.Core.Interfaces;
using Vehicle.Sales.Web.Api.Endpoints.Common;

namespace Vehicle.Sales.Web.Api.Endpoints.VehicleSaleEndpoints
{
    public class Import : EndpointBaseAsync
        .WithoutRequest
        .WithoutResult
    {
        private readonly IVehicleSaleImportService _vehicleSaleImportService;

        public Import(IVehicleSaleImportService vehicleSaleImportService)
        {
            _vehicleSaleImportService = vehicleSaleImportService;
        }

        [HttpPost("/VehicleSales/Import")]
        [SwaggerOperation(
            Summary = "Import Vehicle Sales",
            Description = "Import Vehicle Sales",
            OperationId = "VehicleSale.Import",
            Tags = new[] { "VehicleSaleEndpoints" })
        ]
        public override async Task<ActionResult> HandleAsync(CancellationToken cancellationToken = default)
        {
            var request = HttpContext.Request;

            if (request == null)
                return BadRequest();

            var file = request.Form.Files["File"];

            if (file == null)
                return BadRequest();

            await _vehicleSaleImportService.ImportVehicleSalesFromFile(file.ReadAsList());

            return new StatusCodeResult(201);
        }
    }
}
