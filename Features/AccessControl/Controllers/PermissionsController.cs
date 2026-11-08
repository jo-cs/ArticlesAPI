using ArticlesAPI.Features.AccessControl.DTOs;
using ArticlesAPI.Features.AccessControl.Services;
using Microsoft.AspNetCore.Mvc;
namespace ArticlesAPI.Features.AccessControl.Controllers;
[ApiController]
[Route("api/[controller]")]
public class PermissionsController : ControllerBase
{
    private readonly IAccessControlService _service;
    public PermissionsController(IAccessControlService service) => _service = service;
    [HttpPost]
    public async Task<IActionResult> CreatePermissionAsync([FromBody] CreatePermissionDto permission)
        => Ok(await _service.CreatePermissionAsync(permission));
    
    [HttpGet]
    public async Task<IActionResult> GetAllPermissionsAsync()
        => Ok(await _service.GetAllPermissionsAsync());

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetPermissionByIdAsync([FromRoute] int id)
    {
        var permission = await _service.GetPermissionByIdAsync(id);
        return permission is null ? NotFound() : Ok(permission);
    }
    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdatePermissionAsync([FromRoute] int id, [FromBody] UpdatePermissionDto permission)
        => await _service.UpdatePermissionAsync(id, permission) ? NoContent() : NotFound();
    
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeletePermissionAsync([FromRoute] int id)
        => await _service.DeletePermissionAsync(id) ? NoContent() : NotFound();
    
    [HttpGet("role/{roleId:int}")]
    public async Task<IActionResult> GetPermissionsByRoleIdAsync([FromRoute] int roleId)
        => Ok(await _service.GetPermissionsByRoleIdAsync(roleId));
    
    [HttpPost("assign")]
    public async Task<IActionResult> AssignPermissionAsync([FromBody] AssignPermissionDto assignment)
    {
        var assigned = await _service.AssignPermissionAsync(assignment);
        return assigned ? Ok() : Conflict("Permission is already assigned to this role.");
    }
    
    [HttpDelete("role/{roleId:int}/permission/{permissionId:int}")]
    public async Task<IActionResult> RemovePermissionAsync([FromRoute] int roleId, [FromRoute] int permissionId)
        => await _service.RemovePermissionAsync(roleId, permissionId) ? NoContent() : NotFound();
}
