using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EduWork.Common
{
    [Table("Projects")]
    public class Project
    {
        [Key]
        public Guid ProjectId { get; set; }

        [Required]
        [StringLength(60)]
        public string? ProjectName { get; set; }

        [StringLength(255)]
        public string? Description { get; set; }

        [ForeignKey("ProjectType")]
        public Guid ProjectTypeId { get; set; } 
        public virtual ProjectType? ProjectType { get; set; }

        public virtual ICollection<WorkOnProject>? WorkOnProjects { get; set; }
    }
}
