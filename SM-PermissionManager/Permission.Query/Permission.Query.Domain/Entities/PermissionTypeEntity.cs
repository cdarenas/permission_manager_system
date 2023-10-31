using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Permission.Query.Domain.Entities
{
    [Table("PermissionType")]
    public class PermissionTypeEntity
    {
        [Key]
        public Guid PermissionTypeId { get; set; }
        [Required]
        public string Description { get; set; }

        public static implicit operator PermissionTypeEntity(bool v)
        {
            throw new NotImplementedException();
        }
    }
}