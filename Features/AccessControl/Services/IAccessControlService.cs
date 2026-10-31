using ArticlesAPI.Features.AccessControl.DTOs;
namespace ArticlesAPI.Features.AccessControl.Services;
public interface IAccessControlService
{
    Task<int> CreateRoleAsync(CreateRoleDto role);
    Task<IEnumerable<RoleResponseDto>> GetAllRolesAsync();
    Task<RoleResponseDto?> GetRoleByIdAsync(int id);
    Task<bool> UpdateRoleAsync(int id, UpdateRoleDto role);
    Task<bool> DeleteRoleAsync(int id);
    Task<int> CreatePermissionAsync(CreatePermissionDto permission);
    Task<IEnumerable<PermissionResponseDto>> GetAllPermissionsAsync();
    Task<PermissionResponseDto?> GetPermissionByIdAsync(int id);
    Task<bool> UpdatePermissionAsync(int id, UpdatePermissionDto permission);
    Task<bool> DeletePermissionAsync(int id);
    Task<IEnumerable<string>> GetPermissionsByRoleIdAsync(int roleId);
    Task<bool> AssignPermissionAsync(AssignPermissionDto assignment);
    Task<bool> RemovePermissionAsync(int roleId, int permissionId);
}
