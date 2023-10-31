namespace Permission.Cmd.Api.Commands
{
    public interface ICommandHandler
    {
        Task HandleAsync(NewPermissionCommand command);
        Task HandleAsync(EditPermissionCommand command);
        Task HandleAsync(RevokePermissionCommand command);
    }
}