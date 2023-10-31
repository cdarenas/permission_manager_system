using CQRS.Core.Domain;
using Permission.Common.Events;

namespace Permission.Cmd.Domain.Aggregates
{
    public class PermissionAggregate : AggregateRoot
    {
        private bool _active;
        private string? _employee;

        public bool Active
        {
            get => _active; set => _active = value;
        }

        public PermissionAggregate()
        {

        }

        public PermissionAggregate(Guid id, string employeeFirstName, string employeeLastName, Guid permissionType)
        {
            RaiseEvent(new PermissionCreatedEvent
            {
                Id = id,
                EmployeeFirstName = employeeFirstName,
                EmployeeLastName = employeeLastName,
                PermissionType = permissionType,
                CreatedDate = DateTime.UtcNow
            });
        }

        public void Apply(PermissionCreatedEvent @event)
        {
            _id = @event.Id;
            _active = true;
            _employee = @event.EmployeeFirstName + " " + @event.EmployeeLastName;
        }

        public void ModifyPermission(Guid permissionType)
        {
            if (!_active)
            {
                throw new InvalidOperationException($"You cannot modify revoked permissions for {_employee}!");
            }

            RaiseEvent(new PermissionModifiedEvent
            {
                Id = _id,
                PermissionType = permissionType,
                ModifiedDate = DateTime.Now
            });
        }

        public void Apply(PermissionModifiedEvent @event)
        {
            _id = @event.Id;
        }

        public void RevokePermission()
        {
            if (!_active)
            {
                throw new InvalidOperationException($"The permission for {_employee} has been already revoked!");
            }

            RaiseEvent(new PermissionRevokedEvent
            {
                Id = _id,
                ModifiedDate = DateTime.Now
            });
        }

        public void Apply(PermissionRevokedEvent @event)
        {
            _id = @event.Id;
            _active = false;
        }
    }
}