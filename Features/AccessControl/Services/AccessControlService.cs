using ArticlesAPI.Features.AccessControl.DTOs;
using ArticlesAPI.Features.AccessControl.Repositories;
namespace ArticlesAPI.Features.AccessControl.Services;
public class AccessControlService : IAccessControlService
{
    private readonly IAccessControlRepository _repository;
    public AccessControlService(IAccessControlRepository repository)
        => _repository = repository;
    
    public Task<int> CreateRoleAsync(CreateRoleDto role)
        => _repository.CreateRoleAsync(role);
    
    public Task<IEnumerable<RoleResponseDto>> GetAllRolesAsync()
        => _repository.GetAllRolesAsync();
    
    public Task<RoleResponseDto?> GetRoleByIdAsync(int id)
        => _repository.GetRoleByIdAsync(id);
    
    public Task<bool> UpdateRoleAsync(int id, UpdateRoleDto role)
        => _repository.UpdateRoleAsync(id, role);
    
    public Task<bool> DeleteRoleAsync(int id)
        => _repository.DeleteRoleAsync(id);
    
    public Task<int> CreatePermissionAsync(CreatePermissionDto permission)
        => _repository.CreatePermissionAsync(permission);
    
    public Task<IEnumerable<PermissionResponseDto>> GetAllPermissionsAsync()
        => _repository.GetAllPermissionsAsync();
    
    public Task<PermissionResponseDto?> GetPermissionByIdAsync(int id)
        => _repository.GetPermissionByIdAsync(id);
    
    public Task<bool> UpdatePermissionAsync(int id, UpdatePermissionDto permission) 
        => _repository.UpdatePermissionAsync(id, permission);
    
    public Task<bool> DeletePermissionAsync(int id
    ) => _repository.DeletePermissionAsync(id);
    
    public Task<IEnumerable<string>> GetPermissionsByRoleIdAsync(int roleId)
        => _repository.GetPermissionsByRoleIdAsync(roleId);
    
    public Task<bool> AssignPermissionAsync(AssignPermissionDto assignment)
        => _repository.AssignPermissionAsync(assignment);
    
    public Task<bool> RemovePermissionAsync(int roleId, int permissionId)
        => _repository.RemovePermissionAsync(roleId, permissionId);
}
