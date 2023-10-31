using CQRS.Core.Commands;

namespace Permission.Cmd.Api.Commands
{
    public class EditPermissionCommand : BaseCommand
    {
        public Guid PermissionId { get; set; }
        public Guid PermissionType { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}