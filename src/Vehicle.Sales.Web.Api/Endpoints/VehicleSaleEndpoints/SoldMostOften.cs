using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Vehicle.Sales.Core.Interfaces;
using Vehicle.Sales.Web.Api.Endpoints.Common;
using Vehicle.Sales.Web.Api.Endpoints.VehicleSaleEndpoints;

namespace Clean.Architecture.Web.Endpoints.ProjectEndpoints
{
    public class SoldMostOften : EndpointBaseAsync
        .WithoutRequest
        .WithActionResult<SoldMostOftenResponse>
    {
        private readonly IVehicleSaleSearchService _vehicleSaleSearchService;

        public SoldMostOften(IVehicleSaleSearchService vehicleSaleSearchService)
        {
            _vehicleSaleSearchService = vehicleSaleSearchService;
        }

        [HttpGet("/VehicleSales/SoldMostOften")]
        [SwaggerOperation(
            Summary = "Gets the Vehicle that was sold the most often",
            Description = "Gets the Vehicle that was sold the most often",
            OperationId = "VehicleSale.SoldMostOften",
            Tags = new[] { "VehicleSaleEndpoints" })
        ]
        public override async Task<ActionResult<SoldMostOftenResponse>> HandleAsync(CancellationToken cancellationToken)
        {
            var response = new SoldMostOftenResponse
            {
                Vehicle = await _vehicleSaleSearchService.GetVehicleSoldMostOften()
            };

            return Ok(response);
        }
    }
}
