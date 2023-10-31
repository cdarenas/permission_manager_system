using Permission.Common.DTOs;

namespace Permission.Cmd.Api.DTOs
{
    public class RevokePermissionResponse : BaseResponse
    {
        public Guid Id { get; set; }
    }
}