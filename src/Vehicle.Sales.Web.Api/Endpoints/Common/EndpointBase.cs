using Microsoft.AspNetCore.Mvc;

namespace Vehicle.Sales.Web.Api.Endpoints.Common
{
    /// <summary>
    /// A base class for an API controller with single action (endpoint).
    /// </summary>
    [ApiController]
    public abstract class EndpointBase : ControllerBase
    {
    }
}
