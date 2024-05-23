using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EduWork.Entities
{
    [Table("Users")]
    public class User
    {
        [Key]
        public Guid UserId { get; set; }

        public int OID { get; set; }

        public int Active { get; set; }

        [ForeignKey("Role")]
        public Guid RoleId { get; set; } 

        public virtual Role? Role { get; set; }
        public virtual ICollection<User_WorkDay>? User_WorkDays { get; set; }
        public virtual ICollection<Overtime>? Overtimes { get; set; }
        public virtual ICollection<WorkOnProject>? WorkOnProjects { get; set; }
    }
}
