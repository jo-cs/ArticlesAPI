using ArticlesAPI.Features.AccessControl.DTOs;
using ArticlesAPI.Features.AccessControl.Services;
using ArticlesAPI.Shared.Base;
using Microsoft.AspNetCore.Mvc;
namespace ArticlesAPI.Features.AccessControl.Controllers;
[ApiController]
[Route("api/[controller]")]
public class PermissionsController : BaseController
{
    private readonly IAccessControlService _service;
    public PermissionsController(IAccessControlService service) => _service = service;
    [HttpPost] public async Task<IActionResult> CreatePermissionAsync([FromBody] CreatePermissionDto permission) => Ok(await _service.CreatePermissionAsync(permission));
    [HttpGet] public async Task<IActionResult> GetAllPermissionsAsync() => Ok(await _service.GetAllPermissionsAsync());
    [HttpGet("{id:int}")] public async Task<IActionResult> GetPermissionByIdAsync([FromRoute] int id) => Ok(await _service.GetPermissionByIdAsync(id));
    [HttpPut("{id:int}")] public async Task<IActionResult> UpdatePermissionAsync([FromRoute] int id, [FromBody] UpdatePermissionDto permission) => Ok(await _service.UpdatePermissionAsync(id, permission));
    [HttpDelete("{id:int}")] public async Task<IActionResult> DeletePermissionAsync([FromRoute] int id) => Ok(await _service.DeletePermissionAsync(id));
    [HttpGet("role/{roleId:int}")] public async Task<IActionResult> GetPermissionsByRoleIdAsync([FromRoute] int roleId) => Ok(await _service.GetPermissionsByRoleIdAsync(roleId));
    [HttpPost("assign")] public async Task<IActionResult> AssignPermissionAsync([FromBody] AssignPermissionDto assignment) => Ok(await _service.AssignPermissionAsync(assignment));
    [HttpDelete("role/{roleId:int}/permission/{permissionId:int}")] public async Task<IActionResult> RemovePermissionAsync([FromRoute] int roleId, [FromRoute] int permissionId) => Ok(await _service.RemovePermissionAsync(roleId, permissionId));
}
