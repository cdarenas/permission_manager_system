using CQRS.Core.Infrastructure;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Permission.Cmd.Api.Commands;
using Permission.Cmd.Api.DTOs;
using Permission.Common.DTOs;

namespace Permission.Cmd.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class NewPermissionController : ControllerBase
    {
        private readonly ILogger<NewPermissionController> _logger;
        private readonly ICommandDispatcher _commandDispatcher;

        public NewPermissionController(ILogger<NewPermissionController> logger, ICommandDispatcher commandDispatcher)
        {
            _logger = logger;
            _commandDispatcher = commandDispatcher;
        }

        [EnableCors]
        [HttpPost]
        public async Task<ActionResult> NewPermissionAsync(NewPermissionCommand command)
        {
            var id = Guid.NewGuid();
            try
            {
                command.Id = id;
                await _commandDispatcher.SendAsync(command);

                return StatusCode(StatusCodes.Status201Created, new NewPermissionResponse
                {
                    Message = "The new permission was created successfully!"
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
                const string SAFE_ERROR_MESSAGE = "Error while processing request to create a new permission!";
                _logger.Log(LogLevel.Error, ex, SAFE_ERROR_MESSAGE);

                return StatusCode(StatusCodes.Status500InternalServerError, new NewPermissionResponse
                {
                    Id = id,
                    Message = SAFE_ERROR_MESSAGE
                });
            }
        }
    }
}