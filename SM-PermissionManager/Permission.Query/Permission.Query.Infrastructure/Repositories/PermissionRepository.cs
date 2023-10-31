using Microsoft.EntityFrameworkCore;
using Permission.Query.Domain.Entities;
using Permission.Query.Domain.Repositories;
using Permission.Query.Infrastructure.DataAccess;

namespace Permission.Query.Infrastructure.Repositories
{
    public class PermissionRepository : IPermissionRepository
    {
        private readonly DatabaseContextFactory _contextFactory;

        public PermissionRepository(DatabaseContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task CreateAsync(PermissionEntity permission)
        {
            using DatabaseContext context = _contextFactory.CreateDbContext();
            var permissionType = await context.PermissionTypes.FirstOrDefaultAsync(x => x.PermissionTypeId == permission.PermissionTypeId) ?? throw new Exception("The permission type does not exist in the database!");
            permission.PermissionTypeEntity = permissionType;
            context.Permissions.Add(permission);
            _ = await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid permissionId)
        {
            using DatabaseContext context = _contextFactory.CreateDbContext();
            var permission = await GetByIdAsync(permissionId);

            if (permission == null) return;

            context.Permissions.Remove(permission);
            await context.SaveChangesAsync();
        }

        public async Task<PermissionEntity> GetByIdAsync(Guid permissionId)
        {
            using DatabaseContext context = _contextFactory.CreateDbContext();
            return await context.Permissions.Include(p => p.PermissionTypeEntity).FirstOrDefaultAsync(x => x.PermissionId == permissionId);
        }

        public async Task<List<PermissionEntity>> ListAllAsync()
        {
            using DatabaseContext context = _contextFactory.CreateDbContext();
            return await context.Permissions.AsNoTracking().Include(p => p.PermissionTypeEntity).AsNoTracking().ToListAsync();
        }

        public async Task UpdateAsync(PermissionEntity permission)
        {
            using DatabaseContext context = _contextFactory.CreateDbContext();
            context.Permissions.Update(permission);

            _ = await context.SaveChangesAsync();
        }
    }
}