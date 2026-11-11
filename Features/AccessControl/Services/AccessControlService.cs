using ArticlesAPI.Features.AccessControl.DTOs;
using ArticlesAPI.Features.AccessControl.Repositories;
using ArticlesAPI.Shared.Results;
namespace ArticlesAPI.Features.AccessControl.Services;
public class AccessControlService : IAccessControlService
{
    private readonly IAccessControlRepository _repository;
    public AccessControlService(IAccessControlRepository repository) => _repository = repository;
    public Task<ServiceResult<int>> CreateRoleAsync(CreateRoleDto role) => ServiceResult<int>.FromAsync(_repository.CreateRoleAsync(role), "Role creation failed.", 400);
    public Task<ServiceResult<IEnumerable<RoleResponseDto>>> GetAllRolesAsync() => ServiceResult<IEnumerable<RoleResponseDto>>.FromAsync(_repository.GetAllRolesAsync(), "Roles could not be retrieved.", 500);
    public Task<ServiceResult<RoleResponseDto>> GetRoleByIdAsync(int id) => ServiceResult<RoleResponseDto>.FromAsync(_repository.GetRoleByIdAsync(id), "Role not found.");
    public Task<ServiceResult<bool>> UpdateRoleAsync(int id, UpdateRoleDto role) => ServiceResult<bool>.FromAsync(_repository.UpdateRoleAsync(id, role), "Role not found or update failed.");
    public Task<ServiceResult<bool>> DeleteRoleAsync(int id) => ServiceResult<bool>.FromAsync(_repository.DeleteRoleAsync(id), "Role not found.");
    public Task<ServiceResult<int>> CreatePermissionAsync(CreatePermissionDto permission) => ServiceResult<int>.FromAsync(_repository.CreatePermissionAsync(permission), "Permission creation failed.", 400);
    public Task<ServiceResult<IEnumerable<PermissionResponseDto>>> GetAllPermissionsAsync() => ServiceResult<IEnumerable<PermissionResponseDto>>.FromAsync(_repository.GetAllPermissionsAsync(), "Permissions could not be retrieved.", 500);
    public Task<ServiceResult<PermissionResponseDto>> GetPermissionByIdAsync(int id) => ServiceResult<PermissionResponseDto>.FromAsync(_repository.GetPermissionByIdAsync(id), "Permission not found.");
    public Task<ServiceResult<bool>> UpdatePermissionAsync(int id, UpdatePermissionDto permission) => ServiceResult<bool>.FromAsync(_repository.UpdatePermissionAsync(id, permission), "Permission not found or update failed.");
    public Task<ServiceResult<bool>> DeletePermissionAsync(int id) => ServiceResult<bool>.FromAsync(_repository.DeletePermissionAsync(id), "Permission not found.");
    public Task<ServiceResult<IEnumerable<string>>> GetPermissionsByRoleIdAsync(int roleId) => ServiceResult<IEnumerable<string>>.FromAsync(_repository.GetPermissionsByRoleIdAsync(roleId), "Permissions could not be retrieved.", 500);
    public Task<ServiceResult<bool>> AssignPermissionAsync(AssignPermissionDto assignment) => ServiceResult<bool>.FromAsync(_repository.AssignPermissionAsync(assignment), "Permission is already assigned to this role.", 409);
    public Task<ServiceResult<bool>> RemovePermissionAsync(int roleId, int permissionId) => ServiceResult<bool>.FromAsync(_repository.RemovePermissionAsync(roleId, permissionId), "Role permission not found.");
}
