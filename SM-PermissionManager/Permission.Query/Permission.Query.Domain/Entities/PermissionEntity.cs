using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Permission.Query.Domain.Entities
{
    [Table("Permission")]
    public class PermissionEntity
    {
        [Key]
        public Guid PermissionId { get; set; }
        [Required]
        public Guid PermissionTypeId { get; set; }
        public virtual PermissionTypeEntity PermissionTypeEntity { get; set; }
        [Required]
        public string EmployeeFirstName { get; set; }
        [Required]
        public string EmployeeLastName { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}