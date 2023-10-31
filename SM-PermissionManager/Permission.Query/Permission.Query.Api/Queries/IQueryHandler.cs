using Permission.Query.Domain.Entities;

namespace Permission.Query.Api.Queries
{
    public interface IQueryHandler
    {
        Task<List<PermissionEntity>> HandleAsync(FindAllPermissionsQuery query);
    }
}