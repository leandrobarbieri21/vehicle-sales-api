using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using Vehicle.Sales.Core.Interfaces;
using Vehicle.Sales.Core.VehicleSaleAggregate;
using Vehicle.Sales.Web.Api.Endpoints.Common;

namespace Vehicle.Sales.Web.Api.Endpoints.VehicleSaleEndpoints
{
    public class Create : EndpointBaseAsync
        .WithRequest<CreateVehicleSaleRequest>
        .WithActionResult<CreateVehicleSaleResponse>
    {
        private readonly IVehicleSaleCreateService _vehicleSaleCreateService;

        public Create(IVehicleSaleCreateService vehicleSaleCreateService)
        {
            _vehicleSaleCreateService = vehicleSaleCreateService;
        }

        [HttpPost("/VehicleSales")]
        [SwaggerOperation(
            Summary = "Creates a new Vehicle Sale",
            Description = "Creates a new Vehicle Sale",
            OperationId = "VehicleSale.Create",
            Tags = new[] { "VehicleSaleEndpoints" })
        ]
        public override async Task<ActionResult<CreateVehicleSaleResponse>> HandleAsync(CreateVehicleSaleRequest request,
            CancellationToken cancellationToken)
        {
            if (request.DealNumber == 0)
            {
                return BadRequest();
            }

            var newVehicleSale = new VehicleSale(request.DealNumber,
                                                 request.CustomerName,
                                                 request.DealershipName,
                                                 request.Vehicle,
                                                 request.Price,
                                                 request.Date);

            var createdItem = await _vehicleSaleCreateService.CreateVehicleSale(newVehicleSale, cancellationToken);

            var response = new CreateVehicleSaleResponse(createdItem.Id,
                                                         createdItem.DealNumber,
                                                         createdItem.CustomerName,
                                                         createdItem.DealershipName,
                                                         createdItem.Vehicle,
                                                         createdItem.Price,
                                                         createdItem.Date);

            return Ok(response);
        }
    }
}
