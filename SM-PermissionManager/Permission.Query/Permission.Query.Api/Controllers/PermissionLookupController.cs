using CQRS.Core.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Permission.Common.DTOs;
using Permission.Query.Api.DTOs;
using Permission.Query.Api.Queries;
using Permission.Query.Domain.Entities;

namespace Permission.Query.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class PermissionLookupController : ControllerBase
    {
        private readonly ILogger<PermissionLookupController> _logger;
        private readonly IQueryDispatcher<PermissionEntity> _queryDispatcher;

        public PermissionLookupController(ILogger<PermissionLookupController> logger, IQueryDispatcher<PermissionEntity> queryDispatcher)
        {
            _logger = logger;
            _queryDispatcher = queryDispatcher;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllPermissionsAsync()
        {
            try
            {
                var permissions = await _queryDispatcher.SendAsync(new FindAllPermissionsQuery());

                if (permissions == null || !permissions.Any())
                    return NoContent();

                var count = permissions.Count;
                return Ok(new PermissionLookupResponse
                {
                    Permissions = permissions,
                    Message = $"We found {count} permission(s) in the QUERY database!"
                });
            }
            catch (Exception ex)
            {
                const string SAFE_ERROR_MESSAGE = "Error while processing request to retrieve all permissions!";
                _logger.LogError(ex, SAFE_ERROR_MESSAGE);

                return StatusCode(StatusCodes.Status500InternalServerError, new BaseResponse
                {
                    Message = SAFE_ERROR_MESSAGE
                });
            }
        }
    }
}