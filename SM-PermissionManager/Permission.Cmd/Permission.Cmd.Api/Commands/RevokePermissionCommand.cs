using CQRS.Core.Commands;

namespace Permission.Cmd.Api.Commands
{
    public class RevokePermissionCommand : BaseCommand
    {
        public DateTime ModifiedDate { get; set; }
    }
}