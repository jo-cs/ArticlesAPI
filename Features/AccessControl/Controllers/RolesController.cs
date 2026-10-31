using ArticlesAPI.Features.AccessControl.DTOs;
using ArticlesAPI.Features.AccessControl.Services;
using Microsoft.AspNetCore.Mvc;
namespace ArticlesAPI.Features.AccessControl.Controllers;
[ApiController]
[Route("api/[controller]")]
public class RolesController : ControllerBase
{
    private readonly IAccessControlService _service;
    public RolesController(IAccessControlService service) => _service = service;
    [HttpPost]
    public async Task<IActionResult> CreateRoleAsync([FromBody] CreateRoleDto role) => Ok(await _service.CreateRoleAsync(role));
    [HttpGet]
    public async Task<IActionResult> GetAllRolesAsync() => Ok(await _service.GetAllRolesAsync());
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetRoleByIdAsync([FromRoute] int id) { var role = await _service.GetRoleByIdAsync(id); return role is null ? NotFound() : Ok(role); }
    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateRoleAsync([FromRoute] int id, [FromBody] UpdateRoleDto role) => await _service.UpdateRoleAsync(id, role) ? NoContent() : NotFound();
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteRoleAsync([FromRoute] int id) => await _service.DeleteRoleAsync(id) ? NoContent() : NotFound();
}
