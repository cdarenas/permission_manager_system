using CQRS.Core.Events;

namespace Permission.Common.Events
{
    public class PermissionModifiedEvent : BaseEvent
    {
        public PermissionModifiedEvent() : base(nameof(PermissionModifiedEvent))
        {

        }

        public Guid PermissionId { get; set; }
        public Guid PermissionType { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}