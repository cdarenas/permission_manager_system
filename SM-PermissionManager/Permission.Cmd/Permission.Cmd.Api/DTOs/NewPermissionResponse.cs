using Permission.Common.DTOs;

namespace Permission.Cmd.Api.DTOs
{
    public class NewPermissionResponse : BaseResponse
    {
        public Guid Id { get; set; }
    }
}