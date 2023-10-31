using CQRS.Core.Commands;

namespace Permission.Cmd.Api.Commands
{
    public class NewPermissionCommand : BaseCommand
    {
        public required string EmployeeFirstName { get; set; }
        public required string EmployeeLastName { get; set; }
        public Guid PermissionType { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}