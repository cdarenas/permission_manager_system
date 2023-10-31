using CQRS.Core.Events;

namespace Permission.Common.Events
{
    public class PermissionCreatedEvent : BaseEvent
    {
        public PermissionCreatedEvent() : base(nameof(PermissionCreatedEvent))
        {

        }

        public required string EmployeeFirstName { get; set; }
        public required string EmployeeLastName { get; set; }
        public Guid PermissionType { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}