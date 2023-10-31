using Permission.Query.Domain.Entities;

namespace Permission.Query.Domain.Repositories
{
    public interface IPermissionRepository
    {
        Task CreateAsync(PermissionEntity permission);
        Task UpdateAsync(PermissionEntity permission);
        Task DeleteAsync(Guid permissionId);
        Task<PermissionEntity> GetByIdAsync(Guid permissionId);
        Task<List<PermissionEntity>> ListAllAsync();
    }
}