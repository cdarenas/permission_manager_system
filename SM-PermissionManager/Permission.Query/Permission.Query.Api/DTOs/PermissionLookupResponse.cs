using Permission.Common.DTOs;
using Permission.Query.Domain.Entities;

namespace Permission.Query.Api.DTOs
{
    public class PermissionLookupResponse : BaseResponse
    {
        public List<PermissionEntity> Permissions { get; set; }
    }
}