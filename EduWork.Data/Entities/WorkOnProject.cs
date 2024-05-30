using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EduWork.Entities
{
    [Table("WorkOnProjects")]
    public class WorkOnProject
    {
        [Key]
        public Guid WorkOnProjectId { get; set; }

        public int WorkHours { get; set; }

        [StringLength(255)]
        public string? RoleOnProject { get; set; }

        [ForeignKey("User")]
        public Guid UserId { get; set; }  
        public virtual User? User { get; set; }

        [ForeignKey("Project")]
        public Guid ProjectId { get; set; } 
        public virtual Project? Project { get; set; }
    }
}
