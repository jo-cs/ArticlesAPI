using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using ArticlesAPI.Shared.Results;

namespace ArticlesAPI.Shared.Base;

public class BaseController : ControllerBase
{
    protected int? CurrentUserId
    {
        get
        {
            var userIdValue =
                User.FindFirst(ClaimTypes.NameIdentifier)?.Value
                ?? User.FindFirst(JwtRegisteredClaimNames.Sub)?.Value;

            return int.TryParse(userIdValue, out var id) ? id : null;
        }
    }

    protected string? CurrentUserName =>
        User.Identity?.Name;

    protected string? CurrentUserRole =>
        User.FindFirst(ClaimTypes.Role)?.Value;

    protected string? CurrentRoleId =>
        User.FindFirst("roleId")?.Value;

    protected IActionResult Ok<T>(ServiceResult<T> result)
    {
        if (result.Success)
            return base.Ok(result.Data);

        var response = new { message = result.Error };

        return result.StatusCode switch
        {
            400 => BadRequest(response),
            401 => Unauthorized(response),
            403 => Forbid(),
            404 => NotFound(response),
            409 => Conflict(response),
            422 => UnprocessableEntity(response),
            _ => StatusCode(result.StatusCode, response)
        };
    }
}