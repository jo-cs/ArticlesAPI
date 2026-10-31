using System.Data;
using ArticlesAPI.Features.AccessControl.DTOs;
using ArticlesAPI.Infrastructure.Data;
using Dapper;
namespace ArticlesAPI.Features.AccessControl.Repositories;
public class AccessControlRepository : IAccessControlRepository
{
    private readonly DapperContext _context;
    public AccessControlRepository(DapperContext context) => _context = context;

    public async Task<int> CreateRoleAsync(CreateRoleDto role)
    {
        using var c = _context.CreateConnection();
        return await c.QuerySingleAsync<int>("Role_Create",
            new { role.NameOfRole, role.IsActive },
            commandType: CommandType.StoredProcedure);
    }

    public async Task<IEnumerable<RoleResponseDto>> GetAllRolesAsync()
    {
        using var c = _context.CreateConnection();
        return await c.QueryAsync<RoleResponseDto>("Role_GetAll",
            commandType: CommandType.StoredProcedure);
    }

    public async Task<RoleResponseDto?> GetRoleByIdAsync(int id)
    {
        using var c = _context.CreateConnection();
        return await c.QuerySingleOrDefaultAsync<RoleResponseDto>("Role_GetById",
            new { Id = id }, commandType: CommandType.StoredProcedure);
    }

    public async Task<bool> UpdateRoleAsync(int id, UpdateRoleDto role)
    {
        using var c = _context.CreateConnection();
        return await c.QuerySingleAsync<bool>("Role_Update",
            new
            {
                Id = id,
                role.NameOfRole,
                role.IsActive
            },
            commandType: CommandType.StoredProcedure);
    }

    public async Task<bool> DeleteRoleAsync(int id)
    {
        using var c = _context.CreateConnection();
        return await c.QuerySingleAsync<bool>("Role_Delete",
            new { Id = id },
            commandType: CommandType.StoredProcedure);
    }

    public async Task<int> CreatePermissionAsync(CreatePermissionDto permission)
    {
        using var c = _context.CreateConnection();
        return await c.QuerySingleAsync<int>("Permission_Create"
            , new { permission.NameOfPermission },
            commandType: CommandType.StoredProcedure);
    }

    public async Task<IEnumerable<PermissionResponseDto>> GetAllPermissionsAsync()
    {
        using var c = _context.CreateConnection();
        return await c.QueryAsync<PermissionResponseDto>("Permission_GetAll",
            commandType: CommandType.StoredProcedure);
    }

    public async Task<PermissionResponseDto?> GetPermissionByIdAsync(int id)
    {
        using var c = _context.CreateConnection();
        return await c.QuerySingleOrDefaultAsync<PermissionResponseDto>("Permission_GetById",
            new { Id = id }, commandType: CommandType.StoredProcedure);
    }

    public async Task<bool> UpdatePermissionAsync(int id, UpdatePermissionDto permission)
    {
        using var c = _context.CreateConnection();
        return await c.QuerySingleAsync<bool>("Permission_Update",
            new { Id = id, permission.NameOfPermission },
            commandType: CommandType.StoredProcedure);
    }

    public async Task<bool> DeletePermissionAsync(int id)
    {
        using var c = _context.CreateConnection();
        return await c.QuerySingleAsync<bool>("Permission_Delete",
            new { Id = id },
            commandType: CommandType.StoredProcedure);
    }

    public async Task<IEnumerable<string>> GetPermissionsByRoleIdAsync(int roleId)
    {
        using var c = _context.CreateConnection();
        return await c.QueryAsync<string>("AccessControl_GetPermissionsByRoleId",
            new { RoleId = roleId }, 
            commandType: CommandType.StoredProcedure);
    }

    public async Task<bool> AssignPermissionAsync(AssignPermissionDto assignment)
    {
        using var c = _context.CreateConnection();
        return await c.QuerySingleAsync<bool>("RolePermission_Assign",
            new { assignment.RoleId, assignment.PermissionId },
            commandType: CommandType.StoredProcedure);
    }

    public async Task<bool> RemovePermissionAsync(int roleId, int permissionId)
    {
        using var c = _context.CreateConnection();
        return await c.QuerySingleAsync<bool>("RolePermission_Remove", 
            new { RoleId = roleId, PermissionId = permissionId },
            commandType: CommandType.StoredProcedure);
    }
}
