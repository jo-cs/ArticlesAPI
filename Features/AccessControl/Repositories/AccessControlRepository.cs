using ArticlesAPI.Features.AccessControl.DTOs;
using ArticlesAPI.Infrastructure.Data;
using ArticlesAPI.Shared.Repositories;
namespace ArticlesAPI.Features.AccessControl.Repositories;
public class AccessControlRepository : BaseRepository, IAccessControlRepository
{
    public AccessControlRepository(DapperContext context) : base(context) { }
    public Task<int> CreateRoleAsync(CreateRoleDto role) => QuerySingleAsync<int>("Role_Create", new { role.NameOfRole, role.IsActive });
    public Task<IEnumerable<RoleResponseDto>> GetAllRolesAsync() => QueryAsync<RoleResponseDto>("Role_GetAll");
    public Task<RoleResponseDto?> GetRoleByIdAsync(int id) => QuerySingleOrDefaultAsync<RoleResponseDto>("Role_GetById", new { Id = id });
    public Task<bool> UpdateRoleAsync(int id, UpdateRoleDto role) => QuerySingleAsync<bool>("Role_Update", new { Id = id, role.NameOfRole, role.IsActive });
    public Task<bool> DeleteRoleAsync(int id) => QuerySingleAsync<bool>("Role_Delete", new { Id = id });
    public Task<int> CreatePermissionAsync(CreatePermissionDto permission) => QuerySingleAsync<int>("Permission_Create", new { permission.NameOfPermission });
    public Task<IEnumerable<PermissionResponseDto>> GetAllPermissionsAsync() => QueryAsync<PermissionResponseDto>("Permission_GetAll");
    public Task<PermissionResponseDto?> GetPermissionByIdAsync(int id) => QuerySingleOrDefaultAsync<PermissionResponseDto>("Permission_GetById", new { Id = id });
    public Task<bool> UpdatePermissionAsync(int id, UpdatePermissionDto permission) => QuerySingleAsync<bool>("Permission_Update", new { Id = id, permission.NameOfPermission });
    public Task<bool> DeletePermissionAsync(int id) => QuerySingleAsync<bool>("Permission_Delete", new { Id = id });
    public Task<IEnumerable<string>> GetPermissionsByRoleIdAsync(int roleId) => QueryAsync<string>("AccessControl_GetPermissionsByRoleId", new { RoleId = roleId });
    public Task<bool> AssignPermissionAsync(AssignPermissionDto assignment) => QuerySingleAsync<bool>("RolePermission_Assign", new { assignment.RoleId, assignment.PermissionId });
    public Task<bool> RemovePermissionAsync(int roleId, int permissionId) => QuerySingleAsync<bool>("RolePermission_Remove", new { RoleId = roleId, PermissionId = permissionId });
}
