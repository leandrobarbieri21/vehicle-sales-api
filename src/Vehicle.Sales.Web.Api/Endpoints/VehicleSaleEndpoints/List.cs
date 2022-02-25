using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Vehicle.Sales.Core.Interfaces;
using Vehicle.Sales.Web.Api.Endpoints.Common;
using Vehicle.Sales.Web.Api.Endpoints.VehicleSaleEndpoints;

namespace Clean.Architecture.Web.Endpoints.ProjectEndpoints
{
    public class List : EndpointBaseAsync
        .WithoutRequest
        .WithActionResult<VehicleSaleListResponse>
    {
        private readonly IVehicleSaleSearchService _vehicleSaleSearchService;

        public List(IVehicleSaleSearchService vehicleSaleSearchService)
        {
            _vehicleSaleSearchService = vehicleSaleSearchService;
        }

        [HttpGet("/VehicleSales")]
        [SwaggerOperation(
            Summary = "Gets a list of all Vehicle Sales",
            Description = "Gets a list of all Vehicle Sales",
            OperationId = "VehicleSale.List",
            Tags = new[] { "VehicleSaleEndpoints" })
        ]
        public override async Task<ActionResult<VehicleSaleListResponse>> HandleAsync(CancellationToken cancellationToken)
        {
            var response = new VehicleSaleListResponse
            {
                VehicleSales = (await _vehicleSaleSearchService.GetAllVehicleSales())
                    .Select(vehicleSale => new VehicleSaleRecord(vehicleSale.Id,
                                                                 vehicleSale.DealNumber,
                                                                 vehicleSale.CustomerName,
                                                                 vehicleSale.DealershipName,
                                                                 vehicleSale.Vehicle,
                                                                 vehicleSale.Price,
                                                                 vehicleSale.Date))
                    .ToList()
            };

            return Ok(response);
        }
    }
}
