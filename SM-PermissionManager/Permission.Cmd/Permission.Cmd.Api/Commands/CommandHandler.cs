using CQRS.Core.Handlers;
using Permission.Cmd.Domain.Aggregates;

namespace Permission.Cmd.Api.Commands
{
    public class CommandHandler : ICommandHandler
    {
        private readonly IEventSourcingHandler<PermissionAggregate> _eventSourcingHandler;

        public CommandHandler(IEventSourcingHandler<PermissionAggregate> eventSourcingHandler)
        {
            _eventSourcingHandler = eventSourcingHandler;
        }

        public async Task HandleAsync(NewPermissionCommand command)
        {
            var aggregate = new PermissionAggregate(command.Id, command.EmployeeFirstName, command.EmployeeLastName, command.PermissionType);
            await _eventSourcingHandler.SaveAsync(aggregate);
        }

        public async Task HandleAsync(EditPermissionCommand command)
        {
            var aggregate = await _eventSourcingHandler.GetByIdAsync(command.Id);
            aggregate.ModifyPermission(command.PermissionType);

            await _eventSourcingHandler.SaveAsync(aggregate);
        }

        public async Task HandleAsync(RevokePermissionCommand command)
        {
            var aggregate = await _eventSourcingHandler.GetByIdAsync(command.Id);
            aggregate.RevokePermission();

            await _eventSourcingHandler.SaveAsync(aggregate);
        }
    }
}