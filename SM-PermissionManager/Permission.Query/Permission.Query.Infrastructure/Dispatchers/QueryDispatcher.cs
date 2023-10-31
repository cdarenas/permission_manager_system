using CQRS.Core.Infrastructure;
using CQRS.Core.Queries;
using Permission.Query.Domain.Entities;

namespace Permission.Query.Infrastructure.Dispatchers
{
    public class QueryDispatcher : IQueryDispatcher<PermissionEntity>
    {
        private readonly Dictionary<Type, Func<BaseQuery, Task<List<PermissionEntity>>>> _handlers = new();

        public void RegisterHandler<TQuery>(Func<TQuery, Task<List<PermissionEntity>>> handler) where TQuery : BaseQuery
        {
            if (_handlers.ContainsKey(typeof(TQuery)))
            {
                throw new IndexOutOfRangeException("Cannot register the same query handler again!");
            }
            _handlers.Add(typeof(TQuery), x => handler((TQuery)x));
        }

        public async Task<List<PermissionEntity>> SendAsync(BaseQuery query)
        {
            if (_handlers.TryGetValue(query.GetType(), out Func<BaseQuery, Task<List<PermissionEntity>>> handler))
            {
                return await handler(query);
            }

            throw new ArgumentNullException(nameof(handler), "No query handler was registered!");
        }
    }
}