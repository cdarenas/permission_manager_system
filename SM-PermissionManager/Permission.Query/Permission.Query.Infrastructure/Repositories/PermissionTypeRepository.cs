using Microsoft.EntityFrameworkCore;
using Permission.Query.Domain.Entities;
using Permission.Query.Domain.Repositories;
using Permission.Query.Infrastructure.DataAccess;

namespace Permission.Query.Infrastructure.Repositories
{
    public class PermissionTypeRepository : IPermissionTypeRepository
    {
        private readonly DatabaseContextFactory _contextFactory;

        public PermissionTypeRepository(DatabaseContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task CreateAsync(PermissionTypeEntity permissionType)
        {
            using DatabaseContext context = _contextFactory.CreateDbContext();
            context.PermissionTypes.Add(permissionType);
            _ = await context.SaveChangesAsync();
        }

        public async Task<List<PermissionTypeEntity>> ListAllAsync()
        {
            using DatabaseContext context = _contextFactory.CreateDbContext();
            return await context.PermissionTypes.AsNoTracking().ToListAsync();
        }

        public async Task UpdateAsync(PermissionTypeEntity permissionType)
        {
            using DatabaseContext context = _contextFactory.CreateDbContext();
            context.PermissionTypes.Update(permissionType);

            _ = await context.SaveChangesAsync();
        }
    }
}