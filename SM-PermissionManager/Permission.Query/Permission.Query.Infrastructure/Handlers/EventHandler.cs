using Permission.Common.Events;
using Permission.Query.Domain.Entities;
using Permission.Query.Domain.Repositories;

namespace Permission.Query.Infrastructure.Handlers
{
    public class EventHandler : IEventHandler
    {
        private readonly IPermissionRepository _permissionRepository;
        private readonly IPermissionTypeRepository _permissionTypeRepository;

        public EventHandler(IPermissionRepository permissionRepository, IPermissionTypeRepository permissionTypeRepository)
        {
            _permissionRepository = permissionRepository;
            _permissionTypeRepository = permissionTypeRepository;
        }

        public async Task On(PermissionCreatedEvent @event)
        {
            var permission = new PermissionEntity
            {
                PermissionId = @event.Id,
                EmployeeFirstName = @event.EmployeeFirstName,
                EmployeeLastName = @event.EmployeeLastName,
                CreatedDate = @event.CreatedDate,
                PermissionTypeId = @event.PermissionType
            };

            await _permissionRepository.CreateAsync(permission);
        }

        public async Task On(PermissionModifiedEvent @event)
        {
            var permission = await _permissionRepository.GetByIdAsync(@event.Id);

            if (permission == null) return;

            permission.PermissionId = @event.PermissionType;
            await _permissionRepository.UpdateAsync(permission);
        }

        public async Task On(PermissionRevokedEvent @event)
        {
            await _permissionRepository.DeleteAsync(@event.PermissionId);
        }
    }
}