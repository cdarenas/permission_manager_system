using Permission.Common.Events;

namespace Permission.Query.Infrastructure.Handlers
{
    public interface IEventHandler
    {
        Task On(PermissionCreatedEvent @event);
        Task On(PermissionModifiedEvent @event);
        Task On(PermissionRevokedEvent @event);
    }
}