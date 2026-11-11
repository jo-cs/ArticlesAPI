using ArticlesAPI.Features.AccessControl.DTOs;
using ArticlesAPI.Shared.Results;
namespace ArticlesAPI.Features.AccessControl.Services;
public interface IAccessControlService
{
    Task<ServiceResult<int>> CreateRoleAsync(CreateRoleDto role);
    Task<ServiceResult<IEnumerable<RoleResponseDto>>> GetAllRolesAsync();
    Task<ServiceResult<RoleResponseDto>> GetRoleByIdAsync(int id);
    Task<ServiceResult<bool>> UpdateRoleAsync(int id, UpdateRoleDto role);
    Task<ServiceResult<bool>> DeleteRoleAsync(int id);
    Task<ServiceResult<int>> CreatePermissionAsync(CreatePermissionDto permission);
    Task<ServiceResult<IEnumerable<PermissionResponseDto>>> GetAllPermissionsAsync();
    Task<ServiceResult<PermissionResponseDto>> GetPermissionByIdAsync(int id);
    Task<ServiceResult<bool>> UpdatePermissionAsync(int id, UpdatePermissionDto permission);
    Task<ServiceResult<bool>> DeletePermissionAsync(int id);
    Task<ServiceResult<IEnumerable<string>>> GetPermissionsByRoleIdAsync(int roleId);
    Task<ServiceResult<bool>> AssignPermissionAsync(AssignPermissionDto assignment);
    Task<ServiceResult<bool>> RemovePermissionAsync(int roleId, int permissionId);
}
