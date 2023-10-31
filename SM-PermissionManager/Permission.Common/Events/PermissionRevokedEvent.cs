using CQRS.Core.Events;

namespace Permission.Common.Events
{
    public class PermissionRevokedEvent : BaseEvent
    {
        public PermissionRevokedEvent() : base(nameof(PermissionRevokedEvent))
        {

        }

        public Guid PermissionId { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}