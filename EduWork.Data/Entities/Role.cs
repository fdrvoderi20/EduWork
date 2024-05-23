using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EduWork.Entities
{
    [Table("Roles")]
    public class Role
    {
        [Key]
        public Guid RoleId { get; set; }

        [Required]
        [StringLength(60)]
        public string? RoleName { get; set; }

        public virtual ICollection<User>? Users { get; set; }
    }
}
