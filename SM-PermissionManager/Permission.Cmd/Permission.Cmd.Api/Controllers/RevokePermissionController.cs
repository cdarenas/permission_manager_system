using CQRS.Core.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Permission.Cmd.Api.Commands;
using Permission.Cmd.Api.DTOs;
using Permission.Common.DTOs;

namespace Permission.Cmd.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class RevokePermissionController : ControllerBase
    {
        private readonly ILogger<RevokePermissionController> _logger;
        private readonly ICommandDispatcher _commandDispatcher;

        public RevokePermissionController(ILogger<RevokePermissionController> logger, ICommandDispatcher commandDispatcher)
        {
            _logger = logger;
            _commandDispatcher = commandDispatcher;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> RemovePermissionAsync(Guid id)
        {
            try
            {
                RevokePermissionCommand command = new() { Id = id, ModifiedDate = DateTime.UtcNow };
                await _commandDispatcher.SendAsync(command);

                return StatusCode(StatusCodes.Status201Created, new RevokePermissionResponse
                {
                    Message = $"The permission with id {id} was removed successfully!"
                });
            }
            catch (InvalidOperationException ex)
            {
                _logger.Log(LogLevel.Warning, ex, "Client made a bad request!");
                return BadRequest(new BaseResponse
                {
                    Message = ex.Message
                });
            }
            catch (Exception ex)
            {
                const string SAFE_ERROR_MESSAGE = "Error while processing request to delete a permission!";
                _logger.Log(LogLevel.Error, ex, SAFE_ERROR_MESSAGE);

                return StatusCode(StatusCodes.Status500InternalServerError, new RevokePermissionResponse
                {
                    Id = id,
                    Message = SAFE_ERROR_MESSAGE
                });
            }
        }
    }
}