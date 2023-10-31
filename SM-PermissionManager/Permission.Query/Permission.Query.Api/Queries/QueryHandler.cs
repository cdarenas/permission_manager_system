using Permission.Query.Domain.Entities;
using Permission.Query.Domain.Repositories;

namespace Permission.Query.Api.Queries
{
    public class QueryHandler : IQueryHandler
    {
        private readonly IPermissionRepository _permissionRepository;

        public QueryHandler(IPermissionRepository permissionRepository)
        {
            _permissionRepository = permissionRepository;
        }

        public async Task<List<PermissionEntity>> HandleAsync(FindAllPermissionsQuery query)
        {
            return await _permissionRepository.ListAllAsync();
        }
    }
}