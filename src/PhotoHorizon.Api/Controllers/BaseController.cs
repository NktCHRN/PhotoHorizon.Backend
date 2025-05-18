using Microsoft.AspNetCore.Mvc;
using PhotoHorizon.Api.Contracts.Common;

namespace PhotoHorizon.Api.Controllers;

public abstract class BaseController : ControllerBase
{
    protected OkObjectResult OkResponse<T>(T value)
    {
        return base.Ok(ApiResponse.FromResult(value));
    }

    protected NoContentResult NoContentResponse()
    {
        return base.NoContent();
    }

    protected UnauthorizedObjectResult UnauthorizedResponse(ErrorResponse error)
    {
        return base.Unauthorized(ApiResponse.FromError(error));
    }
}
