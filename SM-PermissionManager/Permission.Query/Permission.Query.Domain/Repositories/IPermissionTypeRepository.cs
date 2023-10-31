using Permission.Query.Domain.Entities;

namespace Permission.Query.Domain.Repositories
{
    public interface IPermissionTypeRepository
    {
        Task CreateAsync(PermissionTypeEntity permissionType);
        Task UpdateAsync(PermissionTypeEntity permissionType);
        Task<List<PermissionTypeEntity>> ListAllAsync();
    }
}